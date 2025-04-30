import { Component, OnInit } from '@angular/core';
import { Activity } from '../../models/activity';
import { ActivitiesService } from '../../services/activities.service';
import { ActivatedRoute } from '@angular/router';
import { TitleCasePipe } from '@angular/common';

@Component({
  selector: 'app-activity',
  standalone: false,
  templateUrl: './activity.component.html',
  styleUrl: './activity.component.css',
})
export class ActivityComponent implements OnInit {
  username: string = '';
  activityname: string = '';
  activity: Activity | undefined;
  constructor(private activityService: ActivitiesService, private route: ActivatedRoute) {

  }
  ngOnInit(): void {
    this.route.paramMap.subscribe(
      params => {
        this.username = params.get('username') || '';
        this.activityname = params.get('activityname') || '';
      }
    );
    this.loadActivity(this.username,this.activityname);
  }
  loadActivity(username:string,activityname:string) {
    this.activityService.getOneActivity(username,activityname ).subscribe(res => {
      this.activity = res;
    });
  }
}

