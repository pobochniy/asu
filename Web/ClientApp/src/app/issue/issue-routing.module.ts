import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListComponent } from './list/list.component';
import { AddComponent } from './add/add.component';
import { EditComponent } from './edit/edit.component';

const routes: Routes = [{
  path: 'issue', children: [
    { path: 'list', component: ListComponent },
    { path: 'add', component: AddComponent },
    { path: 'edit/:id', component: EditComponent },
  ]
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)]
})
export class IssueRoutingModule { }
