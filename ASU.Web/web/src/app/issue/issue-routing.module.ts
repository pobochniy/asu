import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListComponent } from './list/list.component';
import { EditComponent } from './edit/edit.component';
import { RolesGuard } from '../roles.guard';
import { UserRoleEnum } from '../shared/enums/user-role.enum';

const routes: Routes = [{
  path: 'issue', children: [
    { path: '', redirectTo: 'list', pathMatch: 'full', data: { allowedRoles: [UserRoleEnum.issueCrud, UserRoleEnum.issueRead] } },
    { path: 'list', component: ListComponent, canActivate: [RolesGuard], data: { allowedRoles: [UserRoleEnum.issueCrud, UserRoleEnum.issueRead] } },
    { path: 'edit/:id', component: EditComponent, canActivate: [RolesGuard], data: { allowedRoles: [UserRoleEnum.issueCrud] } },
  ]
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class IssueRoutingModule { }
