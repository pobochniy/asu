import { NgModule } from '@angular/core';
import { EpicNameComponent } from '../shared/epic-name/epic-name.component';
import { SharedModule } from '../shared/shared.module';
import { DashboardComponent } from './dashboard/dashboard.component';
import { IssueCardComponent } from './issue-card/issue-card.component';
import { SprintRoutingModule } from './sprint-routing.module';
import { ListComponent } from './list/list.component';

@NgModule({
  declarations: [DashboardComponent, IssueCardComponent, ListComponent],
  imports: [
    SprintRoutingModule,
    SharedModule,
  ]
})
export class SprintModule { }
