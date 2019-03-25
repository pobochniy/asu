import { Component, OnInit, Input } from '@angular/core';
import { ChatService } from '../chat.service';
import { ChatModel } from '../../models/chat.model';

@Component({
  selector: 'app-chat-window',
  templateUrl: './chat-window.component.html',
  styleUrls: ['./chat-window.component.css']
})
export class ChatWindowComponent implements OnInit {
  public message: string = '';

  constructor(
    private chatService: ChatService
  ) { }

  ngOnInit() {
    console.log(this.chatService);
  }

  get messageList(): ChatModel[] {
    return this.chatService.getMessageList;
  }

  send() {
    let model = new ChatModel();
    model.Content = this.message;
    model.Id = 15;
    model.Name = 'Alex Cherniy';

    this.chatService.sendMessage(model);
    this.message = '';
    this.skrollBottom();
  }

  skrollBottom() {
    // scrollContainer

    let objDiv = document.getElementById('scrollContainer');
    if (!objDiv) return;

    setTimeout(() => {
      objDiv.scrollTop = objDiv.scrollHeight;
    }, 50);
  }

}
