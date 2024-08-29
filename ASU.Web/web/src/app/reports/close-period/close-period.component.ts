import {Component, OnInit, ViewChild} from '@angular/core';
import {AlertsService} from "../../shared/alerts/alerts.service";
import {ICrystalProfitPeriod} from "../../shared/models/i-crystal-profit-period";
import {ClosePeriodApiService} from "../../shared/api/close-period-api.service";
import {TimeTrackingPopupComponent} from "../../shared/time-tracking-popup/time-tracking-popup.component";
import {ClosePeriodPopupComponent} from "./close-period-popup/close-period-popup.component";
import {TimeTrackingModel} from "../../shared/models/time-tracking.model";

@Component({
  selector: 'app-close-period',
  templateUrl: './close-period.component.html',
  styleUrl: './close-period.component.css'
})
export class ClosePeriodComponent implements OnInit {

  @ViewChild(ClosePeriodPopupComponent) closePeriodPopup!: ClosePeriodPopupComponent;
  public dataSource: ICrystalProfitPeriod[] = [];

  constructor(public alerts: AlertsService,
              private api: ClosePeriodApiService) {
  }

  async ngOnInit() {
    try {
      this.dataSource = await this.api.GetList();
    } catch {
      this.alerts.push("danger", 'Не удалось загрузить отчет');
    }
  }

  public showPopup() {
    this.closePeriodPopup.show().subscribe((x: any) => {
    });
  }
}
