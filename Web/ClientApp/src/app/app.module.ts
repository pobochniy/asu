import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { ChatModule } from './shared/chat/chat.module';
import { UserModel } from './shared/models/user.model';
import { AuthModule } from './auth/auth.module';
import { IssueModule } from './issue/issue.module';
import { FormValidationComponent } from './shared/form-validation/form-validation.component';
import { SharedModule } from './shared/shared.module';
import { NgxSelectModule } from 'ngx-select-ex';

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
    NgxSelectModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' }
    ])
  ],
  providers: [UserModel],
  bootstrap: [AppComponent],
})
export class AppModule { }
