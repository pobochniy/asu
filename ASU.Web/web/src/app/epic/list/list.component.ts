import {DatePipe} from '@angular/common';
import {Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';
import {EpicApiService} from '../../shared/api/epic-api.service';
import {EpicModel} from '../../shared/models/epic.model';
import {UserProfileModel} from '../../shared/models/user-profile.model';
import {IssuePriorityEnum} from '../../shared/enums/issue-priority.enum';
import {UserRoleEnum} from '../../shared/enums/user-role.enum';
import {UserService} from '../../shared/core/user.service';

@Component({
  selector: 'list-epic',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css'],
  providers: [EpicApiService]
})
export class ListComponent implements OnInit {

  public dataSource?: EpicModel[];
  public profiles?: UserProfileModel[];
  public roles = UserRoleEnum;


  constructor(private service: EpicApiService
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

  async Details(id: number) {
    await this.service.Details(id);
  }

  GetPriority(id: number) {
    const priority = IssuePriorityEnum[id];
    if (priority) return priority;

    return id;
  }

}
