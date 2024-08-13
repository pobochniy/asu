import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {AppComponent} from './app.component';
import {HomeComponent} from "./home/home.component";
import {SharedModule} from "./shared/shared.module";
import {UsersApiService} from "./shared/api/users-api.service";
import {UserService} from "./shared/core/user.service";
import {ChatService} from "./shared/chat/chat.service";
import {AuthModule} from "./auth/auth.module";
import {NavModule} from "./shared/nav/nav.module";
import {NavTabsService} from "./shared/nav/nav-tabs.service";
import {RoleManagementModule} from "./role-management/role-management.module";
import {EpicModule} from "./epic/epic.module";
import {IssueModule} from "./issue/issue.module";
import {provideRouter, RouterModule, Routes} from "@angular/router";
import {SprintModule} from "./sprint/sprint.module";
import {AlertsService} from "./shared/alerts/alerts.service";
import {AlertsComponent} from "./shared/alerts/alerts.component";
import {ReportsModule} from "./reports/reports.module";
import {ProfilesModule} from "./profiles/profiles.module";

const routes: Routes = [{ path: '', component: HomeComponent, pathMatch: 'full' }];

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AlertsComponent
  ],
  imports: [
    AuthModule,
    BrowserModule,
    EpicModule,
    ReportsModule,
    ProfilesModule,
    IssueModule,
    NavModule,
    RoleManagementModule,
    SharedModule,
    SprintModule,
    RouterModule
  ],
  providers: [provideRouter(routes), UsersApiService, UserService, ChatService, NavTabsService, AlertsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
