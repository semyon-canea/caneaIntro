using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLib.DAL
{
    public sealed class ContactInformationEntity
    {
        public long ID_ContactInformation { get; set; }

        public long UserID { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
