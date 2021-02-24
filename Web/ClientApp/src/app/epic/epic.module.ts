import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { NgxSelectModule } from 'ngx-select-ex';
import { EditComponent } from '../epic/edit/edit.component';
import { SharedModule } from '../shared/shared.module';
import { DetailsComponent } from './details/details.component';
import { EpicRoutingModule } from './epic-routing.module';
import { ListComponent } from './list/list.component';

@NgModule({
  imports: [
    SharedModule,
    EpicRoutingModule,
    RouterModule,
    NgxSelectModule,
    FormsModule
  ],
  declarations: [ListComponent, EditComponent, DetailsComponent]
})
export class EpicModule { }
