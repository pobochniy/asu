import { Component, OnInit, Input } from '@angular/core';
import { IssueTypeEnum } from '../../enums/issue-type.enum';

@Component({
  selector: 'shared-enums-icon-type',
  templateUrl: './enums-icon-type.component.html',
  styleUrls: ['./enums-icon-type.component.css']
})
export class EnumsIconTypeComponent implements OnInit {

  @Input('type') type: IssueTypeEnum;
  public src: string;
  public color: string;
  public tooltipTxt: string;

  constructor() { }

  ngOnInit(): void {
    switch (this.type) {
      case IssueTypeEnum.story:
        this.src = 'bookmark';
        this.color = 'green';
        this.tooltipTxt = 'Story';
        break;
      case IssueTypeEnum.task:
        this.src = 'check-square';
        this.color = 'blue';
        this.tooltipTxt = 'Task';
        break;
      case IssueTypeEnum.bug:
        this.src = 'bug';
        this.color = 'red';
        this.tooltipTxt = 'Bug';
        break;
      case IssueTypeEnum.knowledge:
        this.src = 'book';
        this.color = 'brown';
        this.tooltipTxt = 'Knowledge base';
        break;
      case IssueTypeEnum.meeting:
        this.src = 'handshake';
        this.color = 'orange';
        this.tooltipTxt = 'Meeting';
        break;
    }
  }

}
