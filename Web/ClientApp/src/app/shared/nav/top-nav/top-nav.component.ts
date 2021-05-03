import { Component, OnInit } from '@angular/core';
import { EventEmitterService } from '../event-emitter.service';

@Component({
  selector: 'top-nav',
  templateUrl: './top-nav.component.html',
  styleUrls: ['./top-nav.component.css']
})
export class TopNavComponent implements OnInit {

  constructor(
    private eventEmitterService: EventEmitterService
  ) { }

  ngOnInit() {
  }

  toggleMenu() {
    this.eventEmitterService.onToggleMenuButtonClick();
  }
}
