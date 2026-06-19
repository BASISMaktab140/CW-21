## Database Migrations

### Migration Commands

* `--project CW.21.Infrastructure`
* `--startup-project CW.21.WebApi`
* `--output-dir Persistence/Migrations`

### Add a New Migration

From the solution root folder:

```bash
dotnet ef migrations add "SampleMigration" \
--project CW.21.Infrastructure \
--startup-project CW.21.WebApi \
--output-dir Migrations
```

### Update Database

From the solution root folder:

```bash
dotnet ef database update \
--project CW.21.Infrastructure \
--startup-project CW.21.WebApi
```

### Remove Last Migration

```bash
dotnet ef migrations remove \
--project CW.21.Infrastructure \
--startup-project CW.21.WebApi
```

---

## Build & Run

Restore packages:

```bash
dotnet restore
```

Build solution:

```bash
dotnet build
```

Run Web API:

```bash
dotnet run --project CW.21.WebApi
```

---