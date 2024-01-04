using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{


    public enum PlaneType
    {
        Boing,
        Airbus
    }
    public class Plane

    {

        #region prop de base
        public int PlaneId { get; set; }

        public PlaneType PlaneType { get; set; }

        public DateTime ManufactureDate { get; set; }
        [Range(0, int.MaxValue)]
        public int Capacity { get; set; }

        #endregion

        #region prop de navigation
        public virtual IList<Flight> Flights { get; set; }


        #endregion

     
    }
}
