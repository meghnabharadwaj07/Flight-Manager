
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using FlightAvailable;
namespace BookFlight.Controllers
{
    [ApiController]
    [Route("[controller]")]   
     public class BookController : ControllerBase
    {
        public BookController()
        {

        }
       
        [HttpGet]
        public Model.Book Get()
        {
        List<int > Flight_no= new List<int>();
        Flight_no.Add(1234);
        Flight_no.Add(1235);
        int customer_id = 123;
        FlightAvailable.Controllers.AvailabilityController Av= new FlightAvailable.Controllers.AvailabilityController(1234);
       FlightAvailable.Model.Availability avail=Av.Get();
      string payment ="paid";
        if(avail.status)
        {
           if(payment == "paid")
           {
           return  new Model.Book{
               status=true,
               message=" your booking has been confirmed",
               booking= "confirmed"
           };
           }
           else 
           {
                return  new Model.Book{
               status=false,
               message=" your booking is pending",
               booking= "pending"
           };
           }

        }
        else
        {
            return  new Model.Book{
               status=false,
               message=" There are no seats available",
               booking= ""
           };
        }

        }

        
    }
}