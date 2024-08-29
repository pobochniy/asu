import {Component} from '@angular/core';
import {Observable, Subject} from "rxjs";
import {TimeTrackingModel} from "../../../shared/models/time-tracking.model";
import {AlertsService} from "../../../shared/alerts/alerts.service";
import {closePeriodFormModel} from "../../../shared/form-models/close-period-form.model";
import {ClosePeriodApiService} from "../../../shared/api/close-period-api.service";

@Component({
  selector: 'app-close-period-popup',
  templateUrl: './close-period-popup.component.html',
  styleUrl: './close-period-popup.component.css'
})
export class ClosePeriodPopupComponent {
  public closePeriodForm = closePeriodFormModel;
  public isVisible = false;
  public sbj!: Subject<void>;

  constructor(private api: ClosePeriodApiService
    , private alertsService: AlertsService) {
  }

  public toggle() {
    this.isVisible = !this.isVisible;
  }

  public show(): Observable<void> {
    this.sbj = new Subject<void>();
    this.isVisible = true;
    this.closePeriodForm.patchValue({
      from: new Date().toISOString().substr(0, 10)
      , to: new Date().toISOString().substr(0, 10)
    });

    // this.cdRef.detectChanges();
    return this.sbj;
  }

  public async calculate() {
    try {
      await this.api.Calculate(this.closePeriodForm);

      this.isVisible = false;
      this.alertsService.push("primary", "Закрыли период", 5000);
      this.sbj.next();
    } catch (resp: any) {
      let err = '';
      for (const [key, value] of Object.entries(resp.error)) {
        err += `${value} / `;
      }
      this.alertsService.push("danger", err, 15_000);
    }
  }
}
