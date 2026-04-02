using DatabaseMastery.DinnerMenuPostgreSQL.Dtos.ReservationDtos;
using DatabaseMastery.DinnerMenuPostgreSQL.Services.CategoryServices;
using DatabaseMastery.DinnerMenuPostgreSQL.Services.ReservationServices;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseMastery.DinnerMenuPostgreSQL.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly ICategoryService _categoryService;

        public ReservationController(IReservationService reservationService, ICategoryService categoryService)
        {
            _reservationService = reservationService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> ReservationList()
        {
            var values = await _reservationService.GetAllReservationsAsync();
            return View(values);
        }

        public IActionResult CreateReservation() 
        { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationDto createReservationDto)
        {
            createReservationDto.ReservationDate = DateTime.SpecifyKind(createReservationDto.ReservationDate, DateTimeKind.Utc);
            await _reservationService.CreateReservationAsync(createReservationDto);
            return RedirectToAction("ReservationList");
        }

        public async Task<IActionResult> DeleteReservation(int id)
        {
            await _reservationService.DeleteReservationAsync(id);
            return RedirectToAction("ReservationList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateReservation(int id)
        {
            var value = await _reservationService.GetReservationByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateReservation(UpdateReservationDto updateReservationDto)
        {
            updateReservationDto.ReservationDate = DateTime.SpecifyKind(updateReservationDto.ReservationDate, DateTimeKind.Utc);
            await _reservationService.UpdateReservationAsync(updateReservationDto);
            return RedirectToAction("ReservationList");
        }

        public async Task<IActionResult> ApproveReservation(int id)
        {
            await _reservationService.ChangeReservationStatusToApproval(id);
            return RedirectToAction("ReservationList");
        }

        public async Task<IActionResult> PendingReservation(int id)
        {
            await _reservationService.ChangeReservationStatusToPending(id);
            return RedirectToAction("ReservationList");
        }

        public async Task<IActionResult> CancelReservation(int id)
        {
            await _reservationService.ChangeReservationStatusToCancel(id);
            return RedirectToAction("ReservationList");
        }

        // UI tarafı — Müşteri rezervasyon formu
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateReservationDto createReservationDto)
        {
            createReservationDto.Status = "Beklemede";
            createReservationDto.ReservationDate = DateTime.SpecifyKind(
                createReservationDto.ReservationDate, DateTimeKind.Utc);

            await _reservationService.CreateReservationAsync(createReservationDto);

            TempData["Success"] = "Rezervasyonunuz alındı. En kısa sürede onay verilecektir.";
            return RedirectToAction("Create");
        }
    }
}
