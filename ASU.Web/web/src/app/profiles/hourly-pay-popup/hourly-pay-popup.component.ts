import {Component, Input} from '@angular/core';
import {Observable, Subject} from "rxjs";
import {hourlyPayFormModel} from "../../shared/form-models/hourly-pay-form.model";
import {HourlyPayApiService} from "../../shared/api/hourly-pay-api.service";
import {AlertsService} from "../../shared/alerts/alerts.service";

@Component({
  selector: 'app-hourly-pay-popup',
  templateUrl: './hourly-pay-popup.component.html',
  styleUrl: './hourly-pay-popup.component.css'
})
export class HourlyPayPopupComponent {

  public hourlyPayForm = hourlyPayFormModel;
  public isVisible = false;
  public sbj!: Subject<number>;
  public monthlyPay: number = 0;
  private hoursInMonth = 159;

  @Input('userId') userId?: string;

  constructor(public alerts: AlertsService,
    public api: HourlyPayApiService) {
  }


  public show(): Observable<number> {
    this.sbj = new Subject<number>();
    this.isVisible = true;
    this.hourlyPayForm.patchValue({
      userId: this.userId
      , startedDate: new Date().toISOString().substring(0, 10)
    });

    // this.cdRef.detectChanges();
    return this.sbj;
  }

  public toggle() {
    this.isVisible = !this.isVisible;
  }

  public async create() {
    try {
      const res = await this.api.Create(this.hourlyPayForm);

      this.isVisible = false;
      this.alerts.push("success", "Ставка добавлена", 5000);
      this.sbj.next(res!);
    } catch (resp: any) {
      this.alerts.push("danger", resp.error, 15_000);
    }
  }

  public calcMonthPay() {
    const hourlyPay = this.hourlyPayForm.get('cash')?.value || 0;
    this.monthlyPay = hourlyPay * this.hoursInMonth;
  }
  public calcHourPay(e: any) {
    if(!+e.target.value) return;
    const hourPay = +Number(+e.target.value / this.hoursInMonth).toFixed(2);
    this.hourlyPayForm.patchValue({
      cash: hourPay
    })
  }
}
