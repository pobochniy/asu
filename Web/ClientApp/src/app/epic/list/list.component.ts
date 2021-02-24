import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EpicApiService } from '../../shared/api/epic-api.service';
import { EpicModel } from '../../shared/models/epic.model';
import { UserProfileModel } from '../../shared/models/user-profile.model';

@Component({
  selector: 'list-epic',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css'],
  providers: [EpicApiService, DatePipe]
})
export class ListComponent implements OnInit {

  public dataSource: EpicModel[];
  public profiles: UserProfileModel[];


  constructor(private service: EpicApiService
    , private router: Router
    , public datepipe: DatePipe) { }

  async ngOnInit() {
    this.dataSource = await this.service.GetList();
  }

  async Delete(id: number) {

    await this.service.Delete(id);

    this.dataSource = await this.service.GetList();
  }

  async Details(id: number) {

    await this.service.Details(id);

  }
}
