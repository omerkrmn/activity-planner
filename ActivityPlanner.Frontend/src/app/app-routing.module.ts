import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ActivityComponent } from './components/activity/activity.component';
import { LoginComponent } from './pages/login/login.component';
import { NoAuthGuard } from './guards/auth.guard';
import { HomeComponent } from './components/home/home.component';
import { SignupComponent } from './pages/signup/signup.component';
import { CreateActivityComponent } from './create-activity/create-activity.component';

const routes: Routes = [
  {
    path: 'activity/:id',
    component: ActivityComponent
  }, {
    path: 'login',
    component: LoginComponent,
    canActivate: [NoAuthGuard]
  }, {
    path: 'activity',
    component: CreateActivityComponent
  }, {
    path: 'signup',
    component: SignupComponent
  }
  , {
    path: 'home',
    component: HomeComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
