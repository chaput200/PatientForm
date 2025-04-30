using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitechProject
{

    public class Patient
    {
        public Guid PatientKEY { get; set; }  // Used only for editing existing records
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string HomePhone { get; set; }
        public string BusineesPhone { get; set; }
        public string CellPhone { get; set; }
        public string EmailAddress { get; set; }
    }

}
