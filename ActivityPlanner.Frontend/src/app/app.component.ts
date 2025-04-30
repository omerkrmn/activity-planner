import { Component, OnInit } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { filter } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  showNavbarAndFooter: boolean = true;

  constructor(private router: Router) {}

  ngOnInit(): void {
    // Route değişikliklerini dinleyerek, gerekli sayfalarda navbar ve footer'ı gizliyoruz
    this.router.events.pipe(
      filter(event => event instanceof NavigationEnd)
    ).subscribe((event: NavigationEnd) => {
      const currentUrl = event.urlAfterRedirects;
      // Eğer belirli bir URL varsa, navbar ve footer'ı gizle
      this.showNavbarAndFooter = !currentUrl.includes('/activity');
    });
  }
}