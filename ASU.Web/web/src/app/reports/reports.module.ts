import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {provideRouter, Routes} from "@angular/router";
import { MenuComponent } from './menu/menu.component';
import { UserTimeComponent } from './user-time/user-time.component';
import {SharedModule} from "../shared/shared.module";
import {TimeTrackingApiService} from "../shared/api/time-tracking-api.service";
import { ClosePeriodComponent } from './close-period/close-period.component';
import {ClosePeriodApiService} from "../shared/api/close-period-api.service";
import { ClosePeriodPopupComponent } from './close-period/close-period-popup/close-period-popup.component';


const routes: Routes = [{
  path: 'reports', children: [
    { path: '', redirectTo: 'user-time', pathMatch: 'full' },
    { path: 'user-time', component: UserTimeComponent },
    { path: 'close-period', component: ClosePeriodComponent },
  ]
}];

@NgModule({
  declarations: [
    MenuComponent,
    UserTimeComponent,
    ClosePeriodComponent,
    ClosePeriodPopupComponent,
  ],
  imports: [
    SharedModule,
    CommonModule
  ],
  providers: [provideRouter(routes),
    TimeTrackingApiService,
    ClosePeriodApiService
  ]
})
export class ReportsModule { }
