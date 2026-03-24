using DatabaseMastery.TransportMongoDb.Services.TestimonialServices;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseMastery.TransportMongoDb.ViewComponents.DefaultComponents
{
    public class _DefaultTestimonialComponentPartial:ViewComponent
    {
        private readonly ITestimonialService _TestimonialService;

        public _DefaultTestimonialComponentPartial(ITestimonialService TestimonialService)
        {
            _TestimonialService = TestimonialService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _TestimonialService.GetAllTestimonialAsync();
            return View(values);
        }
    }
}
