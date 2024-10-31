using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
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
                return RoomList = context.RoomInformations
                    .Include(r => r.RoomType)
                    .ToList();
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
                var room = context.RoomInformations
                                  .Include(r => r.BookingDetails)
                                  .FirstOrDefault(r => r.RoomId == roomInformation.RoomId);

                if (room == null)
                {
                    throw new Exception("Room not found.");
                }
                bool isRoomInTransaction = room.BookingDetails.Any();

                if (isRoomInTransaction)
                {
                    room.RoomStatus = 2; 
                    context.RoomInformations.Update(room);
                }
                else
                {
                    // If no booking transaction, delete the room
                    context.RoomInformations.Remove(room);
                }

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
