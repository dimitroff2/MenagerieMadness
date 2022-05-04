using MenagerieMadness.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MenagerieMadness.Repositories
{
    public interface IQuestionRepository
    {
        
        List<Question> GetAllQuestions();

        Question GetById(int id);
        void Add(Question question);

        void Update(Question question);
        void Delete(int id);
    }
}