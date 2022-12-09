using FoxNet.Hotel.BO;
using FoxNet.Hotel.Common;
using FoxNet.Hotel.Service.DTO;
using FoxNet.Hotel.Service.ClassConverter;

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
            var r = ConvertReservation.ReservationDataToReservation(reservationData);

            var reservation = db.Reservations.Add(r);
            db.SaveChanges();

            return reservation.Entity.ReservationId;
        }

        public ReservationData GetReservation(int reservationId)
        {
            var reservation = db.Reservations.Single(r => r.ReservationId == reservationId);

            return ConvertReservation.ReservationToReservationData(reservation);
        }

        public IList<ReservationData> GetReservations()
        {
            return db.Reservations.Select(r => 
                ConvertReservation.ReservationToReservationData(r))
                .ToList();
        }

        public void DeleteReservation(int reservationId)
        {
            var reservation = db.Reservations.Single(r => r.ReservationId == reservationId);

            db.Reservations.Remove(reservation);
            db.SaveChanges();
        }
    }
}