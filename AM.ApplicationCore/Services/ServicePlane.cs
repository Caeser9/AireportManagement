using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure
{
    public class ServicePlane : Service<Plane>, IServicePlane
    {
        public ServicePlane(ApplicationCore.Interfaces.IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Plane> GetPlaneByDate(DateTime date)
        {
            return GetMany(p => p.ManufactureDate.Equals(date));
        }
        public IEnumerable<Passenger> GetPassengerByPlane(Plane p)
        {
            return p.Flights.SelectMany(p => p.Passengers);
        }
        public IEnumerable<Flight> GetFlightsByDate(int n)
        {
            return GetAll().SelectMany(p => p.Flights).OrderByDescending(p => p.FlightDate).Take(n);
        }
        public Boolean CheckReservation(int n, Flight f)
        {
            return f.Plane.Capacity > f.Passengers.Count + n;
        }
        public void DeletePlanesByFabricationDate()
        {
            Delete(p => (DateTime.Now - p.ManufactureDate).TotalDays < 10 * 365);

        }


    }
}
