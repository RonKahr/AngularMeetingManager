using AngularMeetingManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularMeetingManager.Models
{
    public class Room
    {
        public int id { get; set; }
        public string roomname { get; set; }
        public string floor { get; set; }
        public int capacity { get; set; }
    }
}