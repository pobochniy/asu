import { Component, Input, OnInit } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { TimeTrackingApiService } from '../api/time-tracking-api.service';
import { timeTrackingFormModel } from '../form-models/time-tracking-form.model';
import { TimeTrackingModel } from '../models/time-tracking.model';
@Component({
  selector: 'shared-time-tracking-popup',
  templateUrl: './time-tracking-popup.component.html',
  styleUrls: ['./time-tracking-popup.component.css'],
  providers: [TimeTrackingApiService]
})
export class TimeTrackingPopupComponent implements OnInit {

  public timeTrackingForm = timeTrackingFormModel;
  public isVisible = false;
  public model!: TimeTrackingModel;
  public sbj!: Subject<TimeTrackingModel>;
  public selectionList = [{ id: 1, name: 'epic1', type: 'Epics' },
    { id: 2, name: 'epic2', type: 'Epics' },
    { id: 3, name: 'epic3', type: 'Epics' },
    { id: 4, name: 'issue1', type: 'Issues' },
    { id: 5, name: 'issue2', type: 'Issues' },
    { id: 6, name: 'issue3', type: 'Issues' }];

  @Input('epicId') epicId?: number;
  @Input('issueId') issueId?: number;

  constructor(private api: TimeTrackingApiService) { }

  ngOnInit(): void {
    debugger
    //if (this.epicId || this.issueId) {
    //  this.epics = [this.epicId ? this.epicId : this.issueId];
    //}
    //else {
    this.selectionList = [{ id:1, name:'epic1', type: 'Epics'},
      { id: 2, name: 'epic2', type: 'Epics' },
      { id: 3, name: 'epic3', type: 'Epics' },
      { id: 4, name: 'issue1', type: 'Issues' },
      { id: 5, name: 'issue2', type: 'Issues' },
      { id: 6, name: 'issue3', type: 'Issues' }];
    //}
  }

  public toggle() {
    this.isVisible = !this.isVisible;
  }

  public show(model: TimeTrackingModel): Observable<TimeTrackingModel> {
    this.sbj = new Subject<TimeTrackingModel>();
    this.isVisible = true;
    this.model = model;

    this.model.date = new Date();
    return this.sbj;
  }

  public create() {
    this.api.Create(this.model).then(x => {
      this.isVisible = false;
      this.sbj.next(x!);
    }).catch(y => {
      let err = '';
      for (const [key, value] of Object.entries(y.error.errors)) {
        err += `${value}\n`;
      }
      alert(err);
    });

  }

  async onSubmit() {
    alert('OnSubmit');
  }
}
