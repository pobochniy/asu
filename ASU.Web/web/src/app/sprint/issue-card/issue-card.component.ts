import { Component, Input } from '@angular/core';
import { IssueModel } from '../../shared/models/issue.model';

@Component({
  selector: 'issue-card',
  templateUrl: './issue-card.component.html',
  styleUrls: ['./issue-card.component.css']
})
export class IssueCardComponent{
  @Input('issue') issue!: IssueModel;

  constructor() { }
}
