import {Component, OnInit} from '@angular/core';
import {AlertsService} from "../../shared/alerts/alerts.service";
import {TimeTrackingApiService} from "../../shared/api/time-tracking-api.service";
import {TimeTrackingModel} from "../../shared/models/time-tracking.model";

@Component({
  selector: 'reports-user-time',
  templateUrl: './user-time.component.html',
  styleUrl: './user-time.component.css'
})
export class UserTimeComponent implements OnInit {
  public dataSource: UserTracking[] = [];

  constructor(public alerts: AlertsService,
              private api: TimeTrackingApiService) {
  }

  async ngOnInit() {
    const resp = await this.api.GetList();
    if(!resp) return;
    const dates = resp
      .map(x=> x.date)
      .filter((x, i, a) => a.indexOf(x) === i);

    for(let i=0;i< dates.length;i++){
      let track = new UserTracking();
      track.date = dates[i]+'';
      track.tracks = resp
        .filter((x, i, a) => x.date+'' == track.date)
        .map(x=> new TimeTracks({from: x.from, to: x.to, comment: x.comment}));
      this.dataSource.push(track);
    }
  }

}

export class UserTracking {
  public date!: string;
  public tracks: TimeTracks[] = []
}

export class TimeTracks {
  public from: string = '';
  public to: string = '';
  public comment: string = '';

  constructor(obj: any = {}) {
    this.from = obj.from.substring(0,5);
    this.to = obj.to.substring(0,5);
    this.comment = obj.comment;
  }
}
