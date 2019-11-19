import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module';
import { AddComponent } from './add/add.component';
import { IssueRoutingModule } from './issue-routing.module';
import { ListComponent } from './list/list.component';


@NgModule({
  imports: [
    SharedModule,
    IssueRoutingModule,
    RouterModule
  ],
  declarations: [
    ListComponent,
    AddComponent,

  ]
})
export class IssueModule { }

