using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace flightproject2.Models;

public partial class CustomersJivanshu
{
    public int CustomerId { get; set; }

    [Display(Name = "Name")]
    [Required(ErrorMessage = "*")]
    public string? CustomerName { get; set; }

    [Display(Name = "Your City")]
    [Required(ErrorMessage = "*")]
    public string? CustomerLocation { get; set; }

    [Display(Name = "Your Email Address")]
    [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address")]
    [Required(ErrorMessage = "*")]
    public string? EmailAddress { get; set; }
    [Display(Name = "Type Your Password")]
    [Required(ErrorMessage = "*")]
    public string? Password { get; set; }
    
    [NotMapped]
    [Display(Name = "Confirm Your Password")]
    [Required(ErrorMessage = "*")]
    [Compare("Password",ErrorMessage ="Passwords do not match")]
    public string? ConfirmPassword{get;set;}

    public virtual ICollection<BookingsJivanshu> BookingsJivanshus { get; set; } = new List<BookingsJivanshu>();

}
