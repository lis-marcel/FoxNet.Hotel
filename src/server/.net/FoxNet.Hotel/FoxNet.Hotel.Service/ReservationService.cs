using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoxNet.Hotel.BO;
using FoxNet.Hotel.Service.DTO;

namespace FoxNet.Hotel.Service
{
    public class ReservationService
    {
        public ReservationService() { }
        public ReservationService(DbStorage.DbStorage db) { }

        public int MakeReservation(ReservationData reservationData)
        {
            var db = new DbStorage.DbStorage();
            db.Database.EnsureCreated();

            var r = new Reservation()
            {
                FirstDay = reservationData.FirstDay,
                LastDay = reservationData.LastDay,
                RoomId = reservationData.RoomId,
                UserId = reservationData.UserId,
            };

            var reservation = db.Reservations.Add(r);
            db.SaveChanges();

            db.Dispose();

            return reservation.Entity.Id;
        }

        public void DeleteReservation(int reservationId)
        {
            var db = new DbStorage.DbStorage();
            db.Database.EnsureCreated();

            var reservation = db.Reservations.SingleOrDefault(r => r.Id == reservationId);

            if (reservation != null)
            {
                db.Reservations.Remove(reservation);
                db.SaveChanges();
            }

            else db.SaveChanges();

            db.Dispose();
        }
    }
}