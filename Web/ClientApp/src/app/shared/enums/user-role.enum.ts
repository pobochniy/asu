export enum UserRoleEnum {
  none,
  roleManagement,

  issueRead = 10,
  issueCreate,
  issueUpdate,
  issueDelete,

  epicCrud = 20,

  sprintCrud = 30
}
