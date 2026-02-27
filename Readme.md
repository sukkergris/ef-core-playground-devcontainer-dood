# Info

## Container selection

https://mcr.microsoft.com/artifact/mar/dotnet/sdk/

## Create XUnit test project

> `dotnet new xunit -n YourProjectName.Tests`

## Add references

> `dotnet reference add Base/Base.csproj --project Agency/Agency.csproj`
> `dotnet reference add Base/Base.csproj --project Agency.Test/Agency.Test.csproj`

## Migrations

### Add

No database access is required when adding.

```sh
dotnet ef migrations add "NAME-MIGRATION" \
--context DataContext \
--startup-project ../your-project-containing-the-app-settings
```

Eg.:
```sh
dotnet ef migrations add "Initial" \
--context AgencyDbContext \
--startup-project Agency
```

### Remove

If not added to the db:
`dotnet ef migrations remove --context AgencyDbContext --startup-project Agency --force`
If applied to the db:
`dotnet ef migrations remove --context AgencyDbContext --startup-project Agency`

## Devcontainer Docker (DooD)

See [Devcontainer-DooD.md](Devcontainer-DooD.md) for the Docker-out-of-Docker setup used in this workspace.
