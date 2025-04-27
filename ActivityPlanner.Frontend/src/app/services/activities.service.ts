import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Activity } from '../models/activity';
import {ApplicationConstants} from '../utilities/application-constants';

@Injectable({
  providedIn: 'root'
})
export class ActivitiesService {
  private baseUrl: string = ApplicationConstants.Base_Url.toString() + "Activity/";

  constructor(private http: HttpClient) {
   }

  getOneActivity(userName: string, activityName: string):Observable<Activity> {
    var url = this.baseUrl + userName + "/" + activityName;
    return this.http.get<Activity>(url);
  }
}
