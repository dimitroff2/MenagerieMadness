using MenagerieMadness.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MenagerieMadness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : Controller
    {
        private readonly IQuestionRepository _questionRepo;

        public QuestionController(IQuestionRepository questionRepository)
        {
            _questionRepo = questionRepository;
        }
        //https://localhost:5001/api/questions/
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_questionRepo.GetAllQuestions());
        }
    }
}
