using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shkolo.Data.Datasets.Seeders
{
    public class DataAdminArea
    {
        public string[] DataRole =
         {
                "Admin","","",
                "Teacher","","",
                "Student","","",
                "Student","","",
          };

        public string[] DataUser =
         {
                "mitko@abv.bg","+359888443322","123456",
                "sashka@abv.bg","+359888554433","123456",
                "asenk@abv.bg","+359892935556","123456",
                "asenm@abv.bg","+359894460845","123456",
          };

        public string[] DataClaims =
         {
                "studentName",
                "phoneNumber",
                "numberInClass",
                "subject",
          };
    }
}
