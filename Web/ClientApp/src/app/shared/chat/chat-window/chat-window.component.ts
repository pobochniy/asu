import { Component, OnInit, Input, AfterViewInit } from '@angular/core';
import { ChatModel } from '../../models/chat.model';
import { from } from "rxjs/observable/from";
import { ChatService } from "../chat.service";
import { PushChatModel } from "../../models/push-chat.model";
import { ChatApiService } from '../../api/chat-api.service';
import { forEach } from '@angular/router/src/utils/collection';
import { UserService } from "../../core/user.service";

@Component({
  selector: 'app-chat-window',
  templateUrl: './chat-window.component.html',
  styleUrls: ['./chat-window.component.css']
})
export class ChatWindowComponent implements OnInit, AfterViewInit {

  public text: string; // текстовове поле ввода
  private currentUser: string;

  constructor(
    public chatService: ChatService,
    public apiService: ChatApiService,
    public userService: UserService
  ) {
    debugger

    if (this.userService && this.userService.User && this.userService.User.login) {
      this.currentUser = this.userService.User.login;
    }
  }

  ngOnInit() {
    this.chatService.initConnection();
  }

  ngAfterViewInit() {
    this.chatService.connectionWebSocket();
  }
    
  async send() {
    const msg = new PushChatModel(this.text);
    //await this.apiService.send(msg);

    this.chatService.send(this.text);
    this.text = '';

    //this.skrollBottom();
  }

  async addTo(to: string[], sender: string) {
    if (!this.text) {
      this.text = "";
    }

    let msg = new PushChatModel(this.text);

    if (!msg.to) {
      msg.to = [];
    }

    this.addToArray(msg.to, to, sender);

    this.text = msg.toString();
  }

  async addPrivat(privat: string[], sender: string) {
    if (!this.text) {
      this.text = "";
    }

    let msg = new PushChatModel(this.text);

    if (!msg.privat) {
      msg.privat = [];
    }

    this.addToArray(msg.privat, privat, sender);

    this.text = msg.toString();
  }

  private addToArray(to: string[], from: string[], sender: string) {
    let _currentUser = this.currentUser;

    from.forEach(function (element) {
      if (!to.includes(element)) {
        if (element == _currentUser) {
          if (!to.includes(sender) && sender != _currentUser) {
            to.push(sender);
          }
        }
        else {
          to.push(element);
        }
      }
    });
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
