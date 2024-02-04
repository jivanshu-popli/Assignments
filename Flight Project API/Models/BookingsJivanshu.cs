using System;
using System.Collections.Generic;

namespace flightapi.Models;

public partial class BookingsJivanshu
{
    public int BookingId { get; set; }

    public int? FlightId { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? BookingDate { get; set; }

    public int? NoOfPassengers { get; set; }

    public decimal? TotalCost { get; set; }

    public virtual CustomersJivanshu? Customer { get; set; }

    public virtual FlightsJivanshu? Flight { get; set; }
}
