using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : Service<Flight>, IServiceFlight
    {
        public ServiceFlight(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Staff> GetStaffById(int FlightId)
        {
            return GetById(FlightId).Passengers.OfType<Staff>();
        }

        public IEnumerable<Passenger> GetPassengersByPlane(Plane p, DateTime date)
        {
            return GetMany(f => f.Plane.PlaneId == p.PlaneId && f.FlightDate == date).SelectMany(f => f.Passengers).OfType<Traveller>();
        }
    }
}
