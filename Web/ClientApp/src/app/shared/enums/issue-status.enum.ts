export enum IssueStatusEnum {
  todo,
  inwork,
  done,
  testing,
  resolved
}

export function GetIssueStatus(id: number) {
  switch (id) {
    case 0: return "To do";
      break;
    case 1: return "In work";
      break;
    case 2: return "Done";
      break;
    case 3: return "Testing";
      break;
    case 4: return "Resolved";
      break;
  }
}
