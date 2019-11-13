import { Component, OnInit, Input, AfterViewInit } from '@angular/core';
import { ChatModel } from '../../models/chat.model';
import { from } from "rxjs/observable/from";
import { ChatService } from "../chat.service";
import { PushChatModel } from "../../models/push-chat.model";
import { ChatApiService } from '../../api/chat-api.service';
import { forEach } from '@angular/router/src/utils/collection';

@Component({
  selector: 'app-chat-window',
  templateUrl: './chat-window.component.html',
  styleUrls: ['./chat-window.component.css']
})
export class ChatWindowComponent implements OnInit, AfterViewInit {

  public text: string; // текстовове поле ввода

  constructor(
    public chatService: ChatService,
    public apiService: ChatApiService
  ) { }

  ngOnInit() {
    this.chatService.initConnection();
  }

  ngAfterViewInit() {
    this.chatService.connectionWebSocket();
  }
    
  async send() {
    debugger
    const msg = new PushChatModel(this.text);
    //await this.apiService.send(msg);

    this.chatService.send(this.text);
    this.text = '';

    //this.skrollBottom();
  }

  async addTo(to: string[]) {
    debugger

    if (!this.text)
      this.text = "";

    let msg = new PushChatModel(this.text);

    if (!msg.to) 
      msg.to = [];

    to.forEach(function (element) {
      if (!msg.to.includes(element))
        msg.to.push(element);
    });

    this.text = msg.toString();
  }

  async addPrivat(privat: string[]) {
    debugger

    if (!this.text)
      this.text = "";

    let msg = new PushChatModel(this.text);

    if (!msg.privat)
      msg.privat = [];

    privat.forEach(function (element) {
      if (!msg.privat.includes(element))
        msg.privat.push(element);
    });

    this.text = msg.toString();
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
