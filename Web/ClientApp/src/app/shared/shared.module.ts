import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { FormValidationComponent } from './form-validation/form-validation.component';
import { FaIconComponent } from './fa-icon/fa-icon.component';
import { UserNameComponent } from './user-name/user-name.component';
import { EnumsIconTypeComponent } from './enums-icon/enums-icon-type/enums-icon-type.component';


@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  declarations: [
    FormValidationComponent,
    FaIconComponent,
    UserNameComponent,
    EnumsIconTypeComponent
  ],
  exports: [
    FormValidationComponent,
    ReactiveFormsModule,
    CommonModule,
    FaIconComponent,
    UserNameComponent,
    EnumsIconTypeComponent
  ]
})
export class SharedModule { }
