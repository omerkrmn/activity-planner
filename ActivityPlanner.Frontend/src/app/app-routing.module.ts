import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ActivityComponent } from './components/activity/activity.component';
import { LoginComponent } from './pages/login/login.component';

const routes: Routes = [
  {
    path: 'activity',
    component: ActivityComponent
  },{
    path: 'login',
    component: LoginComponent
  },{
    path: 'activity',
    component: ActivityComponent
  },{
    path: 'activity',
    component: ActivityComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
