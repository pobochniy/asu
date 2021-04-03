import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { sprintFormModel } from '../../shared/form-models/sprint-form.model';
import { DashboardModel } from '../../shared/models/dashboard.model';
import { SprintApiService } from '../../shared/api/sprint-api.service';

@Component({
  selector: 'sprint-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css'],
  providers: [SprintApiService]
})
export class EditComponent implements OnInit {

  public model: DashboardModel;
  public sprintForm = sprintFormModel;

  constructor(private service: SprintApiService
    , private router: Router
    , private route: ActivatedRoute
    , private cdRef: ChangeDetectorRef
  ) { }

  async ngOnInit() {
    debugger
    const id = +this.route.snapshot.paramMap.get('id');
    debugger
    const sprint = await this.service.Details(id);

    this.cdRef.detectChanges();

    this.sprintForm.setValue({
      id: sprint.id,
      startDate: sprint.startDate,
      finishDate: sprint.finishDate,
      isEnded: sprint.isEnded
    });
    
  }

  async onSubmit() {
    for (let item in this.sprintForm.controls) {
      this.sprintForm.controls[item].markAsDirty();
    }

    try {
      //if (this.issueForm.valid) {
      //  if (this.issueForm.value['id'] || 0 > 0) {
      //    await this.service.Update(this.issueForm);
      //  }
      //  else {
      //    this.storageSave();
      //    await this.service.Create(this.issueForm);
      //  }

      //  this.router.navigateByUrl('/issue/list');
      //}
    }
    catch {
      alert('Возникли непредвиденные ошибки. Попробуйте ввести другие значения или сообщите программисту');
    }
  }

}
