import { EventEmitter, Injectable } from '@angular/core';
import { Subscription } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EventEmitterService {

  invokeMenuToggleMenuFunction = new EventEmitter();
  subsMenu: Subscription;

  invokeWideChatFunction = new EventEmitter();
  subsChat: Subscription;

  constructor() { }

  onToggleMenuButtonClick() {
    this.invokeMenuToggleMenuFunction.emit();
    this.invokeWideChatFunction.emit();
  }
}
