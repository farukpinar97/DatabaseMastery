using DatabaseMastery.TransportMongoDb.Dtos.ProjectSectionDtos;
using DatabaseMastery.TransportMongoDb.Services.ProjectSectionServices;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseMastery.TransportMongoDb.Controllers
{
    public class ProjectSectionController : Controller
    {
        private readonly IProjectSectionService _ProjectSectionService;

        public ProjectSectionController(IProjectSectionService ProjectSectionService)
        {
            _ProjectSectionService = ProjectSectionService;
        }

        public async Task<IActionResult> ProjectSectionList()
        {
            var values = await _ProjectSectionService.GetAllProjectSectionAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateProjectSection()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProjectSection(CreateProjectSectionDto createProjectSectionDto)
        {
            await _ProjectSectionService.CreateProjectSectionAsync(createProjectSectionDto);
            return RedirectToAction("ProjectSectionList");
        }

        public async Task<IActionResult> DeleteProjectSection(string id)
        {
            await _ProjectSectionService.DeleteProjectSectionAsync(id);
            return RedirectToAction("ProjectSectionList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProjectSection(string id)
        {
            var value = await _ProjectSectionService.GetProjectSectionByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProjectSection(UpdateProjectSectionDto updateProjectSectionDto)
        {
            await _ProjectSectionService.UpdateProjectSectionAsync(updateProjectSectionDto);
            return RedirectToAction("ProjectSectionList");
        }
    }
}
