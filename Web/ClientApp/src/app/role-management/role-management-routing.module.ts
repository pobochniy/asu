import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RoleManagementComponent } from './role-management.component';
import { RoleManagementGuard } from './role-management.guard';

const routes: Routes = [
  { path: 'rolemanagement', component: RoleManagementComponent, canActivate: [RoleManagementGuard] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  providers: [RoleManagementGuard]
})
export class RoleManagementRoutingModule { }
