import {ChangeDetectorRef, Component, Input, OnInit} from '@angular/core';
import {Observable, Subject} from 'rxjs';
import {TimeTrackingApiService} from '../api/time-tracking-api.service';
import {timeTrackingFormModel} from '../form-models/time-tracking-form.model';
import {TimeTrackingModel} from '../models/time-tracking.model';
import {AlertsService} from "../alerts/alerts.service";

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
    , private alertsService: AlertsService
    , private cdRef: ChangeDetectorRef) {
  }

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
      , Date: (model.date || new Date()).toISOString().substr(0, 10)
      , from: (model.from || new Date()).toISOString().substr(11, 5)
      , to: (model.to || new Date()).toISOString().substr(11, 5)
      , Comment: model.comment || ''
      , userId: model.userId || undefined
      , IssueId: model.issueId
      , EpicId: model.epicId
      , issueEpicName: model.issueEpicName
    });

    this.cdRef.detectChanges();
    return this.sbj;
  }

  public async create() {
    try {
      const res = await this.api.Create(this.timeTrackingForm);

      this.isVisible = false;
      this.alertsService.push("primary", "Время учтено", 5000);
      this.sbj.next(res!);
    } catch (resp: any) {
      let err = '';
      for (const [key, value] of Object.entries(resp.error)) {
        err += `${value} / `;
      }
      this.alertsService.push("danger", err, 15_000);
    }
  }

  async onSubmit() {
    alert('OnSubmit');
  }
}
