import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {ProfileComponent} from './profile/profile.component';
import {provideRouter, Routes} from "@angular/router";
import {ReactiveFormsModule} from "@angular/forms";
import {SharedModule} from "../shared/shared.module";
import {HourlyPayApiService} from "../shared/api/hourly-pay-api.service";
import { HourlyPayPopupComponent } from './hourly-pay-popup/hourly-pay-popup.component';


const routes: Routes = [{
  path: 'profiles', children: [
    {path: '', redirectTo: 'user', pathMatch: 'full'},
    {path: 'user', component: ProfileComponent},
    {path: 'user/:userId', component: ProfileComponent},
  ]
}];

@NgModule({
  declarations: [
    ProfileComponent,
    HourlyPayPopupComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    SharedModule
  ],
  providers: [provideRouter(routes), HourlyPayApiService]
})
export class ProfilesModule {
}
