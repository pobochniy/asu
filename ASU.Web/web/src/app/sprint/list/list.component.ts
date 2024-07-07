import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { SprintApiService } from '../../shared/api/sprint-api.service';
import { UserService } from '../../shared/core/user.service';
import { UserRoleEnum } from '../../shared/enums/user-role.enum';
import { DashboardModel } from '../../shared/models/dashboard.model';

@Component({
  selector: 'list-sprint',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css'],
  providers: [SprintApiService]
})
export class ListComponent implements OnInit {
  public dataSource?: DashboardModel[];

  public roles = UserRoleEnum;

  constructor(private service: SprintApiService
    , private router: Router
    , public datepipe: DatePipe
    , public userService: UserService
  ) { }

  async ngOnInit() {
    this.dataSource = await this.service.GetList();
  }

  async Delete(id: number) {

    await this.service.Delete(id);

    this.dataSource = await this.service.GetList();
  }

}
