# EventEase

A Blazor WebAssembly app for managing events, registrations and attendance. Built with .NET 8.

## Features

| Area | What it does | Where |
| --- | --- | --- |
| Event Card component | Reusable card with `[Parameter]` data and two-way bound edit fields (`@bind`, `@bind:event`, `@bind:after`) | `Components/EventCard.razor` |
| Event list | Searchable board of events, two columns from `lg` up | `Pages/Home.razor` |
| Routing | `/`, `/events`, `/events/{id:int}`, `/register/{eventId:int}`, `/confirmation/{registrationId:int}`, `/attendance` | `Pages/` |
| Registration form | `EditForm` + `DataAnnotationsValidator`, per-field `ValidationMessage`, `ValidationSummary` | `Pages/Register.razor` |
| Session state | Scoped `SessionService` holds the signed-in attendee; the navbar subscribes to its `OnChange` event | `Services/SessionService.cs`, `Layout/NavMenu.razor` |
| Attendance tracker | Per-event list of registrants with check-in toggles and a live count | `Pages/Attendance.razor` |
| Not found handling | Unknown event IDs and unmatched routes show a friendly message and a way back | `Pages/EventDetails.razor`, `App.razor` |

## Run it

Requires the .NET 8 SDK.

```bash
dotnet run --project EventEase
```

Then open the URL printed in the console (the profile uses `http://localhost:5xxx`).

To watch files and reload on change:

```bash
dotnet watch --project EventEase run
```

## Project layout

```
EventEase/
├── Components/EventCard.razor     # reusable event card, two-way bound
├── Layout/NavMenu.razor           # navigation + signed-in attendee
├── Models/EventItem.cs            # event with validation attributes
├── Models/Registration.cs         # registration request + saved registration
├── Pages/Home.razor               # event list and search
├── Pages/EventDetails.razor       # /events/{id}
├── Pages/Register.razor           # validated registration form
├── Pages/Confirmation.razor       # post-registration confirmation
├── Pages/Attendance.razor         # attendance tracker
├── Services/EventService.cs       # in-memory events and registrations
└── Services/SessionService.cs     # signed-in attendee for the session
```

## Notes

- Data is held in memory, so a full page reload resets the catalogue and registrations. Swapping
  `EventService` for an HTTP client would be the next step.
- Validation is done with DataAnnotations so the same rules could be enforced server-side later.
