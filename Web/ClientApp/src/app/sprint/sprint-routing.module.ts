import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';


const routes: Routes = [{
  path: 'sprint', children: [
    { path: 'dashboard', component: DashboardComponent }
  ]
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)]
})
export class SprintRoutingModule { }
