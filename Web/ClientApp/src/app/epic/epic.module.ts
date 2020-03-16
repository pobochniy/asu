import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListComponent } from './list/list.component';
import { EpicRoutingModule } from './epic-routing.module';
import { SharedModule } from '../shared/shared.module';
import { RouterModule } from '@angular/router';
import { NgxSelectModule } from 'ngx-select-ex';
import { FormsModule } from '@angular/forms';
import { AddComponent } from './add/add.component';

@NgModule({
  imports: [
    SharedModule,
    EpicRoutingModule,
    RouterModule,
    NgxSelectModule,
    FormsModule
  ],
  declarations: [ListComponent, AddComponent]
})
export class EpicModule { }
