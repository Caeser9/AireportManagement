using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IFlightMethods
    {

      IList<DateTime>  GetFlightDates(string destination);
       void ShowFlightDetails(Plane plane);

       int ProgrammedFlightNumber(DateTime startDate);
        double DurationAverage(string destination);
      IEnumerable<Flight>  OrderedDurationFlights();
        IEnumerable<Traveller> SeniorTravellers(Flight f1);

       IEnumerable<IGrouping<string,Flight>> DestinationGroupedFlights();
    }
}
