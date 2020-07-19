using System.Reflection;
using System.Xml.Schema;
using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace FlightAvailable.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AvailabilityController : ControllerBase
    { 
      public AvailabilityController(int Flight_no)
      {
         this.Flight_no=Flight_no;
      }
       
       public int Flight_no{get;set;}
      
        
      
       
       [HttpGet]
       public Model.Availability Get()
       {
           int Flight_no=1234;
            Dictionary<int,int> fl= new Dictionary<int, int>();
            fl.Add(1234,5);
            fl.Add(1235,5);
            fl.Add(1236,5);
            fl.Add(1237,5);
           
           
            if(fl.ContainsKey(Flight_no))
            {
                 int v= fl[Flight_no];
                if(v>0)
                {
                   
                return new Model.Availability{
                    status=true,
                    message="Seat available",
                    seat=v

                };
                }
                else
                {
                    return new Model.Availability{
                        status=false,
                        message="seats not available",
                        seat=v
                    };
                }
     
       }
       else
       {
           return new Model.Availability{
               message="invalid"
           };
       }

    }
}
}