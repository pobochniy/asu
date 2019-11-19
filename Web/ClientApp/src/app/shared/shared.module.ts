import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { FormValidationComponent } from './form-validation/form-validation.component';


@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
  ],
  declarations: [
    FormValidationComponent,

  ],
  exports: [
    FormValidationComponent,
    ReactiveFormsModule,
    CommonModule

  ]
})
export class SharedModule { }
