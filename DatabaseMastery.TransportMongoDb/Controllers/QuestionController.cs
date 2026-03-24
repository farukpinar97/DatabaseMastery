using DatabaseMastery.TransportMongoDb.Dtos.QuestionDtos;
using DatabaseMastery.TransportMongoDb.Services.QuestionServices;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseMastery.TransportMongoDb.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionService _QuestionService;

        public QuestionController(IQuestionService QuestionService)
        {
            _QuestionService = QuestionService;
        }

        public async Task<IActionResult> QuestionList()
        {
            var values = await _QuestionService.GetAllQuestionAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateQuestion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestion(CreateQuestionDto createQuestionDto)
        {
            await _QuestionService.CreateQuestionAsync(createQuestionDto);
            return RedirectToAction("QuestionList");
        }

        public async Task<IActionResult> DeleteQuestion(string id)
        {
            await _QuestionService.DeleteQuestionAsync(id);
            return RedirectToAction("QuestionList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateQuestion(string id)
        {
            var value = await _QuestionService.GetQuestionByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuestion(UpdateQuestionDto updateQuestionDto)
        {
            await _QuestionService.UpdateQuestionAsync(updateQuestionDto);
            return RedirectToAction("QuestionList");
        }
    }
}
