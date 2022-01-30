using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LunaParkProject.Classes
{
    public class UpdateMaxPeople
    {
        public DateTime TimeNow { get; set; }
        public int AttractionId { get; set; }
        public int AttractionMaxPeople { get; set; }
    }
}