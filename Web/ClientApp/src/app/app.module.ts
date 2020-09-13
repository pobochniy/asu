import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { NgxSelectModule } from 'ngx-select-ex';
import { AppComponent } from './app.component';
import { AuthModule } from './auth/auth.module';
import { HomeComponent } from './home/home.component';
import { IssueModule } from './issue/issue.module';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { ChatModule } from './shared/chat/chat.module';
import { ChatService } from './shared/chat/chat.service';
import { UserService } from './shared/core/user.service';
import { SharedModule } from './shared/shared.module';
import { EpicModule } from './epic/epic.module';
import { RoleManagementModule } from './role-management/role-management.module';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    SharedModule,
    FormsModule,
    ChatModule,
    AuthModule,
    IssueModule,
    EpicModule,
    RoleManagementModule,
    NgxSelectModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' }
    ])
  ],
  providers: [UserService, ChatService],
  bootstrap: [AppComponent],
})
export class AppModule { }
