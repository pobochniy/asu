import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { IssueRoutingModule } from './issue-routing.module';
import { ListComponent } from './list/list.component';


@NgModule({
  imports: [
    IssueRoutingModule,
    CommonModule,
    ReactiveFormsModule
  ],
  declarations: [
    ListComponent,
  ]
})
export class IssueModule { }

