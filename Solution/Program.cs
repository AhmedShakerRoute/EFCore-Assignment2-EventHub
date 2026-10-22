using EventHub;
using EventHub.Models;
using Microsoft.EntityFrameworkCore;

using EventHubDbContext db = new();

await db.Database.MigrateAsync();
Console.WriteLine("EventHub database is ready.");

if (!await db.Organizers.AnyAsync())
{
    var organizer = new Organizer
    {
        Name = "Mona Adel",
        CompanyName = "TechTalks Egypt",
        IsVerified = true,
        Profile = new OrganizerProfile
        {
            Biography = "We organize tech conferences across Egypt.",
            WebsiteUrl = "https://techtalks.example.com",
            LogoUrl = "https://techtalks.example.com/logo.png"
        }
    };
    organizer.Events.Add(new Event
    {
        Title = "Cairo .NET Conference",
        Description = "A full-day conference about modern .NET development.",
        StartDate = new DateTime(2026, 12, 5, 9, 0, 0),
        EndDate = new DateTime(2026, 12, 5, 17, 0, 0),
        MaxAttendees = 300
    });
    db.Organizers.Add(organizer);

    db.Attendees.Add(new Attendee
    {
        FullName = "Ahmed Hassan",
        Email = "ahmed.hassan@example.com",
        Street = "12 Tahrir Square",
        City = "Cairo",
        Country = "Egypt",
        PostalCode = "11511",
        Badge = new Badge
        {
            BadgeNumber = "BDG-0001",
            IssuedDate = DateTime.Today,
            Tier = BadgeTier.VIP
        }
    });

    await db.SaveChangesAsync();
}

Console.WriteLine($"Organizers: {await db.Organizers.CountAsync()} | Profiles: {await db.OrganizerProfiles.CountAsync()} | " +
                  $"Events: {await db.Events.CountAsync()} | Attendees: {await db.Attendees.CountAsync()} | Badges: {await db.Badges.CountAsync()}");
