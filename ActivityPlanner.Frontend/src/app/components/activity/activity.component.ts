import { Component, OnInit } from '@angular/core';
import { Activity } from '../../models/activity';
import { ActivitiesService } from '../../services/activities.service';

@Component({
  selector: 'app-activity',
  standalone: false,
  templateUrl: './activity.component.html',
  styleUrl: './activity.component.css'
})
export class ActivityComponent implements OnInit {
  activity: Activity | undefined;
  constructor(private activityService: ActivitiesService) {

  }
  ngOnInit(): void {
    this.loadActivity()
  }
  loadActivity() {
    this.activityService.getOneActivity("Omer", "Test2").subscribe(res => {
      this.activity = res;
    });
  }
}

