import { Component, OnInit } from '@angular/core';
import { Activity } from '../../models/activity';
import { ActivitiesService } from '../../services/activities.service';
import { ActivatedRoute } from '@angular/router';
import { TitleCasePipe } from '@angular/common';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SubscribersService } from '../../services/subscribers.service';

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
      attendanceStatus: [null, [Validators.required]]
    });
    this.route.paramMap.subscribe(
      params => {
        this.username = params.get('username') || '';
        this.activityname = params.get('activityname') || '';
      }
    );
    this.loadActivity(this.username, this.activityname);
  }
  loadActivity(username: string, activityname: string) {
    this.activityService.getOneActivity(username, activityname).subscribe(res => {
      this.activity = res;
    });
  }
  onSubmit(): void {
    if (this.subscriberForm.valid) {
      const subscriberData = this.subscriberForm.value;

      const subscriberDTO = {
        subscriberName: subscriberData.subscriberName,  // Bu veriyi ekleyebilirsiniz
        subscriberSurname: subscriberData.subscriberSurname,
        subscriberMail: subscriberData.subscriberMail,
        mailValidation: "",
        attendanceStatus: Number(subscriberData.attendanceStatus),
        activityId: Number(this.activity?.id)// Activity ID burada gönderilebilir
      };
      console.log(subscriberDTO);

      this.subscribersService.createSubscriber(subscriberDTO).subscribe(
        (response) => {
          console.log('Kullanıcı başarıyla abone oldu:', response);
          // Burada success mesajı veya yönlendirme yapabilirsiniz
        },
        (error) => {
          console.error('Abonelik hatası:', error);
        }
      );
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

