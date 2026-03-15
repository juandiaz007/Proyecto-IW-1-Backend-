using SalaFinder.DAO;
using SalaFinder.Interfaces;
using SalaFinder.Models;
using Microsoft.EntityFrameworkCore;


public class ReservationService : IReservationService
{
    private readonly ApplicationDbContext _context;

    public ReservationService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Reservation?> GetById(Guid id)
    {
        return await _context.Reservations.FirstOrDefaultAsync(r => r.id_reservation == id);
    }
    public async Task<List<Reservation>> GetAll()
    {
        return await _context.Reservations.ToListAsync();
    }

    public async Task<Reservation> Create(Reservation reservation, string userProgram)
    {
        var space = await _context.Spaces.FindAsync(reservation.spaceId);

        if (space == null)
            throw new Exception("El espacio no existe");

        if (!space.allowedPrograms.Contains(userProgram))
            throw new Exception("Tu programa no tiene acceso a este espacio");

        var conflict = await CheckConflict(reservation.spaceId,reservation.date,reservation.startTime,reservation.endTime);

        if (conflict)
            throw new Exception("Conflicto de tiempo detectado");

        if (space.requiresApproval)
            reservation.status = "Pending";
        else
            reservation.status = "Approved";

        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync();

        return reservation;
    }

    public async Task<bool> CheckConflict(Guid spaceId, DateTime date, TimeSpan start, TimeSpan end)
    {
        return await _context.Reservations.Where(r => r.spaceId == spaceId && r.date == date && r.status == "Approved" && start < r.endTime && end > r.startTime).AnyAsync();
    }

    public async Task<bool> Approve(Guid reservationId)
    {
        var reservation = await _context.Reservations.FindAsync(reservationId);

        if (reservation == null)
            return false;

        reservation.status = "Approved";

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> Reject(Guid reservationId)
    {
        var reservation = await _context.Reservations.FindAsync(reservationId);

        if (reservation == null)
            return false;

        reservation.status = "Rejected";

        await _context.SaveChangesAsync();

        return true;
    }
    public async Task<bool> Cancel(Guid reservationId)
    {
        var reservation = await _context.Reservations.FindAsync(reservationId);

        if (reservation == null)
            return false;

        reservation.status = "Cancelled";

        await _context.SaveChangesAsync();

        return true;
    }
}