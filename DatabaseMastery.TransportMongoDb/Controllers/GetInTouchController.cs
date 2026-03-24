using DatabaseMastery.TransportMongoDb.Dtos.GetInTouchDtos;
using DatabaseMastery.TransportMongoDb.Services.GetInTouchServices;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseMastery.TransportMongoDb.Controllers
{
    public class GetInTouchController : Controller
    {
        private readonly IGetInTouchService _GetInTouchService;

        public GetInTouchController(IGetInTouchService GetInTouchService)
        {
            _GetInTouchService = GetInTouchService;
        }

        public async Task<IActionResult> GetInTouchList()
        {
            var values = await _GetInTouchService.GetAllGetInTouchAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateGetInTouch()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateGetInTouch(CreateGetInTouchDto createGetInTouchDto)
        {
            await _GetInTouchService.CreateGetInTouchAsync(createGetInTouchDto);
            return RedirectToAction("GetInTouchList");
        }

        public async Task<IActionResult> DeleteGetInTouch(string id)
        {
            await _GetInTouchService.DeleteGetInTouchAsync(id);
            return RedirectToAction("GetInTouchList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateGetInTouch(string id)
        {
            var value = await _GetInTouchService.GetGetInTouchByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateGetInTouch(UpdateGetInTouchDto updateGetInTouchDto)
        {
            await _GetInTouchService.UpdateGetInTouchAsync(updateGetInTouchDto);
            return RedirectToAction("GetInTouchList");
        }
    }
}
