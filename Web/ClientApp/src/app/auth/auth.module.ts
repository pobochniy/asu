import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './login/login.component';
import { AuthRoutingModule } from './auth-routing.module';
import { RegisterComponent } from './register/register.component';
import { FormValidationComponent } from '../shared/form-validation/form-validation.component';


@NgModule({
  imports: [
    AuthRoutingModule,
    CommonModule,
    ReactiveFormsModule
  ],
  declarations: [
    LoginComponent,
    RegisterComponent,
    FormValidationComponent
  ]
})
export class AuthModule { }
