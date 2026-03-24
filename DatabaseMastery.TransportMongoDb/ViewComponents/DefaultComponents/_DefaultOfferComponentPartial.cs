using DatabaseMastery.TransportMongoDb.Services.OfferServices;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseMastery.TransportMongoDb.ViewComponents.DefaultComponents
{
    public class _DefaultOfferComponentPartial:ViewComponent
    {
        private readonly IOfferService _OfferService;

        public _DefaultOfferComponentPartial(IOfferService OfferService)
        {
            _OfferService = OfferService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _OfferService.GetAllOfferAsync();
            return View(values);
        }
    }
}
