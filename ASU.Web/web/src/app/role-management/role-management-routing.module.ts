import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RoleManagementComponent } from './role-management.component';
import { RolesGuard } from '../roles.guard';
import { UserRoleEnum } from '../shared/enums/user-role.enum';

const routes: Routes = [
  {
    path: 'rolemanagement',
    component: RoleManagementComponent,
    canActivate: [RolesGuard],
    data: { allowedRoles: [UserRoleEnum.roleManagement] }
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  providers: [RolesGuard]
})
export class RoleManagementRoutingModule { }
