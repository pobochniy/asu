import { NgModule } from '@angular/core';
import { EpicNameComponent } from '../shared/epic-name/epic-name.component';
import { SharedModule } from '../shared/shared.module';
import { DashboardComponent } from './dashboard/dashboard.component';
import { IssueCardComponent } from './issue-card/issue-card.component';
import { SprintRoutingModule } from './sprint-routing.module';

@NgModule({
  declarations: [DashboardComponent, IssueCardComponent],
  imports: [
    SprintRoutingModule,
    SharedModule,
  ]
})
export class SprintModule { }
