using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataAccessLayer
{
    public class RoomDAO
    {
        public static List<RoomInformation> GetRooms()
        {
            var RoomList = new List<RoomInformation>();
            try
            {
                using var context = new FuminiHotelManagementContext();
                return RoomList = context.RoomInformations.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void CreateNewRoom(RoomInformation roomInformation)
        {
            try
            {
                using var context = new FuminiHotelManagementContext();
                context.RoomInformations.Add(roomInformation);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateRoom(RoomInformation roomInformation)
        {
            try
            {
                using var context = new FuminiHotelManagementContext();
                context.RoomInformations.Update(roomInformation);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteRoom(RoomInformation roomInformation)
        {
            try
            {
                using var context = new FuminiHotelManagementContext();
                context.RoomInformations.Remove(roomInformation);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static RoomInformation GetRoomById(int id)
        {
            try
            {
                using var context = new FuminiHotelManagementContext();
                return context.RoomInformations.FirstOrDefault(r => r.RoomId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
