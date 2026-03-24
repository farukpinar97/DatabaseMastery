using DatabaseMastery.TransportMongoDb.Dtos.OfferDtos;
using DatabaseMastery.TransportMongoDb.Services.OfferServices;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseMastery.TransportMongoDb.Controllers
{
    public class OfferController : Controller
    {
        private readonly IOfferService _OfferService;

        public OfferController(IOfferService OfferService)
        {
            _OfferService = OfferService;
        }

        public async Task<IActionResult> OfferList()
        {
            var values = await _OfferService.GetAllOfferAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateOffer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOffer(CreateOfferDto createOfferDto)
        {
            await _OfferService.CreateOfferAsync(createOfferDto);
            return RedirectToAction("OfferList");
        }

        public async Task<IActionResult> DeleteOffer(string id)
        {
            await _OfferService.DeleteOfferAsync(id);
            return RedirectToAction("OfferList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateOffer(string id)
        {
            var value = await _OfferService.GetOfferByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOffer(UpdateOfferDto updateOfferDto)
        {
            await _OfferService.UpdateOfferAsync(updateOfferDto);
            return RedirectToAction("OfferList");
        }
    }
}
