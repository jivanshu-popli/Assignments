using System;
using System.Collections.Generic;

namespace flightapi.Models;

public partial class FlightsJivanshu
{
    public int FlightId { get; set; }

    public string? Airline { get; set; }

    public string? SourceCity { get; set; }

    public string? DestinationCity { get; set; }

    public TimeOnly? DepartureTime { get; set; }

    public TimeOnly? ArrivalTime { get; set; }

    public decimal? Price { get; set; }

    public virtual ICollection<BookingsJivanshu> BookingsJivanshus { get; set; } = new List<BookingsJivanshu>();
}
