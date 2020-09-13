import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RoleManagementComponent } from './role-management.component';
import { RoleManagementRoutingModule } from './role-management-routing.module';

@NgModule({
  imports: [
    CommonModule,
    RoleManagementRoutingModule
  ],
  declarations: [RoleManagementComponent]
})
export class RoleManagementModule { }
