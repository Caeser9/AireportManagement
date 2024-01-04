using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods : IFlightMethods
    {

       public IList<Flight> Flights = new List<Flight>();

        public IList<DateTime> GetFlightDates(string destination)
        {
            //IList<DateTime> Result = new List<DateTime>();
            // // foreach -- item = Flight
            // foreach (var item in Flights)
            // {
            //     if (item.Destination == destination)
            //         Result.Add(item.FlightDate);
            // }
            // return Result;


            /* Le langage Linq 
             * var query = from instance in Collection
             *                  (A-X-P-item) in Flights (A= Flight)
             *             where condition ( A.Destination== destination)
             *             select   A.FlightDate;
             * return query 
       
             */

            //with linq
            //var query = from item in Flights
            //            where item.Destination == destination
            //            select item.FlightDate;
            //return query.ToList();

            //Lambda // item = Flight
            return Flights.Where(item=>item.Destination == destination)

                .Select(a=>a.FlightDate).ToList() ;
                
                ;
        }

       
        public void ShowFlightDetails(Plane x1)
        {

            //var query = from a in x1.Flights
            //            select new {a.Destination,a.FlightDate};


            var query = from a in Flights // a= flight
                        where a.Plane == x1
                        select new { a.Destination, a.FlightDate };

            foreach (var item in query)
            {
                Console.WriteLine( "FlightDate"
                    +item.FlightDate+"Destination"+item.Destination );
            }
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            //var query = from a in Flights
            //            where DateTime.Compare(a.FlightDate, startDate) > 0
            //            && (a.FlightDate - startDate).TotalDays < 7
            //            select a;
            //return query.Count();

            //Lamba
            //return Flights.Where(a => (a.FlightDate - startDate).TotalDays < 7)
            //    .Count();
            return Flights.Count(a=> (a.FlightDate - startDate).TotalDays < 7);

        }

        public double DurationAverage(string destination)
        {
            //var query = from f in Flights
            //            where f.Destination == destination
            //            select f.EstimatedDuration;
            //return query.Average();
            //Lambda
            return Flights.Where(f => f.Destination.Equals(destination)).Average(p => p.EstimatedDuration);
        }

        public IEnumerable<Flight> OrderedDurationFlights()
        {
            //Linq
            //var query = from a in Flights
            //            orderby a.EstimatedDuration descending
            //            select a;
            //return query;

            //Lambda
            return Flights.OrderByDescending(f => f.EstimatedDuration);
           
        }

        public IEnumerable<Traveller> SeniorTravellers(Flight f1)
        {

            //var query = from a in f1.Passengers.OfType<Traveller>()
            //            orderby a.BirthDate
            //            select a;
            //return query.Take(3);
            //Lambda
            return f1.Passengers.OfType<Traveller>().OrderBy(p => p.BirthDate).Take(3);

        }

        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            var query = from a in Flights
                        group a by a.Destination;
            foreach (var item in query)
            {
                Console.WriteLine("Destination "+item.Key  );
                foreach(var a in item)
                {
                    Console.WriteLine(  "Flight Date "+a.FlightDate);
                }


            }
            return query;

        }

        /* Le langage Linq 
           * var query = from instance in Collection
           *                  (A-X-P-item) in Flights (A= Flight)
           *             where condition ( A.Destination== destination)
           *             select   A.FlightDate;
           * return query 
           * 
           * Lambda ,
           * var lambda = Collection.Where(instance=> instance.. (condition)
           *                         .Select(instance=>instance.FlightDate);

           */

    }
}
