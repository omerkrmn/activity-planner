import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApplicationConstants } from '../utilities/application-constants';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseUrl: string = ApplicationConstants.Base_Url.toString() + "Authentication/login";

  constructor(private http: HttpClient) { }

  login(loginData: { email: string; password: string }): Observable<any> {
    console.log(this.baseUrl);
    return this.http.post<any>(this.baseUrl, loginData);
  }
  saveToken(token: string): void {
    localStorage.setItem('access_token', token);
  }

  getToken(): string | null {
    return localStorage.getItem('access_token');
  }

  removeToken(): void {
    localStorage.removeItem('access_token');
  }
}