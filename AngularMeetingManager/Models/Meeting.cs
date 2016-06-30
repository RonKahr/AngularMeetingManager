using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularMeetingManager.Models
{
    public class Meeting
    {
        public int id { get; set; }
        public string title { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public int room_id { get; set; }
        public string roomname { get; set; }


    }
}