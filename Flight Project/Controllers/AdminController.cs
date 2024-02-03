using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using flightproject2.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
namespace flightproject2.Controllers{
    public class AdminController : Controller{
   
 
        public static List<AdminFlightsJivanshu> acc = new List<AdminFlightsJivanshu>();
       
        public async Task<ActionResult> RetrieveFlight(){
            if(HttpContext.Session.GetString("email") == null){
                return RedirectToAction("Login", "Login");
            }
            using (var client = new HttpClient()){
 
                //Passing service base url  
         //       client.BaseAddress = new Uri(Baseurl);
 
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
 
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("http://localhost:5159/api/Admin1");
 
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api  
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
 
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    acc = JsonConvert.DeserializeObject<List<AdminFlightsJivanshu>>(EmpResponse);
 
                }
                return RedirectToAction("Index", "Home");
            }
        }
        public async Task<IActionResult> AllFlights()
        {
            if(HttpContext.Session.GetString("email") == null){
                return RedirectToAction("Login", "Login");
            }
                using (var client = new HttpClient()){
 
                //Passing service base url  
         //       client.BaseAddress = new Uri(Baseurl);
 
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
 
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("http://localhost:5159/api/Admin1");
 
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api  
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
 
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    acc = JsonConvert.DeserializeObject<List<AdminFlightsJivanshu>>(EmpResponse);
 
                }
                //s= acc;
                //returning the employee list to view  
                return View(acc);
                }
           
        }

        public async Task<IActionResult> FlightDetails(int id)
        {
                List<AdminFlightsJivanshu> s = new List<AdminFlightsJivanshu>();
                AdminFlightsJivanshu j = new AdminFlightsJivanshu();
                using (var client = new HttpClient()){
                    using (var response = await client.GetAsync("http://localhost:5159/api/Admin1/"+id)){
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        j = JsonConvert.DeserializeObject<AdminFlightsJivanshu>(apiResponse);
                    }
                }
                s.Add(j);
                return View(s);
           
        }

        public IActionResult Home()
        {
            if(HttpContext.Session.GetString("email") == null){
                return RedirectToAction("Login", "Login");
            }
            return View();
        }
        public IActionResult AddFlight()
        {
            if(HttpContext.Session.GetString("email") == null){
                return RedirectToAction("Login", "Login");
            }
            var sourceC = acc.Select(x=>x.SourceCity).Distinct().ToList();
            ViewBag.SourceCitys =new SelectList(sourceC);
            var destC = acc.Select(x=>x.DestinationCity).Distinct().ToList();
            ViewBag.dest =new SelectList(destC);
            return View();
        }
 
        [HttpPost]
        public async Task<IActionResult> AddFlight(AdminFlightsJivanshu e)
        {
            
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(e),
              Encoding.UTF8, "application/json");
 
                using (var response = await httpClient.PostAsync("http://localhost:5159/api/Admin1", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    e = JsonConvert.DeserializeObject<AdminFlightsJivanshu>(apiResponse);
                }
            }
            return RedirectToAction("AllFlights");
        }

        [HttpGet]
        public async Task<ActionResult> UpdateFlight(int id)
        {
            AdminFlightsJivanshu emp = new AdminFlightsJivanshu();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5159/api/Admin1/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    emp = JsonConvert.DeserializeObject<AdminFlightsJivanshu>(apiResponse);
                }
            }
            return View(emp);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateFlight(AdminFlightsJivanshu e)
        {
            AdminFlightsJivanshu receivedemp = new AdminFlightsJivanshu();

            using (var httpClient = new HttpClient())
            {
                #region
                //var content = new MultipartFormDataContent();
                //content.Add(new StringContent(reservation.Empid.ToString()), "Empid");
                //content.Add(new StringContent(reservation.Name), "Name");
                //content.Add(new StringContent(reservation.Gender), "Gender");
                //content.Add(new StringContent(reservation.Newcity), "Newcity");
                //content.Add(new StringContent(reservation.Deptid.ToString()), "Deptid");
                #endregion
                int id = e.FlightId;
                StringContent content1 = new StringContent(JsonConvert.SerializeObject(e)
         , Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("http://localhost:5159/api/Admin1/" + id, content1))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    receivedemp = JsonConvert.DeserializeObject<AdminFlightsJivanshu>(apiResponse);
                }
            }
            return RedirectToAction("Home", "Admin");
        }

        public async Task<ActionResult> DeleteFlight(int id)
        {
            if(HttpContext.Session.GetString("email") == null){
                return RedirectToAction("Login", "Login");
            }
            TempData["Flightid"] = id;
            AdminFlightsJivanshu e = new AdminFlightsJivanshu();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5159/api/Admin1/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    e = JsonConvert.DeserializeObject<AdminFlightsJivanshu>(apiResponse);
                }
            }
            return View(e);
        }


        [HttpPost]
       // [ActionName("DeleteEmployee")]
        public async Task<ActionResult> DeleteFlight(AdminFlightsJivanshu e)
        {
            if(HttpContext.Session.GetString("email") == null){
                return RedirectToAction("Login", "Login");
            }
            int flightid = Convert.ToInt32(TempData["Flightid"]);
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:5159/api/Admin1/" + flightid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Home", "Admin");
        }



        public static List<AdminBookingsJivanshu> b = new List<AdminBookingsJivanshu>();
       
        public async Task<ActionResult> RetrieveBooking(){
            if(HttpContext.Session.GetString("email") == null){
                return RedirectToAction("Login", "Login");
            }
            using (var client = new HttpClient()){
 
                //Passing service base url  
         //       client.BaseAddress = new Uri(Baseurl);
 
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
 
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("http://localhost:5159/api/Admin2");
 
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api  
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
 
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    b = JsonConvert.DeserializeObject<List<AdminBookingsJivanshu>>(EmpResponse);
 
                }
                return RedirectToAction("Index", "Home");
            }
        }
        public async Task<IActionResult> AllBookings(){
            if(HttpContext.Session.GetString("email") == null){
                return RedirectToAction("Login", "Login");
            }
                using (var client = new HttpClient()){
 
                //Passing service base url  
         //       client.BaseAddress = new Uri(Baseurl);
 
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
 
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("http://localhost:5159/api/Admin2");
 
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api  
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
 
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    b = JsonConvert.DeserializeObject<List<AdminBookingsJivanshu>>(EmpResponse);
 
                }
                //s= acc;
                //returning the employee list to view  
                return View(b);
                }
           
        }


        public async Task<ActionResult> DeleteBooking(int id)
        {
            if(HttpContext.Session.GetString("email") == null){
                return RedirectToAction("Login", "Login");
            }
            TempData["bid"] = id;
            AdminBookingsJivanshu e = new AdminBookingsJivanshu();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5159/api/Admin2/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    e = JsonConvert.DeserializeObject<AdminBookingsJivanshu>(apiResponse);
                }
            }
            return View(e);
        }


        [HttpPost]
       // [ActionName("DeleteEmployee")]
        public async Task<ActionResult> DeleteBooking(AdminBookingsJivanshu e)
        {
            if(HttpContext.Session.GetString("email") == null){
                return RedirectToAction("Login", "Login");
            }
            int bid = Convert.ToInt32(TempData["bid"]);
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:5159/api/Admin2/" + bid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Home", "Admin");
        }



        public static List<AdminCustomersJivanshu> c = new List<AdminCustomersJivanshu>();
       
        public async Task<ActionResult> RetrieveCustomer(){
            if(HttpContext.Session.GetString("email") == null){
                return RedirectToAction("Login", "Login");
            }
            using (var client = new HttpClient()){
 
                //Passing service base url  
         //       client.BaseAddress = new Uri(Baseurl);
 
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
 
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("http://localhost:5159/api/Admin3");
 
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api  
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
 
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    c = JsonConvert.DeserializeObject<List<AdminCustomersJivanshu>>(EmpResponse);
 
                }
                return RedirectToAction("Search", "Book");
            }
        }
        public async Task<IActionResult> AllCustomers()
        {
            if(HttpContext.Session.GetString("email") == null){
                return RedirectToAction("Login", "Login");
            }
                using (var client = new HttpClient()){
 
                //Passing service base url  
         //       client.BaseAddress = new Uri(Baseurl);
 
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
 
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("http://localhost:5159/api/Admin3");
 
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api  
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
 
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    c = JsonConvert.DeserializeObject<List<AdminCustomersJivanshu>>(EmpResponse);
 
                }
                //s= acc;
                //returning the employee list to view  
                return View(c);
                }
           
        }

        public async Task<ActionResult> DeleteCustomer(int id)
        {
            if(HttpContext.Session.GetString("email") == null){
                return RedirectToAction("Login", "Login");
            }
            TempData["cid"] = id;
            AdminCustomersJivanshu e = new AdminCustomersJivanshu();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5159/api/Admin3/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    e = JsonConvert.DeserializeObject<AdminCustomersJivanshu>(apiResponse);
                }
            }
            return View(e);
        }


        [HttpPost]
       // [ActionName("DeleteEmployee")]
        public async Task<ActionResult> DeleteCustomer(AdminCustomersJivanshu e)
        {
            if(HttpContext.Session.GetString("email") == null){
                return RedirectToAction("Login", "Login");
            }
            int cid = Convert.ToInt32(TempData["cid"]);
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:5159/api/Admin3/" + cid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Home", "Admin");
        }
 
       
 
    }
}