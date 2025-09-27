// activities.service.ts
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Activity, ActivityCreateRequest } from '../models/activity';
import { ApplicationConstants } from '../utilities/application-constants';

export interface ActivityQuery {
  country?: string;
  city?: string;
  date?: string | Date;   // yyyy-MM-dd veya Date
  pageNumber?: number;
  pageSize?: number;
}

@Injectable({ providedIn: 'root' })
export class ActivitiesService {
  private readonly baseUrl = `${ApplicationConstants.Base_Url.replace(/\/+$/, '')}/activities`;

  constructor(private http: HttpClient) {}

  getOneActivity(activityId: number): Observable<Activity> {
    return this.http.get<Activity>(`${this.baseUrl}/${activityId}`);
  }

  getAllActivities(q?: ActivityQuery): Observable<Activity[]> {
    let params = new HttpParams();

    if (q?.country?.trim()) params = params.set('country', q.country.trim());
    if (q?.city?.trim()) params = params.set('city', q.city.trim());

    if (q?.date) {
      const d =
        typeof q.date === 'string'
          ? q.date
          : new Date(Date.UTC(
              q.date.getFullYear(),
              q.date.getMonth(),
              q.date.getDate()
            ))
              .toISOString()
              .slice(0, 10); // yyyy-MM-dd
      params = params.set('date', d);
    }

    if (typeof q?.pageNumber === 'number') {
      params = params.set('pageNumber', String(q.pageNumber));
    }
    if (typeof q?.pageSize === 'number') {
      params = params.set('pageSize', String(q.pageSize));
    }

    return this.http.get<Activity[]>(this.baseUrl, { params });
  }

  createActivity(payload: ActivityCreateRequest): Observable<Activity> {
    return this.http.post<Activity>(this.baseUrl, payload);
  }

  deleteActivity(activityId: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${activityId}`);
  }
}
