using AngularMeetingManager.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AngularMeetingManager.Controllers
{
    [RoutePrefix("api/meetings")]
    public class MeetingsController : ApiController
    {

        [Route("GetAllMeetings")]
        public IEnumerable<Meeting> GetAllMeetings()
        {
            List<Meeting> meetings = new List<Meeting>();
            Meeting meet;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["AMMDb"].ConnectionString;
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conn;
            conn.Open();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "GetAllMeetings";

            //sqlCmd.Parameters.Add(sqlParam);

            SqlDataReader reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {
                meet = new Meeting();
                meet.end = (DateTime)reader["end"];
                meet.id = (int)reader["id"];
                meet.start = (DateTime)reader["start"];
                meet.title = reader["title"].ToString();
                meetings.Add(meet);
            }
            reader.Dispose();

            //output.Load(reader);
            return meetings;
        }

        [Route("GetMeetingsByRoom/{id}")]
        public IEnumerable<Meeting> GetMeetingsByRoom(int id)
        {
            List<Meeting> meetings = new List<Meeting>();
            Meeting meet;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["AMMDb"].ConnectionString;
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conn;
            conn.Open();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "GetMeetingsByRoom";

            SqlParameter sqlParam = new SqlParameter("room_id", id);
            sqlCmd.Parameters.Add(sqlParam);

            SqlDataReader reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {
                meet = new Meeting();
                meet.end = (DateTime)reader["end"];
                meet.id = (int)reader["id"];
                meet.start = (DateTime)reader["start"];
                meet.title = reader["title"].ToString();
                meet.room_id = (int)reader["room_id"];
                meetings.Add(meet);
            }
            reader.Dispose();

            //output.Load(reader);
            return meetings;
        }

        [Route("GetMeetingByID/{id}")]
        public IEnumerable<Meeting> GetMeetingByID(int id)
        {
            List<Meeting> meetings = new List<Meeting>();
            Meeting meeting;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["AMMDb"].ConnectionString;
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conn;
            conn.Open();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "GetMeetingByID";

            SqlParameter sqlParam = new SqlParameter("meeting_id", id);
            sqlCmd.Parameters.Add(sqlParam);

            SqlDataReader reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {

                meeting = new Meeting();
                meeting.end = (DateTime)reader["end"];
                meeting.id = (int)reader["id"];
                meeting.start = (DateTime)reader["start"];
                meeting.title = reader["title"].ToString();
                meeting.room_id = (int)reader["room_id"];
                meeting.roomname = reader["roomname"].ToString();
                meetings.Add(meeting);
            }
            reader.Dispose();

            //output.Load(reader);
            return meetings;
        }

        [HttpPost]
        [Route("AddMeeting")]
        public string AddRoom([FromBody] Meeting mt)
        {
            string meetingid = string.Empty;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["AMMDb"].ConnectionString;
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conn;
            conn.Open();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "AddMeeting";

            SqlParameter sqlParam1 = new SqlParameter("title", mt.title);
            sqlCmd.Parameters.Add(sqlParam1);
            SqlParameter sqlParam2 = new SqlParameter("start", mt.start);
            sqlCmd.Parameters.Add(sqlParam2);
            SqlParameter sqlParam3 = new SqlParameter("end", mt.end);
            sqlCmd.Parameters.Add(sqlParam3);
            SqlParameter sqlParam4 = new SqlParameter("room_id", mt.room_id);
            sqlCmd.Parameters.Add(sqlParam4);

            SqlDataReader reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {

                meetingid = reader["meetingid"].ToString();
            }
            reader.Dispose();

            //output.Load(reader);
            return meetingid;
        }

        [HttpGet]
        [Route("DeleteMeeting/{id}")]
        public string DeleteMeeting(int id)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["AMMDb"].ConnectionString;
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conn;
            conn.Open();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "DeleteMeeting";

            SqlParameter sqlParam = new SqlParameter("meetingid", id);
            sqlCmd.Parameters.Add(sqlParam);

            sqlCmd.ExecuteNonQuery();

            ////info should contain emailaddress and rolid
            return "Room Deleted";
        }
    }
}
