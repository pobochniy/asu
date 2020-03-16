import { Component, OnInit, ViewEncapsulation} from '@angular/core';
import { Router } from '@angular/router';
import { EpicApiService } from '../../shared/api/epic-api.service';
import { epicFormModel } from '../../shared/form-models/epic-form.model';
import { DomSanitizer, SafeStyle } from '@angular/platform-browser';
import { UsersApiService } from '../../shared/api/users-api.service';
import { UserProfileModel } from '../../shared/models/user-profile.model';
import { IssuePriorityEnum } from '../../shared/enums/issue-priority.enum';

@Component({
  selector: 'add-epic',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css'],
  providers: [EpicApiService, UsersApiService]
})
export class AddComponent implements OnInit {

  public epicForm = epicFormModel;
  public profiles: UserProfileModel[];
  public issueTypes: { id: number; name: string }[] = [];
  public issueStatus: { id: number; name: string }[] = [];
  public issuePriority: { id: number; name: string } [] = [];

  constructor(private service: EpicApiService
    , private userApiService: UsersApiService
    , private router: Router
  ) { }

  async ngOnInit() {
    this.profiles = await this.userApiService.GetProfiles();
    var reporterCtrl = this.epicForm.controls['reporter'];


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
        let issueId = await this.service.Create(this.epicForm);
        this.router.navigateByUrl('/epic/list');
      }
    }
    catch{
      alert('Возникли непредвиденные ошибки. Попробуйте ввести другие значения или сообщите программисту');
    }
  }
}

