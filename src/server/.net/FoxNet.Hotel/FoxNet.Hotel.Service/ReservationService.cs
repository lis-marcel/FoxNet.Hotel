using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoxNet.Hotel.BO;
using FoxNet.Hotel.Common;
using FoxNet.Hotel.Service.DTO;

namespace FoxNet.Hotel.Service
{
    public class ReservationService
    {
        private DbStorage db;
        public ReservationService(DbStorage db) 
        {
            this.db = db;
        }

        public int MakeReservation(ReservationData reservationData)
        {
            var r = new Reservation()
            {
                FirstDay = reservationData.FirstDay,
                LastDay = reservationData.LastDay,
                RoomId = reservationData.RoomId,
                UserId = reservationData.UserId,
            };

            var reservation = db.Reservations.Add(r);
            db.SaveChanges();

            return reservation.Entity.Id;
        }

        public ReservationData GetReservation(int reservationId)
        {
            var reservation = db.Reservations.Single(r => r.Id == reservationId);

            return new ReservationData()
            {
                Id = reservation.Id,
                FirstDay = reservation.FirstDay,
                LastDay = reservation.LastDay,
                RoomId = reservation.RoomId,
                UserId = reservation.UserId
            };
        }

        public IList<ReservationData> GetReservations()
        {
            return (IList<ReservationData>)db.Reservations.Select(r => new ReservationData()
            {
                Id = r.Id,
                FirstDay = r.FirstDay,
                RoomId=r.RoomId,
                LastDay=r.LastDay,
                UserId = r.UserId
            });
        }

        public void DeleteReservation(int reservationId)
        {
            var reservation = db.Reservations.Single(r => r.Id == reservationId);

            db.Reservations.Remove(reservation);
            db.SaveChanges();
        }
    }
}