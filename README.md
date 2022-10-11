# ASU project

Run `docker-compose up -d` to init databases

## Migrations

Add migration:

Run `add-migration [NAME] -Project Atheneum` for win + Visual Studio

Run `dotnet ef --startup-project ../Api/Api.csproj migrations add Init --context ApplicationContext -o MigrationsDeployment ` for mac/linux from /Atheneum folder

if has error 'No such file or directory' run `dotnet new tool-manifest` then `dotnet tool install dotnet-ef`

___
Update Database:

Run `update-database -Project Atheneum` for windows

Run `dotnet ef --startup-project ../Api/Api.csproj database update --context DeploymentContext
` from /asu/Atheneum for mac

___
Other commands:

`remove-migration`, `update-database NAME_OF_MIGRATION`, `script-migration`

## Koko