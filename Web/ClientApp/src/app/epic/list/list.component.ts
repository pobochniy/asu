import { Component, OnInit } from '@angular/core';
import { EpicApiService } from '../../shared/api/epic-api.service';
import { EpicModel } from '../../shared/models/epic.model';
import { Router } from '@angular/router';
import { UserProfileModel } from '../../shared/models/user-profile.model';
import { UsersApiService } from '../../shared/api/users-api.service';
import { DatePipe } from '@angular/common';
import { IssuePriorityEnum } from '../../shared/enums/issue-priority.enum';

@Component({
  selector: 'list-epic',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css'],
  providers: [EpicApiService, UsersApiService, DatePipe]
})
export class ListComponent implements OnInit {

  public dataSource: EpicModel[];
  public profiles: UserProfileModel[];


  constructor(private service: EpicApiService, private router: Router
    , private userApiService: UsersApiService, public datepipe: DatePipe) { }

  async ngOnInit() {

    this.dataSource = await this.service.GetList();

    this.profiles = await this.userApiService.GetProfiles();

  }

  async Delete(id: number) {

    await this.service.Delete(id);

    this.dataSource = await this.service.GetList();
  }
  async Details(id: number) {

    await this.service.Details(id);

  }
  GetPriority(id: number) {
    const priority = IssuePriorityEnum[id];
    if (priority) return priority;

    return id;
  }

  GetLogin(id: string) {
    if (this.profiles && this.profiles.length) {
      const user = this.profiles.find(x => x.id == id);
      if (user) return user.login;
    }

    return id;
  }
}
