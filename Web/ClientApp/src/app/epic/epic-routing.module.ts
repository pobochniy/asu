import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EditComponent } from '../epic/edit/edit.component';
import { DetailsComponent } from './details/details.component';
import { ListComponent } from './list/list.component';

const routes: Routes = [{
  path: 'epic', children: [
    { path: 'list', component: ListComponent },
    { path: 'edit/:id', component: EditComponent },
    { path: 'details/:id', component: DetailsComponent }
  ]
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)]
})
export class EpicRoutingModule { }
