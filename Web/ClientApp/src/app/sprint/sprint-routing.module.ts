import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RolesGuard } from '../roles.guard';
import { UserRoleEnum } from '../shared/enums/user-role.enum';
import { DashboardComponent } from './dashboard/dashboard.component';
import { DetailsComponent } from './details/details.component';
import { EditComponent } from './edit/edit.component';
import { ListComponent } from './list/list.component';


const routes: Routes = [{
  path: 'sprint', children: [
    { path: 'dashboard', component: DashboardComponent },
    { path: '', redirectTo: 'list', pathMatch: 'full', canActivate: [RolesGuard], data: { allowedRoles: [UserRoleEnum.sprintCrud, UserRoleEnum.sprintRead] } },
    { path: 'list', component: ListComponent, canActivate: [RolesGuard], data: { allowedRoles: [UserRoleEnum.sprintRead, UserRoleEnum.sprintCrud] } },
    { path: 'edit/:id', component: EditComponent, canActivate: [RolesGuard], data: { allowedRoles: [UserRoleEnum.sprintCrud] } },
    { path: 'details/:id', component: DetailsComponent, canActivate: [RolesGuard], data: { allowedRoles: [UserRoleEnum.sprintCrud, UserRoleEnum.sprintRead] } }
  ]
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)]
})
export class SprintRoutingModule { }
