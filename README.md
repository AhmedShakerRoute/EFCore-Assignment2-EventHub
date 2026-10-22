# EF Core - Assignment 2: EventHub (Model Answer)

Session 2: Fluent API, separate configuration classes, relationships **1-1** and **1-M** (plus Session 1: conventions, migrations, Data Annotations).

Instructor copy. The assignment statement is in [`Assignment/`](Assignment).

**One technique per entity (never mixed on the same entity)**

| Entity | Technique |
|---|---|
| `Organizer` | Data Annotations |
| `Attendee` | Data Annotations |
| `OrganizerProfile` | Fluent API inside `OnModelCreating` |
| `Event` | Separate configuration class (`EventConfiguration`) |
| `Badge` | Separate configuration class (`BadgeConfiguration`) |

**Relationships**
- Organizer 1-1 OrganizerProfile (shared primary key: the profile cannot exist without its organizer).
- Organizer 1-M Event.
- Attendee 1-1 Badge (a badge belongs to one attendee; an attendee has at most one badge; badge number is unique).
- The attendee's home address is stored as plain columns (street, city, country, postal code).

## How to run

Requirements: .NET 9 SDK, SQL Server (the connection string in the DbContext uses `Server=.` with Windows authentication; change it if yours is different).

```bash
cd Solution
dotnet restore
dotnet ef migrations add InitialCreate
dotnet run
```

`dotnet ef` comes from `dotnet tool install --global dotnet-ef`.

