import { Component, OnInit, Input, AfterViewInit } from '@angular/core';
import { ChatModel } from '../../models/chat.model';
import { from } from "rxjs/observable/from";
import { ChatService } from "../chat.service";
import { PushChatModel } from "../../models/push-chat.model";

@Component({
  selector: 'app-chat-window',
  templateUrl: './chat-window.component.html',
  styleUrls: ['./chat-window.component.css']
})
export class ChatWindowComponent implements OnInit, AfterViewInit {

  public text: string; // текстовове поле ввода

  constructor(
    public chatService: ChatService
  ) { }

  ngOnInit() {
    let text = "to [bla1, bla2] hello!!";
    new PushChatModel(text);
    this.chatService.initConnection();
  }

  ngAfterViewInit() {
    this.chatService.connectionWebSocket();
  }
    
  send() {
    this.chatService.send(this.text);
    this.text = '';

    //this.skrollBottom();
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
