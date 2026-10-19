using System.ComponentModel.DataAnnotations;

namespace EventEase.Models;

/// <summary>An event listed on the EventEase board.</summary>
public class EventItem
{
    public int Id { get; set; }

    [Required(ErrorMessage = "An event needs a name.")]
    [StringLength(60, MinimumLength = 3, ErrorMessage = "Event names are 3 to 60 characters.")]
    public string Name { get; set; } = string.Empty;

    public DateTime Date { get; set; } = DateTime.Today;

    [Required(ErrorMessage = "An event needs a location.")]
    public string Location { get; set; } = string.Empty;

    [Range(1, 5000, ErrorMessage = "Capacity must be between 1 and 5000.")]
    public int Capacity { get; set; } = 50;

    public string Description { get; set; } = string.Empty;
}
