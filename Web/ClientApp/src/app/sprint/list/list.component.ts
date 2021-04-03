import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SprintApiService } from '../../shared/api/sprint-api.service';
import { DashboardModel } from '../../shared/models/dashboard.model';

@Component({
  selector: 'list-sprint',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css'],
  providers: [SprintApiService]
})
export class ListComponent implements OnInit {
  public dataSource: DashboardModel[];

  constructor(private service: SprintApiService
    , private router: Router) { }

  async ngOnInit() {
    this.dataSource = await this.service.GetList();
  }

}
