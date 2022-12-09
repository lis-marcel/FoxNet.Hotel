using FoxNet.Hotel.Common;
using FoxNet.Hotel.Service.DTO;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxNet.Hotel.Service.Filters
{
    public class FiltersQueries
    {
        private static string CompareQueries(string basicQuery, string newQuery)
        {
            if (basicQuery != newQuery)
            {
                return newQuery += " and";
            }

            else
            {
                return newQuery;
            }
        }

        public static IList<Room> FilterRooms(DbStorage db, DTO.FiltersData roomsFilters)
        {
            var min = roomsFilters.MinPrice != null ? Convert.ToDecimal(roomsFilters.MinPrice) : default(decimal?);
            var firstDay = new SqliteParameter("firstDay", roomsFilters.FirstDay);
            var lastDay = new SqliteParameter("lastDay", roomsFilters.LastDay);
            var beds = new SqliteParameter("beds", roomsFilters.Beds);
            var maxPrice = new SqliteParameter("max", roomsFilters.MaxPrice);
            var minPrice = new SqliteParameter("min", min);

            var queryCore = new StringBuilder("select * from Rooms where 1 = 1 ");

            if (roomsFilters.FirstDay != null && roomsFilters.LastDay != null)
            {
                queryCore.AppendLine(
                    " and Rooms.RoomId not in (" +
                        "select Reservations.RoomId" +
                        " from Reservations" +
                        " where (@firstDay < Reservations.FirstDay)" +
                        " or (@firstDay > Reservations.FirstDay and @firstDay < Reservations.LastDay) " +
                    ")");
            }

            if (roomsFilters.Beds != null)
            {
                queryCore.AppendLine(" and (Rooms.BedsAmount = @beds)");
            }

            if (roomsFilters.MaxPrice != null)
            {
                queryCore.AppendLine(" and (CAST(Rooms.Price AS DECIMAL) < CAST(@max AS DECIMAL))");
            }

            if (min.HasValue)
            {
                queryCore.AppendLine(" and (Rooms.Price > @min)");
            }

            var res = db.Rooms
                .FromSqlRaw(queryCore.ToString(), firstDay, lastDay, beds, maxPrice, minPrice)
                .ToList();

            return res;
        }
    }
}
