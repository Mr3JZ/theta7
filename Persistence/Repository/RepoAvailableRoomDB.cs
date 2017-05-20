using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class RepoAvailableRoomDB
    {
        public void Add(int confId, string roomName, int capacity, string street, string city, string postalCode, DateTime beginDate, DateTime endDate)
        {
            using (var context = new ISSEntities2(Util.ConnectionStringWithPassword.doIt()))
            {
                AvailableRoom ar = new AvailableRoom();
                ar.ConferenceId = confId;
                ar.RoomName = roomName;
                ar.Capacity = capacity;
                ar.BeginDate = beginDate;
                ar.EndDate = endDate;

                int aId = -1;
                foreach (Address a in context.Addresses)
                    if (a.City == city && a.Street == street && a.PostalCode == postalCode)
                    {
                        aId = a.AddressId;
                        break;
                    }

                if (aId == -1)
                {
                    Address a = new Address();
                    a.City = city;
                    a.Street = street;
                    a.PostalCode = postalCode;
                    context.Addresses.Add(a);
                    context.SaveChanges();
                    aId = a.AddressId;
                }

                ar.AddressId = aId;
                context.AvailableRooms.Add(ar);
                context.SaveChanges();
            }

        }
    }
}
