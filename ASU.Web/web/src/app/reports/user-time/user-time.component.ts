import {Component, OnInit} from '@angular/core';
import {AlertsService} from "../../shared/alerts/alerts.service";
import {TimeTrackingApiService} from "../../shared/api/time-tracking-api.service";
import {IUserTracking} from "../../shared/models/time-tracking.model";

@Component({
  selector: 'reports-user-time',
  templateUrl: './user-time.component.html',
  styleUrl: './user-time.component.css'
})
export class UserTimeComponent implements OnInit {
  public dataSource: IUserTracking[] = [];

  constructor(public alerts: AlertsService,
              private api: TimeTrackingApiService) {
  }

  async ngOnInit() {
    try {
      this.dataSource = await this.api.UserTracking();
    } catch {
      this.alerts.push("danger", 'Не удалось загрузить отчет');
    }
  }
}
