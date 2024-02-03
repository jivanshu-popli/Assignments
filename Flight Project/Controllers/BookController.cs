using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using flightproject2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.IO.Compression;

namespace flightproject2.Controllers;

public class BookController : Controller
{
    private readonly ILogger<BookController> _logger;
    private readonly ISession session;
    public static Ace52024Context db;

    public BookController(ILogger<BookController> logger, Ace52024Context _db, IHttpContextAccessor httpContextAccessor)
    {
        _logger = logger;
        db = _db;
        session = httpContextAccessor.HttpContext.Session;
    }
    public IActionResult Search()
    {   
        var sourceC = db.FlightsJivanshus.Select(x=>x.SourceCity).Distinct().ToList();
        ViewBag.SourceCitys =new SelectList(sourceC);
        var destC = db.FlightsJivanshus.Select(x=>x.DestinationCity).Distinct().ToList();
        ViewBag.dest =new SelectList(destC);
        return View();
    }

    [HttpPost]
    public IActionResult Search(FlightsJivanshu j){
        string s = j.SourceCity;
        string d = j.DestinationCity;
        return RedirectToAction("AllFlights", new{SourceCity=s, DestinationCity=d});
    }

    public IActionResult AllFlights(string SourceCity, string DestinationCity)
    {   
        List<FlightsJivanshu> ls = db.FlightsJivanshus.Select(x=>x).Where(x=>x.SourceCity == SourceCity && x.DestinationCity==DestinationCity).ToList();
        ViewBag.EmailAddress=HttpContext.Session.GetString("email");
        if(ViewBag.EmailAddress!=null){
            return View(ls);
        }
        else{
            return RedirectToAction("Login", "Login");
        }
    }
    public IActionResult SeeBookings()
    {   
        return View();
    }

    public IActionResult BookFlight()
    {   
        return View();
    }
    
    [HttpPost]

    public IActionResult BookFlight(BookingsJivanshu j, int id)
    {   
        HttpContext.Session.SetInt32("Flightid", id);
        FlightsJivanshu f = db.FlightsJivanshus.Where(x=>x.FlightId==id).SingleOrDefault();
        j.FlightId = id;
        int customerId = (int)HttpContext.Session.GetInt32("Customerid");
        j.CustomerId = customerId;
        j.BookingDate = DateTime.Now;
        j.TotalCost = f.Price * j.NoOfPassengers;
        db.BookingsJivanshus.Add(j);
        db.SaveChanges();
        return RedirectToAction("YourBookings", j);
    }
    public IActionResult YourBookings(BookingsJivanshu j)
    {   
        return View(db.BookingsJivanshus.Where(x=>x.BookingId==j.BookingId).ToList());
    }
    public IActionResult AllBookings()
    {   
        ViewBag.EmailAddress=HttpContext.Session.GetString("email");
        if(ViewBag.EmailAddress!=null){
            int cust = (int)HttpContext.Session.GetInt32("Customerid");
            return View(db.BookingsJivanshus.Where(x=>x.CustomerId==cust).Include(y=>y.Customer).Include(z=>z.Flight).ToList());
        }
        else{
            return RedirectToAction("Login", "Login");
        }
    }

    public IActionResult Details(int id){
        return View(db.BookingsJivanshus.Where(x=>x.BookingId == id).Include(y=>y.Customer).Include(z=>z.Flight).SingleOrDefault());
    }

    public ActionResult Delete(int id){
            BookingsJivanshu j = db.BookingsJivanshus.Where(x=>x.BookingId == id).SingleOrDefault();
            return View(j);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id){
            BookingsJivanshu j = db.BookingsJivanshus.Where(x=>x.BookingId == id).SingleOrDefault();
            db.BookingsJivanshus.Remove(j);
            db.SaveChanges();
            return RedirectToAction("AllBookings");
        }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
