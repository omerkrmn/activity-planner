import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApplicationConstants } from '../utilities/application-constants';
import { SubscriberCreateDTO, SubscriberUpdateDTO, CreateSubscriberDTO } from '../models/subscriber';

@Injectable({
  providedIn: 'root'
})
export class SubscribersService {
  private baseUrl = `${ApplicationConstants.Base_Url.replace(/\/+$/, '')}/activities`;
  constructor(private http: HttpClient) {}


  getSubscribersByActivity(activityId: string): Observable<CreateSubscriberDTO[]> {
    const url = `${this.baseUrl}/${activityId}/subscribers`;
    return this.http.get<CreateSubscriberDTO[]>(url);
  }

  createSubscriber(activityId: string, data: SubscriberCreateDTO): Observable<CreateSubscriberDTO> {
    const url = `${this.baseUrl}/${activityId}/subscribers`;
    return this.http.post<CreateSubscriberDTO>(url, data);
  }
  
  updateSubscriber(activityId: string, data: SubscriberUpdateDTO): Observable<CreateSubscriberDTO> {
    const url = `${this.baseUrl}/${activityId}/subscribers/${data.subscriberId}`;
    return this.http.put<CreateSubscriberDTO>(url, data);
  }


  deleteSubscriber(activityId: string, subscriberId: string): Observable<void> {
    const url = `${this.baseUrl}/${activityId}/subscribers/${subscriberId}`;
    return this.http.delete<void>(url);
  }
}
