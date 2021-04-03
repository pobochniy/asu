import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { EditComponent } from './edit/edit.component';
import { ListComponent } from './list/list.component';


const routes: Routes = [{
  path: 'sprint', children: [
    { path: 'dashboard', component: DashboardComponent },
    { path: 'list', component: ListComponent },
    { path: 'edit/:id', component: EditComponent }
  ]
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)]
})
export class SprintRoutingModule { }
