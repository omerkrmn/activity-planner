import { Injectable } from '@angular/core';
import { CanActivate, CanActivateFn, Router } from '@angular/router';
@Injectable({
  providedIn: 'root'
})
export class NoAuthGuard implements CanActivate {

  constructor(private router: Router) { }

  canActivate(): boolean {
    const token = localStorage.getItem('access_token');
    if (token) {
      this.router.navigate(['/activity/Omer/Test2']);
      return false;
    }
    return true;
  }
}