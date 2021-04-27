import { NgModule } from '@angular/core';
import { EpicNameComponent } from '../shared/epic-name/epic-name.component';
import { SharedModule } from '../shared/shared.module';
import { DashboardComponent } from './dashboard/dashboard.component';
import { IssueCardComponent } from './issue-card/issue-card.component';
import { SprintRoutingModule } from './sprint-routing.module';
import { ListComponent } from './list/list.component';
import { EditComponent } from './edit/edit.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { DetailsComponent } from './details/details.component';

@NgModule({
  declarations: [DashboardComponent, IssueCardComponent, ListComponent, EditComponent, DetailsComponent],
  imports: [
    SprintRoutingModule,
    SharedModule,
    FormsModule,
    RouterModule
  ]
 
})
export class SprintModule { }
