using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AngularMeetingManager.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace AngularMeetingManager.Controllers
{
    [RoutePrefix("api/rooms")]
    public class RoomsController : ApiController
    {
        [Route("GetAllRooms")]
        public IEnumerable<Room> GetAllRooms()
        {
            List<Room> rooms = new List<Room>();
            Room rm;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["AMMDb"].ConnectionString;
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conn;
            conn.Open();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "GetAllRooms";

            //sqlCmd.Parameters.Add(sqlParam);

            SqlDataReader reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {
                rm = new Room();
                rm.capacity = (int)reader["capacity"];
                rm.floor = reader["floor"].ToString();
                rm.id = (int)reader["id"];
                rm.roomname = reader["roomname"].ToString();
                rooms.Add(rm);
            }
            reader.Dispose();

            //output.Load(reader);
            return rooms;
        }

        [Route("GetRoomByID/{id}")]
        public IEnumerable<Room> GetRoomByID(int id)
        {
            List<Room> rooms = new List<Room>();
            Room room;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["AMMDb"].ConnectionString;
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conn;
            conn.Open();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "GetRoomByID";

            SqlParameter sqlParam = new SqlParameter("room_id", id);
            sqlCmd.Parameters.Add(sqlParam);

            SqlDataReader reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {

                room = new Room();
                room.capacity = (int)reader["capacity"];
                room.floor = reader["floor"].ToString();
                room.id = (int)reader["id"];
                room.roomname = reader["roomname"].ToString();
                rooms.Add(room);
            }
            reader.Dispose();

            //output.Load(reader);
            return rooms;
        }

        [HttpGet]
        [Route("DeleteRoom/{id}")]
        public string DeleteRoom(int id)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["AMMDb"].ConnectionString;
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conn;
            conn.Open();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "DeleteRoom";

            SqlParameter sqlParam = new SqlParameter("roomid", id);
            sqlCmd.Parameters.Add(sqlParam);

            sqlCmd.ExecuteNonQuery();

            ////info should contain emailaddress and rolid
            return "Room Deleted";
        }

        [HttpPost]
        [Route("UpdateRoom")]
        public HttpResponseMessage UpdateRoom([FromBody] Room room)
        {
            HttpStatusCode code = new HttpStatusCode();
            StringContent content;
            content = new StringContent(string.Empty);
            code = HttpStatusCode.OK;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["AMMDb"].ConnectionString;
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conn;
            conn.Open();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "UpdateRoom";

            SqlParameter sqlParam = new SqlParameter("roomid", room.id);
            sqlCmd.Parameters.Add(sqlParam);
            SqlParameter sqlParam1 = new SqlParameter("roomname", room.roomname);
            sqlCmd.Parameters.Add(sqlParam1);
            SqlParameter sqlParam2 = new SqlParameter("floor", room.floor);
            sqlCmd.Parameters.Add(sqlParam2);
            SqlParameter sqlParam3 = new SqlParameter("capacity", room.capacity);
            sqlCmd.Parameters.Add(sqlParam3);

            sqlCmd.ExecuteNonQuery();

            HttpResponseMessage response = Request.CreateResponse(code);
            response.Content = content;
            ////info should contain emailaddress and rolid
            return response;
        }
        
        [HttpPost]
        [Route("AddRoom")]
        public string AddRoom([FromBody] Room room) {
            string roomid = string.Empty;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["AMMDb"].ConnectionString;
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conn;
            conn.Open();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "AddRoom";

            SqlParameter sqlParam1 = new SqlParameter("roomname", room.roomname);
            sqlCmd.Parameters.Add(sqlParam1);
            SqlParameter sqlParam2 = new SqlParameter("floor", room.floor);
            sqlCmd.Parameters.Add(sqlParam2);
            SqlParameter sqlParam3 = new SqlParameter("capacity", room.capacity);
            sqlCmd.Parameters.Add(sqlParam3);

            SqlDataReader reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {

                roomid = reader["roomid"].ToString() ;
            }
            reader.Dispose();

            //output.Load(reader);
            return roomid;
        }

        
    }
}
