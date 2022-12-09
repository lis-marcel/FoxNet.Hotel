using FoxNet.Hotel.BO;
using FoxNet.Hotel.Service.ClassConverter;
using FoxNet.Hotel.Service.DTO;

namespace FoxNet.Hotel.Service.ClassConverter
{
    public class ConvertReservation
    {
        public static ReservationData ReservationToReservationData(Reservation reservation)
        {
            return new ReservationData()
            {
                Id = reservation.ReservationId,
                FirstDay = reservation.FirstDay,
                LastDay = reservation.LastDay,
                RoomId = reservation.RoomId,
                UserId = reservation.UserId
            };
        }

        public static Reservation ReservationDataToReservation(ReservationData reservationData)
        {
            return new Reservation()
            {
                ReservationId = reservationData.Id,
                FirstDay = reservationData.FirstDay,
                LastDay = reservationData.LastDay,
                RoomId = reservationData.RoomId,
                UserId = reservationData.UserId
            };
        }
    }
}
