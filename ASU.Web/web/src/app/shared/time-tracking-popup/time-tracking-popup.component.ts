import {ChangeDetectorRef, Component, Input, OnInit} from '@angular/core';
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
  public sbj!: Subject<TimeTrackingModel>;

  @Input('epicId') epicId?: number;
  @Input('issueId') issueId?: number;

  constructor(private api: TimeTrackingApiService
              , private cdRef: ChangeDetectorRef) { }

  ngOnInit(): void {
  }

  public toggle() {
    this.isVisible = !this.isVisible;
  }

  public show(model: TimeTrackingModel): Observable<TimeTrackingModel> {
    this.sbj = new Subject<TimeTrackingModel>();
    this.isVisible = true;
    this.timeTrackingForm.patchValue({
      id: model.id
      , Date: (model.date || new Date()).toISOString().substr(0,10)
      , from: (model.from || new Date()).toISOString().substr(11,5)
      , to: (model.to || new Date()).toISOString().substr(11,5)
      , Comment: model.comment || ''
      , userId: model.userId || undefined
      , IssueId: model.issueId
      , EpicId: model.epicId
      , issueEpicName: model.issueEpicName
    });

    this.cdRef.detectChanges();
    return this.sbj;
  }

  public create() {
    this.api.Create(this.timeTrackingForm).then(x => {
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
