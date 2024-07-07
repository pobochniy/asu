import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RoleManagementComponent } from './role-management.component';
import { RoleManagementRoutingModule } from './role-management-routing.module';
import { NgxSelectModule } from 'ngx-select-ex';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    RoleManagementRoutingModule,
    NgxSelectModule
  ],
  declarations: [RoleManagementComponent]
})
export class RoleManagementModule { }
