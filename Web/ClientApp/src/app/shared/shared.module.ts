import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { FormValidationComponent } from './form-validation/form-validation.component';
import { FaIconComponent } from './fa-icon/fa-icon.component';
import { UserNameComponent } from './user-name/user-name.component';
import { EnumsIconTypeComponent } from './enums-icon/enums-icon-type/enums-icon-type.component';
import { EpicNameComponent } from './epic-name/epic-name.component';
import { ChatUserNameComponent } from './chat-user-name/chat-user-name.component';
import { TimeTrackingPopupComponent } from './time-tracking-popup/time-tracking-popup.component';
import { NgxSelectModule } from 'ngx-select-ex';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    NgxSelectModule
  ],
  declarations: [
    FormValidationComponent,
    FaIconComponent,
    UserNameComponent,
    EnumsIconTypeComponent,
    EpicNameComponent,
    ChatUserNameComponent,
    TimeTrackingPopupComponent,
  ],
  exports: [
    FormValidationComponent,
    ReactiveFormsModule,
    CommonModule,
    FaIconComponent,
    UserNameComponent,
    EpicNameComponent,
    EnumsIconTypeComponent,
    ChatUserNameComponent,
    TimeTrackingPopupComponent
  ]
})
export class SharedModule { }
