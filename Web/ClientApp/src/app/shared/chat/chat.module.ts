import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChatWindowComponent } from './chat-window/chat-window.component';
import { ChatService } from './chat.service';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    FormsModule
  ],
  declarations: [
    ChatWindowComponent
  ],
  providers: [
    ChatService
  ],
  exports: [
    ChatWindowComponent
  ]
})
export class ChatModule { }
