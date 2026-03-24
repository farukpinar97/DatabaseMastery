using DatabaseMastery.TransportMongoDb.Dtos.ShipmentDtos;
using DatabaseMastery.TransportMongoDb.Dtos.ShipmentTrackingDtos;
using DatabaseMastery.TransportMongoDb.Services.ShipmentServices;
using DatabaseMastery.TransportMongoDb.Services.ShipmentTrackingServices;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseMastery.TransportMongoDb.Controllers
{
    public class ShipmentTrackingController : Controller
    {
        private readonly IShipmentTrackingService _trackingService;
        private readonly IShipmentService _shipmentService;

        public ShipmentTrackingController(
            IShipmentTrackingService trackingService,
            IShipmentService shipmentService)
        {
            _trackingService = trackingService;
            _shipmentService = shipmentService;
        }

        // GET: /ShipmentTracking/Index?trackingNumber=TRK-ABC123
        public async Task<IActionResult> Index(string trackingNumber)
        {
            var values = await _trackingService.GetAllTrackingsAsync(trackingNumber);

            var shipment = await _shipmentService.GetShipmentByTrackingNumberAsync(trackingNumber);

            ViewBag.TrackingNumber = trackingNumber;
            ViewBag.SenderName = shipment?.SenderName;
            ViewBag.ReceiverName = shipment?.ReceiverName;
            ViewBag.OriginCity = shipment?.OriginCity;
            ViewBag.DestinationCity = shipment?.DestinationCity;
            ViewBag.CurrentStatus = shipment?.CurrentStatus;

            return View(values);
        }

        // GET: /ShipmentTracking/AddTracking?trackingNumber=TRK-ABC123
        [HttpGet]
        public async Task<IActionResult> AddTracking(string trackingNumber)
        {
            var shipment = await _shipmentService
                .GetShipmentByTrackingNumberAsync(trackingNumber);

            if (shipment == null)
                return NotFound();

            ViewBag.TrackingNumber = shipment.TrackingNumber;
            ViewBag.SenderName = shipment.SenderName;
            ViewBag.ReceiverName = shipment.ReceiverName;
            ViewBag.OriginCity = shipment.OriginCity;
            ViewBag.DestinationCity = shipment.DestinationCity;
            ViewBag.CurrentStatus = shipment.CurrentStatus;
            ViewBag.ExistingTrackings = shipment.Trackings?
                .OrderByDescending(x => x.EventDate)
                .ToList();

            var dto = new CreateShipmentTrackingDto
            {
                TrackingNumber = trackingNumber,
                EventDate = DateTime.Now
            };

            return View(dto);
        }

        // POST: /ShipmentTracking/AddTracking
        [HttpPost]
        public async Task<IActionResult> AddTracking(CreateShipmentTrackingDto createDto)
        {
            if (!ModelState.IsValid)
            {
                var shipment = await _shipmentService
                    .GetShipmentByTrackingNumberAsync(createDto.TrackingNumber);

                ViewBag.TrackingNumber = shipment?.TrackingNumber;
                ViewBag.SenderName = shipment?.SenderName;
                ViewBag.ReceiverName = shipment?.ReceiverName;
                ViewBag.OriginCity = shipment?.OriginCity;
                ViewBag.DestinationCity = shipment?.DestinationCity;
                ViewBag.CurrentStatus = shipment?.CurrentStatus;
                ViewBag.ExistingTrackings = shipment?.Trackings?
                    .OrderByDescending(x => x.EventDate)
                    .ToList();

                return View(createDto);
            }

            await _trackingService.CreateTrackingAsync(createDto);
            TempData["Success"] = "Kargo hareketi başarıyla eklendi!";
            return RedirectToAction("Index", new { trackingNumber = createDto.TrackingNumber });
        }

        // GET: /ShipmentTracking/UpdateTracking?trackingNumber=TRK-ABC123&trackingId=abc
        [HttpGet]
        public async Task<IActionResult> UpdateTracking(string trackingNumber, string trackingId)
        {
            var tracking = await _trackingService
                .GetTrackingByIdAsync(trackingNumber, trackingId); // ← değişti

            if (tracking == null)
                return NotFound();

            var shipment = await _shipmentService
                .GetShipmentByTrackingNumberAsync(trackingNumber);

            ViewBag.TrackingNumber = trackingNumber;
            ViewBag.SenderName = shipment?.SenderName;
            ViewBag.ReceiverName = shipment?.ReceiverName;
            ViewBag.OriginCity = shipment?.OriginCity;
            ViewBag.DestinationCity = shipment?.DestinationCity;
            ViewBag.CurrentStatus = shipment?.CurrentStatus;

            var dto = new UpdateShipmentTrackingDto
            {
                TrackingNumber = trackingNumber,
                TrackingId = trackingId,        // ← TrackingIndex yerine TrackingId
                EventDate = tracking.EventDate,
                Location = tracking.Location,
                Description = tracking.Description,
                TrackingStatus = tracking.TrackingStatus
            };

            return View(dto);
        }

        // POST: /ShipmentTracking/UpdateTracking
        [HttpPost]
        public async Task<IActionResult> UpdateTracking(UpdateShipmentTrackingDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                var shipment = await _shipmentService
                    .GetShipmentByTrackingNumberAsync(updateDto.TrackingNumber);

                ViewBag.TrackingNumber = updateDto.TrackingNumber;
                ViewBag.SenderName = shipment?.SenderName;
                ViewBag.ReceiverName = shipment?.ReceiverName;
                ViewBag.OriginCity = shipment?.OriginCity;
                ViewBag.DestinationCity = shipment?.DestinationCity;
                ViewBag.CurrentStatus = shipment?.CurrentStatus;

                return View(updateDto);
            }

            await _trackingService.UpdateTrackingAsync(updateDto);
            TempData["Success"] = "Kargo hareketi başarıyla güncellendi!";
            return RedirectToAction("Index", new { trackingNumber = updateDto.TrackingNumber });
        }

        // GET: /ShipmentTracking/DeleteTracking?trackingNumber=TRK-ABC123&trackingId=abc
        public async Task<IActionResult> DeleteTracking(string trackingNumber, string trackingId)
        {
            await _trackingService.DeleteTrackingAsync(trackingNumber, trackingId); // ← değişti
            TempData["Success"] = "Kargo hareketi başarıyla silindi!";
            return RedirectToAction("Index", new { trackingNumber });
        }
    }
}