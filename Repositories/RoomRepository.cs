using BusinessObjects.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RoomRepository : IRoomRepository
    {
        public void CreateNewRoom(RoomInformation roomInformation) => RoomDAO.CreateNewRoom(roomInformation);

        public void DeleteRoom(RoomInformation roomInformation) => RoomDAO.DeleteRoom(roomInformation);

        public RoomInformation GetRoomById(int id) => RoomDAO.GetRoomById(id);

        public List<RoomInformation> GetRooms() => RoomDAO.GetRooms();

        public void UpdateRoom(RoomInformation roomInformation) => RoomDAO.UpdateRoom(roomInformation);
    }
}
