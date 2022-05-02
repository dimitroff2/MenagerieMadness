using MenagerieMadness.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MenagerieMadness.Repositories
{
    public interface IQuestionRepository
    {
        SqlConnection Connection { get; }

        List<Question> GetAllQuestions();
    }
}