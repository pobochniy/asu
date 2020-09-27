import { AfterViewInit, Component, OnInit } from '@angular/core';
import { ChatApiService } from '../../api/chat-api.service';
import { UserService } from "../../core/user.service";
import { PushChatModel } from "../../models/push-chat.model";
import { ChatService } from "../chat.service";

@Component({
  selector: 'app-chat-window',
  templateUrl: './chat-window.component.html',
  styleUrls: ['./chat-window.component.css']
})
export class ChatWindowComponent implements OnInit {

  public text: string; // текстовове поле ввода
  private currentUser: string;

  constructor(
    public chatService: ChatService,
    public apiService: ChatApiService,
    public userService: UserService
  ) {
  }

  ngOnInit() {
    this.chatService.initConnection();

    if (this.userService && this.userService.User && this.userService.User.userName) {
      this.currentUser = this.userService.User.userName;
      this.chatService.connectionWebSocket();
    }
  }

  send() {
    this.chatService
      .send(this.text)
      .then(() => this.text = '');

    //this.skrollBottom();
  }

  async addTo(recipients: string[], sender: string) {
    this.addRecipientsToText(recipients, sender, false);
  }

  async addPrivat(recipients: string[], sender: string) {
    this.addRecipientsToText(recipients, sender, true);
  }

  private addRecipientsToText(recipients: string[], sender: string, isPrivate: boolean) {
    let msg = new PushChatModel(this.text);

    if (isPrivate) {
      this.addRecipientsToArray(msg.privat, recipients, sender);
    }
    else {
      this.addRecipientsToArray(msg.to, recipients, sender);
    }

    this.text = msg.toString();
  }

  private addRecipientsToArray(addTo: string[], addFrom: string[], sender: string) {
    for (let element of addFrom) {
      if (!addTo.includes(element)) {
        if (element == this.currentUser) {
          if (!addTo.includes(sender) && sender != this.currentUser) {
            addTo.push(sender);
          }
        }
        else {
          addTo.push(element);
        }
      }
    };
  }

  //skrollBottom() {
  //  // scrollContainer

  //  let objDiv = document.getElementById('scrollContainer');
  //  if (!objDiv) return;

  //  setTimeout(() => {
  //    objDiv.scrollTop = objDiv.scrollHeight;
  //  }, 50);
  //}

  //onEnter(e: any) {
  //  debugger;
  //  if (!e.shiftKey || !e.ctrlKey) {
  //    e.preventDefault()
  //    this.send();
  //  }
  //}

}
