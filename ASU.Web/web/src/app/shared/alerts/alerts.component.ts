import {Component} from '@angular/core';
import {AlertsService} from "./alerts.service";

@Component({
  selector: 'shared-alerts',
  templateUrl: './alerts.component.html',
  styleUrl: './alerts.component.css'
})
export class AlertsComponent {
  constructor(public alertsService: AlertsService) {
  }

  public removeAlert(id: number){
    this.alertsService.remove(id);
  }
}
