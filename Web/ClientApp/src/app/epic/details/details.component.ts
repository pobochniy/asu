import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EpicApiService } from '../../shared/api/epic-api.service';
import { UsersApiService } from '../../shared/api/users-api.service';
import { IssuePriorityEnum } from '../../shared/enums/issue-priority.enum';
import { epicFormModel } from '../../shared/form-models/epic-form.model';
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

  public epicForm = epicFormModel;
  public profiles: UserProfileModel[];
  public issueTypes: { id: number; name: string }[] = [];
  public issueStatus: { id: number; name: string }[] = [];
  public issuePriority: { id: number; name: string } [] = [];

  constructor(private service: EpicApiService
    , private userApiService: UsersApiService
    , private route: ActivatedRoute
    , private router: Router
    , public datepipe: DatePipe
  ) { }

  async ngOnInit() {

    const id = +this.route.snapshot.paramMap.get('id');

    const epic = await this.service.Details(id);

    const dueDate = this.datepipe.transform(epic.dueDate, 'yyyy-MM-dd')

    this.epicForm.setValue({ id: epic.id, reporter: epic.reporter, name: epic.name, priorityEnum: epic.priorityEnum, description: epic.description, dueDate: dueDate });

    this.profiles = await this.userApiService.GetProfiles();

    for (var n in IssuePriorityEnum) {
      if (typeof IssuePriorityEnum[n] === 'number') {
        this.issuePriority.push({ id: <any>IssuePriorityEnum[n], name: n });
      }
    }
  }

  async onSubmit() {
    for (let item in this.epicForm.controls) {
      this.epicForm.controls[item].markAsDirty();
    }
    
    try {
      if (this.epicForm.valid) {
        await this.service.Update(this.epicForm);
        this.router.navigateByUrl('/epic/list');
      }
    }
    catch{
      alert('Возникли непредвиденные ошибки. Попробуйте ввести другие значения или сообщите программисту');
    }
  }
}

