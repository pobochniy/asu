import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListComponent } from './list/list.component';

const routes: Routes = [{
  path: 'epic', children: [
    { path: 'list', component: ListComponent }
  ]
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)]
})
export class EpicRoutingModule { }
