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
    case 1: return "In work";
    case 2: return "Done";
    case 3: return "Testing";
    case 4: return "Resolved";
    default: return "To do";
  }
}
