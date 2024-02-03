using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace flightproject2.Model;

public partial class AdminFlightsJivanshu
{
    public int FlightId { get; set; }

    public string Airline { get; set; }

    [Display(Name = "Source")]
    [Required(ErrorMessage = "*")]
    public string SourceCity { get; set; }
    
    [Display(Name = "Destination")]
    [Required(ErrorMessage = "*")]
    public string DestinationCity { get; set; }

    public TimeOnly DepartureTime { get; set; }

    public TimeOnly ArrivalTime { get; set; }

    public decimal Price { get; set; }

}
