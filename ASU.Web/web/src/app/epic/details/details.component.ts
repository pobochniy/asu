import { DatePipe } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EpicApiService } from '../../shared/api/epic-api.service';
import { UsersApiService } from '../../shared/api/users-api.service';
import { IssuePriorityEnum } from '../../shared/enums/issue-priority.enum';
import { EpicModel } from '../../shared/models/epic.model';
import { UserProfileModel } from '../../shared/models/user-profile.model';
import { ListComponent } from '../list/list.component';
import { IssueApiService } from '../../shared/api/issue-api.service';
import { IssueModel } from '../../shared/models/issue.model';
import { IssueStatusEnum } from '../../shared/enums/issue-status.enum';
import { UserService } from '../../shared/core/user.service';
import { UserRoleEnum } from '../../shared/enums/user-role.enum';
import { TimeTrackingModel } from '../../shared/models/time-tracking.model';
import {TimeTrackingPopupComponent} from "../../shared/time-tracking-popup/time-tracking-popup.component";


@Component({
  selector: 'details-epic',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css'],
  providers: [EpicApiService, IssueApiService, ListComponent]
})
export class DetailsComponent implements OnInit {

  @ViewChild(TimeTrackingPopupComponent) timePopup!: TimeTrackingPopupComponent;

  public epic: EpicModel = new EpicModel();
  public profiles: UserProfileModel[] = [];
  public issues: IssueModel[] = [];
  public issueTypes: { id: number; name: string }[] = [];
  public issueStatus: { id: number; name: string }[] = [];
  public issuePriority: { id: number; name: string }[] = [];
  public roles = UserRoleEnum;

  constructor(private service: EpicApiService
    , private userApiService: UsersApiService
    , private issueApiService: IssueApiService
    , private route: ActivatedRoute
    , private router: Router
    , public datepipe: DatePipe
    , public userService: UserService
  ) {
  }

  async ngOnInit() {

    const id = +(this.route.snapshot.paramMap.get('id') || 0);

    this.epic = await this.service.Details(id);

    this.issues = await this.issueApiService.GetList(this.epic.id) || [];

    for (var n in IssuePriorityEnum) {
      if (typeof IssuePriorityEnum[n] === 'number') {
        this.issuePriority.push({ id: <any>IssuePriorityEnum[n], name: n });
      }
    }
  }

  GetPriority(id: number) {
    const priority = IssuePriorityEnum[id];
    if (priority) return priority;

    return id;
  }

  GetStatus(id: number) {
    const priority = IssueStatusEnum[id];
    if (priority) return priority;

    return id;
  }

  public showTimeTrack() {
    const model = new TimeTrackingModel();
    model.epicId = this.epic.id;
    model.issueEpicName = this.epic.name!;
    this.timePopup.show(model).subscribe((x: any) => {
    });


  }

}

