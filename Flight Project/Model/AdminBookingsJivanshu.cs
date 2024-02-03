using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace flightproject2.Model;

public partial class AdminBookingsJivanshu
{
    public int BookingId { get; set; }

    public int FlightId { get; set; }

    public int CustomerId { get; set; }

    [Display(Name = "Date and Time of Booking")]
    public DateTime? BookingDate { get; set; }

    [Display(Name = "Passengers")]
    [Required(ErrorMessage = "*")]
    [Range(minimum:1,maximum:24,ErrorMessage ="One person can book tickets between 1 and 24")]
    public int NoOfPassengers { get; set; }

    [Display(Name = "Final Amount")]
    public decimal TotalCost { get; set; }


}
