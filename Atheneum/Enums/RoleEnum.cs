namespace Atheneum.Enums
{
    public enum RoleEnum
    {
        none,
        roleManagement,

        issueRead = 10,
        issueCreate,
        issueUpdate,
        issueDelete,

        epicCrud = 20,
        epicRead,

        sprintCrud = 30,
        sprintRead
    }
}
