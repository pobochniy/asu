import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EpicApiService } from '../../shared/api/epic-api.service';
import { UsersApiService } from '../../shared/api/users-api.service';
import { IssuePriorityEnum } from '../../shared/enums/issue-priority.enum';
import { UserProfileModel } from '../../shared/models/user-profile.model';
import { ListComponent } from '../list/list.component';
import { EpicModel } from '../../shared/models/epic.model';
import { DatePipe } from '@angular/common';


@Component({
  selector: 'details-epic',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css'],
  providers: [EpicApiService, ListComponent, DatePipe]
})
export class DetailsComponent implements OnInit {
  public epic: EpicModel;
  public profiles: UserProfileModel[];
  public issueTypes: { id: number; name: string }[] = [];
  public issueStatus: { id: number; name: string }[] = [];
  public issuePriority: { id: number; name: string } [] = [];

  constructor(private service: EpicApiService
    , private userApiService: UsersApiService
    , private route: ActivatedRoute
    , private router: Router
    , public datepipe: DatePipe
    , private cdRef: ChangeDetectorRef
  ) {
  }

  async ngOnInit() {
    
    const id = +this.route.snapshot.paramMap.get('id');

    this.epic = await this.service.Details(id);
    for (var n in IssuePriorityEnum) {
      if (typeof IssuePriorityEnum[n] === 'number') {
        this.issuePriority.push({ id: <any>IssuePriorityEnum[n], name: n });
      }
    }
    this.cdRef.detectChanges();
  }

  GetPriority(id: number) {
    const priority = IssuePriorityEnum[id];
    if (priority) return priority;
    return id;
  }
}

