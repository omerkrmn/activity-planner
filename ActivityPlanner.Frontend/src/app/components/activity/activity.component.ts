import { Component, OnInit } from '@angular/core';
import { Activity } from '../../models/activity';
import { ActivitiesService } from '../../services/activities.service';
import { ActivatedRoute } from '@angular/router';
import { TitleCasePipe } from '@angular/common';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SubscribersService } from '../../services/subscribers.service';
import { CreateSubscriberDTO } from '../../models/subscriber';

@Component({
  selector: 'app-activity',
  standalone: false,
  templateUrl: './activity.component.html',
  styleUrl: './activity.component.css',
})
export class ActivityComponent implements OnInit {
  subscriberForm!: FormGroup;

  username: string = '';
  activityname: string = '';

  activity: Activity | undefined;

  activityId: string = '';


  constructor(
    private activityService: ActivitiesService,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private subscribersService: SubscribersService) { }


  ngOnInit(): void {
    this.subscriberForm = this.fb.group({
      subscriberName: ['', [Validators.required]],
      subscriberSurname: ['', [Validators.required]],
      subscriberMail: ['', [Validators.required, Validators.email]],
      attendanceStatus: [null, [Validators.required]],
      note: ['']
    });
    this.route.paramMap.subscribe(
      params => {
        this.activityId = params.get('id') || '';

      }
    );
    this.loadActivity(Number(this.activityId));


  }
  loadActivity(activityId: number) {
    this.activityService.getOneActivity(activityId).subscribe(res => {
      this.activity = res;
    });
  }
  onSubmit(): void {
    if (this.subscriberForm.valid) {
      const formValues = this.subscriberForm.value;

      // activityId route'dan alınıyor ve DTO'ya ekleniyor
      const subscriberDTO: CreateSubscriberDTO = {
        subscriberName: formValues.subscriberName,
        subscriberSurname: formValues.subscriberSurname,
        subscriberMail: formValues.subscriberMail,
        mailValidation: "", // opsiyonel değilse boş string gönder
        attendanceStatus: Number(formValues.attendanceStatus),
        activityId: Number(this.activity?.id), // veya this.activityId uygun şekilde
        note: formValues.note || "" // opsiyonel değilse boş string gönder
      };

      this.subscribersService.createSubscriber(this.activityId, subscriberDTO)
        .subscribe({
          next: (response) => {
            console.log('Kullanıcı başarıyla abone oldu:', response);
            this.subscriberForm.reset();
            window.location.reload();
          },
          error: (error) => {
            console.error('Abonelik hatası:', error);
          }
        });
    } else {
      console.log('Form geçerli değil');
    }
  }
  getRemainingDays(dateString: string | Date | undefined): string {
    if (!dateString) return 'Tarih yok';

    const now = new Date().getTime();
    const target = new Date(dateString).getTime();
    const diff = target - now;

    if (diff <= 0) return 'Süre doldu';

    const days = Math.floor(diff / (1000 * 60 * 60 * 24));
    const hours = Math.floor((diff % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
    const minutes = Math.floor((diff % (1000 * 60 * 60)) / (1000 * 60));
    const seconds = Math.floor((diff % (1000 * 60)) / 1000);

    return `${days == 0 ? '' : days + 'gün ,'} ${hours} saat, ${minutes} dakika, ${seconds} saniye kaldı`;
  }
}

