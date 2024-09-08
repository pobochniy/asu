namespace Atheneum.Enums
{
    public enum RoleEnum
    {
        none,
        roleManagement,

        issueRead = 10,
        issueCrud,

        epicCrud = 20,
        epicRead,

        sprintCrud = 30,
        sprintRead,

        hourlyPayCrud = 40,
        hourlyPayRead,
        
        finPeriodEdit = 50,
        finPeriodRead,
    }
}
