import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SprintApiService } from '../../shared/api/sprint-api.service';
import { DashboardModel } from '../../shared/models/dashboard.model';

@Component({
  selector: 'details-sprint',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css'],
  providers: [SprintApiService, DatePipe]
})
export class DetailsComponent implements OnInit {

  public sprint: DashboardModel = new DashboardModel();

  constructor(private service: SprintApiService
    , private route: ActivatedRoute
    , private router: Router
    , public datepipe: DatePipe
  ) {
  }

  async ngOnInit() {
    const id = +this.route.snapshot.paramMap.get('id');

    this.sprint = await this.service.Details(id);
  }

}
