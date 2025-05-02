import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  standalone: false,
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent implements OnInit {
  isLoggedIn: boolean = false; // Kullanıcının giriş durumu.

  constructor(private authService: AuthService,private router:Router) { }

  ngOnInit(): void {
    this.isLoggedIn = this.authService.isLoggedIn();
  }
  logout() {
    this.authService.logOut(); // kullanıcı oturumunu sonlandır
    this.router.navigate(['/login']); // login sayfasına yönlendir
  }
}
