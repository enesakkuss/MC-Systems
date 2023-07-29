using McSystems.DataAccess;
using McSystems.DataAccess.Entities;
using McSystems.Reservations;
using McSystems.Rooms;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McSystems.Business
{
    public class ReservationService
    {
        public CommandResult Creat(ReservationDto reservationDto)
        {
            var context = new McSystemsContext();
                var reserve = MapToEntity(reservationDto);
            try
            {
                context.Reservations.Add(reserve);

                // Reservation Entity nesnesini context'e Add metodu ile tanıttığımızda o reservation
                // nesnesi veritabanına SaveChanges metodu çağırıldığında Insert edilecek

                // Ancak bu işlemin şöyle bir yan etkisi söz konusu!! reservation nesnesi ile
                // birlikte üzerindeki referans Customer nesneleri de Added durumu ile context'e tanıtılmış olur

                // Rezervasyon'a kaydı üzerinde her bir Customer nesnesinin Context'e tanıtılmış olmasında bir
                // bir sakınca yok, hatta rezervasyona zaten müşteri ekleyebilmek için bunun yapılmış olması gerekir
                // Ancak burada sorun olan durum; o Customer nesnelerinin Added (yeni kayıt) bilgisi ile tanıtılmış
                // olmasıdır.

                // Bu sebeple, Reservation nesnesini context'e tanıttıktan sonra kendisi ile birlikte 
                // otomatik olarak Context'e tanıtılmış Customer nesnelerini tek tek dolaşıp, durum bilgilerini
                // Unchanged (değişiklik görmemiş, var olan kayıt) olarak değiştirmem gerekir
                foreach (var customer in reserve.Customers)
                {
                    context.Entry(customer).State = EntityState.Unchanged;
                }
                context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Failure(ex);
            }
        }
        public CommandResult Delete(ReservationDto reservation)
        {
            var context = new McSystemsContext();
            try
            {
                context.Reservations.Remove(MapToEntity(reservation));
                context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Failure(ex);
            }
        }
        public List<ReservationDto> GetAll()
        {
            var context = new McSystemsContext();
            try
            {
                return context.Reservations.Select(MapToDto).ToList();
            }
            catch (Exception)
            {
                return new List<ReservationDto>();
            }
        }
        public List<RoomDto> SearchAvailableRoom(DateTime startDate, DateTime endDate)
        {
            var context = new McSystemsContext();

            try
            {
                var query = context.Reservations
                    .Where(r => r.StartDate >= startDate && r.StartDate <= startDate
                    || r.EndDate >= endDate && r.EndDate <= endDate
                    || startDate >= r.StartDate && startDate <= r.StartDate
                    || endDate >= r.EndDate && endDate <= r.EndDate)
                    .Select(r => r.RoomId).ToList();

                var result = context.Rooms.Where(room => !query.Contains(room.Id)).Select(MapToDtoRoom).ToList();
                if (result != null)
                {
                    return result;
                }
                return default;
            }
            catch (Exception)
            {
                return new List<RoomDto>();
            }
        }
        private Reservation MapToEntity(ReservationDto reservationDto)
        {
            return new Reservation
            {
                EmployeeId = reservationDto.EmployeeId,
                RoomId = reservationDto.RoomId,
                EndDate = reservationDto.EndDate,
                Id = reservationDto.Id,
                StartDate = reservationDto.StartDate
            };
        }
        private ReservationDto MapToDto(Reservation reservation)
        {
            return new ReservationDto
            {
                EmployeeId = reservation.EmployeeId,
                RoomId = reservation.RoomId,
                EndDate = reservation.EndDate,
                Id = reservation.Id,
                StartDate = reservation.StartDate,
            };
        }
        private RoomDto MapToDtoRoom(Room room)
        {
            return new RoomDto
            {
                Id = room.Id,
                Capacity = room.Capacity,
                Floor = room.Floor,
                InMaintanance = room.InMaintanance,
                Number = room.Number,
                RoomType = room.RoomType,
            };
        }
        internal static Reservation MapToReservationEntity(ReservationDto reservationDto)
        {
            var reservation = new Reservation()
            {
                Id = reservationDto.Id,
                RoomId = reservationDto.RoomId,
                EmployeeId = reservationDto.EmployeeId,
                EndDate = reservationDto.EndDate,
                StartDate = reservationDto.StartDate,
            };
            foreach (var customerDto in reservationDto.Customers)
            {
                reservation.Customers.Add(CustomerService.MapToEntity(customerDto));
            }
            return reservation;
        }

    }
}
