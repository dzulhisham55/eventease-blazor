using EventEase.Models;

namespace EventEase.Services;

/// <summary>
/// In-memory event catalogue and registration store. A real deployment would call an API;
/// the Blazor app only needs the data to survive navigation, which a singleton provides.
/// </summary>
public class EventService
{
    private readonly List<EventItem> events = new()
    {
        new EventItem
        {
            Id = 1,
            Name = "Design Systems Summit",
            Date = DateTime.Today.AddDays(12),
            Location = "Sunway Convention Centre",
            Capacity = 120,
            Description = "Two days of talks on building and maintaining design systems at scale."
        },
        new EventItem
        {
            Id = 2,
            Name = "Blazor Bootcamp",
            Date = DateTime.Today.AddDays(21),
            Location = "Online",
            Capacity = 30,
            Description = "Hands-on workshop: components, routing, forms and state in Blazor WebAssembly."
        },
        new EventItem
        {
            Id = 3,
            Name = "Founders Breakfast",
            Date = DateTime.Today.AddDays(5),
            Location = "Bangsar South",
            Capacity = 25,
            Description = "Informal round table for early-stage founders and their first hires."
        },
        new EventItem
        {
            Id = 4,
            Name = "Accessibility Clinic",
            Date = DateTime.Today.AddDays(34),
            Location = "PJ Community Hall",
            Capacity = 60,
            Description = "Bring a page or flow and leave with an accessibility review and fixes."
        }
    };

    private readonly List<Registration> registrations = new();
    private int nextRegistrationId = 1;

    public IReadOnlyList<EventItem> GetEvents() => events;

    public EventItem? GetEvent(int id) => events.FirstOrDefault(e => e.Id == id);

    public int RegisteredCount(int eventId) => registrations.Count(r => r.EventId == eventId);

    public int CheckedInCount(int eventId) => registrations.Count(r => r.EventId == eventId && r.CheckedIn);

    public int SeatsLeft(EventItem eventItem) => Math.Max(0, eventItem.Capacity - RegisteredCount(eventItem.Id));

    public IReadOnlyList<Registration> GetRegistrations(int eventId) =>
        registrations.Where(r => r.EventId == eventId).OrderBy(r => r.FullName).ToList();

    public Registration? GetRegistration(int id) => registrations.FirstOrDefault(r => r.Id == id);

    public Registration Register(int eventId, string fullName, string email)
    {
        var registration = new Registration
        {
            Id = nextRegistrationId++,
            EventId = eventId,
            FullName = fullName.Trim(),
            Email = email.Trim()
        };

        registrations.Add(registration);
        return registration;
    }
}
