import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { AuthRoutingModule } from './auth-routing.module';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';


@NgModule({
  imports: [
    SharedModule,
    AuthRoutingModule,
  ],
  declarations: [
    LoginComponent,
    RegisterComponent,
  ]
})
export class AuthModule { }
