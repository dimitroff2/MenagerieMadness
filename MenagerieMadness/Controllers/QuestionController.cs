using MenagerieMadness.Models;
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
        //get by Id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var question = _questionRepo.GetById(id);
            if (question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }

        [HttpPost]
        public IActionResult Post(Question question)
        {
            _questionRepo.Add(question);
            
            return NoContent();
        }

        // update a question

        [HttpPut("{id}")]
        public IActionResult Put(int id, Question question)
        {
            if (id != question.id)
            {
                return BadRequest();
            }
            _questionRepo.Update(question);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _questionRepo.Delete(id);
            return NoContent();
        }
    }
}
