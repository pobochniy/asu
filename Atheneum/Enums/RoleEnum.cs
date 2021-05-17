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

        sprintCrud = 30
    }
}
