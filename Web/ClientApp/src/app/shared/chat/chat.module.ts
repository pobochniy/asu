import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChatWindowComponent } from './chat-window/chat-window.component';
import { FormsModule } from '@angular/forms';
import { ChatService } from './chat.service';
import { ChatApiService } from '../api/chat-api.service';
import { ChatResizerDirective } from './chat-resizer.directive';
import { UserService } from "../core/user.service";

@NgModule({
  imports: [
    CommonModule,
    FormsModule
  ],
  declarations: [
    ChatWindowComponent,
    ChatResizerDirective
  ],
  providers: [
    ChatService,
    ChatApiService,
    UserService
  ],
  exports: [
    ChatWindowComponent
  ]
})
export class ChatModule { }
