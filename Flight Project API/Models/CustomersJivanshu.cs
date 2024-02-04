using System;
using System.Collections.Generic;

namespace flightapi.Models;

public partial class CustomersJivanshu
{
    public int CustomerId { get; set; }

    public string? CustomerName { get; set; }

    public string? CustomerLocation { get; set; }

    public string? Password { get; set; }

    public string? EmailAddress { get; set; }

    public virtual ICollection<BookingsJivanshu> BookingsJivanshus { get; set; } = new List<BookingsJivanshu>();
}
