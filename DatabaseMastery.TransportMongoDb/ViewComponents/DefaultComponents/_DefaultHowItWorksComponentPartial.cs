using DatabaseMastery.TransportMongoDb.Services.HowItWorkServices;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseMastery.TransportMongoDb.ViewComponents.DefaultComponents
{
    public class _DefaultHowItWorksComponentPartial:ViewComponent
    {
        private readonly IHowItWorkService _HowItWorkService;

        public _DefaultHowItWorksComponentPartial(IHowItWorkService HowItWorkService)
        {
            _HowItWorkService = HowItWorkService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _HowItWorkService.GetAllHowItWorkAsync();
            return View(values);
        }
    }
}
