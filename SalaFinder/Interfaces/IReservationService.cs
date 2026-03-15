using SalaFinder.Models;

namespace SalaFinder.Interfaces
{
    public interface IReservationService
    {

        Task<List<Reservation>> GetAll();

        Task<Reservation> GetById(Guid id);

        Task<Reservation> Create(Reservation reservation);

        Task<bool> Approve(Guid reservationId);

        Task<bool> Reject(Guid reservationId);

        Task<bool> Cancel(Guid reservationId);

        Task<bool> CheckConflict(Guid spaceId, DateTime date, TimeSpan start, TimeSpan end);
    
    }   
}
