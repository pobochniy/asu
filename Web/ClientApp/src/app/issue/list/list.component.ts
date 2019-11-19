import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IssueApiService } from '../../shared/api/issue-api.service';
import { IssueModel } from '../../shared/models/issue.model';

@Component({
  selector: 'list-issue',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css'],
  providers: [IssueApiService]
})
export class ListComponent implements OnInit{

  public dataSource: IssueModel[];

  constructor(private service: IssueApiService
    , private router: Router
  ) { }

  async ngOnInit() {
    this.dataSource = await this.service.GetList();
  }
}
