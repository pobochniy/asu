import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module';
import { AddComponent } from './add/add.component';
import { IssueRoutingModule } from './issue-routing.module';
import { ListComponent } from './list/list.component';
import { NgxSelectModule } from 'ngx-select-ex';
import { FormsModule } from '@angular/forms';


@NgModule({
  imports: [
    SharedModule,
    IssueRoutingModule,
    RouterModule,
    NgxSelectModule,
    FormsModule
  ],
  declarations: [
    ListComponent,
    AddComponent,

  ]
})
export class IssueModule { }

