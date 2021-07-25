import { Component, OnInit } from '@angular/core';
import { TimeTrackingApiService } from '../api/time-tracking-api.service';
import { TimeTrackingModel } from '../models/time-tracking.model';

@Component({
  selector: 'shared-time-tracking-popup',
  templateUrl: './time-tracking-popup.component.html',
  styleUrls: ['./time-tracking-popup.component.css']
})
export class TimeTrackingPopupComponent implements OnInit {

  public isVisible = false;
  public model: TimeTrackingModel;

  constructor(private api: TimeTrackingApiService) { }

  ngOnInit(): void {
  }

  public toggle() {
    this.isVisible = !this.isVisible;
  }

  public show(model: TimeTrackingModel) {
    this.isVisible = true;
    this.model = model;
  }

  public create() {
    var res = this.api.Create(this.model);
    this.isVisible = false;

    return res;
  }
}
