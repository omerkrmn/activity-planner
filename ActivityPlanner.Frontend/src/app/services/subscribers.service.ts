import { Injectable } from '@angular/core';
import { ApplicationConstants } from '../utilities/application-constants';
import { HttpClient } from '@angular/common/http';
import { CreateSubscriberDTO, DeleteSubscriberDTO } from '../models/subscriber';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SubscribersService {
  private baseUrl: string = ApplicationConstants.Base_Url.toString() + "Subscriber";

  constructor(private http: HttpClient) { }
  createSubscriber(data: CreateSubscriberDTO): Observable<any> {
    return this.http.post(this.baseUrl, data);
  }
  UpdateSubscribe() { }
  deleteSubscribe(request: DeleteSubscriberDTO): Observable<any> {
    return this.http.request('DELETE', this.baseUrl, {
      body: request
    });
  }
}
