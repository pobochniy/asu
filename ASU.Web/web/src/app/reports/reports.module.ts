import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {provideRouter, Routes} from "@angular/router";
import { MenuComponent } from './menu/menu.component';
import { UserTimeComponent } from './user-time/user-time.component';
import {SharedModule} from "../shared/shared.module";
import {TimeTrackingApiService} from "../shared/api/time-tracking-api.service";


const routes: Routes = [{
  path: 'reports', children: [
    { path: '', redirectTo: 'user-time', pathMatch: 'full' },
    { path: 'user-time', component: UserTimeComponent },
  ]
}];

@NgModule({
  declarations: [
    MenuComponent,
    UserTimeComponent,
  ],
  imports: [
    SharedModule,
    CommonModule
  ],
  providers: [provideRouter(routes),
    TimeTrackingApiService]
})
export class ReportsModule { }
