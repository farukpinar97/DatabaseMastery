using DatabaseMastery.TransportMongoDb.Services.ProjectSectionServices;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseMastery.TransportMongoDb.ViewComponents.DefaultComponents
{
    public class _DefaultWhatWeHaveDoneComponentPartial:ViewComponent
    {
        private readonly IProjectSectionService _ProjectSectionService;

        public _DefaultWhatWeHaveDoneComponentPartial(IProjectSectionService ProjectSectionService)
        {
            _ProjectSectionService = ProjectSectionService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _ProjectSectionService.GetAllProjectSectionAsync();
            return View(values);
        }
    }
}
