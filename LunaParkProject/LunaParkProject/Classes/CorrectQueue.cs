using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LunaParkProject.Classes
{
    public class CorrectQueue
    {
        public int UserId { get; set; }
        public int AttractionId { get; set; }
        public DateTime StartTime { get; set; }
        public int Tickets { get; set; }
    }
}