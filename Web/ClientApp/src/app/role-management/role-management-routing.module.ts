import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RoleManagementComponent } from './role-management.component';

const routes: Routes = [
  { path: 'rolemanagement', component: RoleManagementComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)]
})
export class RoleManagementRoutingModule { }
