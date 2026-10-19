using EventEase.Models;

namespace EventEase.Services;

/// <summary>
/// Holds the signed-in attendee for the life of the app, so the navbar and any page can read
/// the same session without passing parameters down the component tree.
/// </summary>
public class SessionService
{
    public Registration? CurrentUser { get; private set; }

    public bool IsSignedIn => CurrentUser is not null;

    /// <summary>Raised whenever the session changes, so subscribed components can re-render.</summary>
    public event Action? OnChange;

    public void SignIn(Registration registration)
    {
        CurrentUser = registration;
        NotifyChanged();
    }

    public void SignOut()
    {
        CurrentUser = null;
        NotifyChanged();
    }

    private void NotifyChanged() => OnChange?.Invoke();
}
