using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalaFinder.Interfaces;
using SalaFinder.Models;

namespace SalaFinder.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly IReservationService _reservationService;

            public ReservationController(IReservationService reservationService)
            {
                _reservationService = reservationService;
            }

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                return Ok(await _reservationService.GetAll());
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(Guid id)
            {
                var reservation = await _reservationService.GetById(id);

                if (reservation == null) return NotFound();

                return Ok(reservation);
            }

            [Authorize]
            [HttpPost]
            public async Task<IActionResult> Create([FromBody] Reservation reservation)
            {
                var created = await _reservationService.Create(reservation);
                return Ok(created);
            }

            [Authorize(Roles = "Admin")]
            [HttpPut("approve/{id}")]
            public async Task<IActionResult> Approve(Guid id)
            {
                var result = await _reservationService.Approve(id);

                if (!result) return NotFound();

                return Ok("Reservation approved");
            }

            [Authorize(Roles = "Admin")]
            [HttpPut("reject/{id}")]
            public async Task<IActionResult> Reject(Guid id)
            {
                var result = await _reservationService.Reject(id);

                if (!result) return NotFound();

                return Ok("Reservation rejected");
            }

            [Authorize]
            [HttpPut("cancel/{id}")]
            public async Task<IActionResult> Cancel(Guid id)
            {
                var result = await _reservationService.Cancel(id);

                if (!result) return NotFound();

                return Ok("Reservation cancelled");
            }
        }
}


