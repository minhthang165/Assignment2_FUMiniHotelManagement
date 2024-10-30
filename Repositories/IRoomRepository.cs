using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IRoomRepository
    {
        List<RoomInformation> GetRooms();
        void UpdateRoom(RoomInformation roomInformation);
        void DeleteRoom(RoomInformation roomInformation);
        void CreateNewRoom(RoomInformation roomInformation);
        RoomInformation GetRoomById(int id);
    }
}
