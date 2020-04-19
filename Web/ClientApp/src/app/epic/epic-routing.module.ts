import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListComponent } from './list/list.component';
import { AddComponent } from './add/add.component';
import { DetailsComponent } from './details/details.component';

const routes: Routes = [{
  path: 'epic', children: [
    { path: 'list', component: ListComponent },
    { path: 'add', component: AddComponent },
    { path: 'details/:id', component: DetailsComponent}
  ]
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)]
})
export class EpicRoutingModule { }
