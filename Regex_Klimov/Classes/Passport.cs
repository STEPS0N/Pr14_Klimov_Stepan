using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regex_Klimov.Classes
{
    public class Passport
    {
        public string Name { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Issued { get; set; }
        
        public string DateOfIssued { get; set; }
        
        public string DepartmentCode { get; set; }
        
        public string SeriesAndNumber { get; set; }
        
        public string DateOfBirth { get; set; }
        
        public string PlaceOfBirth { get; set; }

        public string Picture { get; set; } = "pack://application:,,,/Images/passport.jpg";
    }
}
