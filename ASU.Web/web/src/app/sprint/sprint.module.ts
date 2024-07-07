import {SharedModule} from '../shared/shared.module';
import {DashboardComponent} from './dashboard/dashboard.component';
import {IssueCardComponent} from './issue-card/issue-card.component';
import {ListComponent} from './list/list.component';
import {EditComponent} from './edit/edit.component';
import {DetailsComponent} from './details/details.component';
import {NgModule} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {provideRouter, RouterModule, Routes} from '@angular/router';
import {UserRoleEnum} from "../shared/enums/user-role.enum";
import {RolesGuard} from "../roles.guard";

const routes: Routes = [{
  path: 'sprint', children: [
    { path: 'dashboard', component: DashboardComponent },
    { path: '', redirectTo: 'list', pathMatch: 'full', data: { allowedRoles: [UserRoleEnum.sprintCrud, UserRoleEnum.sprintRead] } },
    { path: 'list', component: ListComponent, canActivate: [RolesGuard], data: { allowedRoles: [UserRoleEnum.sprintRead, UserRoleEnum.sprintCrud] } },
    { path: 'edit/:id', component: EditComponent, canActivate: [RolesGuard], data: { allowedRoles: [UserRoleEnum.sprintCrud] } },
    { path: 'details/:id', component: DetailsComponent, canActivate: [RolesGuard], data: { allowedRoles: [UserRoleEnum.sprintCrud, UserRoleEnum.sprintRead] } }
  ]
}];

@NgModule({
  declarations: [DashboardComponent, IssueCardComponent, ListComponent, EditComponent, DetailsComponent],
  imports: [
    SharedModule,
    FormsModule,
    RouterModule
  ],
  providers: [provideRouter(routes)]
})
export class SprintModule { }
