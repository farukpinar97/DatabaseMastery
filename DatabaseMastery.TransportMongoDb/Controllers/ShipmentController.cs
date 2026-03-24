using DatabaseMastery.TransportMongoDb.Dtos.ShipmentDtos;
using DatabaseMastery.TransportMongoDb.Services.ShipmentServices;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseMastery.TransportMongoDb.Controllers
{
    public class ShipmentController : Controller
    {
        private readonly IShipmentService _ShipmentService;

        public ShipmentController(IShipmentService ShipmentService)
        {
            _ShipmentService = ShipmentService;
        }

        public async Task<IActionResult> ShipmentList()
        {
            var values = await _ShipmentService.GetAllShipmentAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateShipment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateShipment(CreateShipmentDto createShipmentDto)
        {
            await _ShipmentService.CreateShipmentAsync(createShipmentDto);
            return RedirectToAction("ShipmentList");
        }

        public async Task<IActionResult> DeleteShipment(string id)
        {
            await _ShipmentService.DeleteShipmentAsync(id);
            return RedirectToAction("ShipmentList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateShipment(string id)
        {
            var value = await _ShipmentService.GetShipmentByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateShipment(UpdateShipmentDto updateShipmentDto)
        {
            await _ShipmentService.UpdateShipmentAsync(updateShipmentDto);
            return RedirectToAction("ShipmentList");
        }
    }
}
