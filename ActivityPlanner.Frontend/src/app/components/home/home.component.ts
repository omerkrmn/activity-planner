import { Component, OnInit } from '@angular/core';
import { ActivitiesService, ActivityQuery } from '../../services/activities.service';
import { Activity } from '../../models/activity';

@Component({
  selector: 'app-home',
  standalone: false,
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  activities: Activity[] = [];
  loading = false;
  error: string | null = null;

  // Basit filtre state'i (opsiyonel)
  country = '';
  city = '';
  date: string | null = ""; // 'YYYY-MM-DD'
  pageNumber: number=1;
  pageSize: number =10;

  constructor(private activitiesService: ActivitiesService) {}

  ngOnInit(): void {
    this.loadActivities();
  }

  loadActivities(q?: ActivityQuery): void {
    this.loading = true;
    this.error = null;

    this.activitiesService.getAllActivities(q).subscribe({
      next: (res) => {
        this.activities = res ?? [];
        this.loading = false;
      },
      error: (err) => {
        console.error(err);
        this.error = 'Aktiviteler çekilirken bir hata oluştu.';
        this.loading = false;
      }
    });
  }

  applyFilters(): void {
    const query: ActivityQuery = {
      country: this.country?.trim() || undefined,
      city: this.city?.trim() || undefined,
      date: this.date || undefined,
      pageNumber: this.pageNumber || undefined,
      pageSize: this.pageSize || undefined
    };
    this.loadActivities(query);
  }

  clearFilters(): void {
    this.country = '';
    this.city = '';
    this.date = null;
    this.loadActivities();
  }

  trackById(_: number, a: Activity) {
    return (a as any).id ?? a.activityName; // id yoksa activityName
  }
}
