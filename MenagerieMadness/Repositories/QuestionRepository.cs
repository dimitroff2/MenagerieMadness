using MenagerieMadness.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MenagerieMadness.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {

        private readonly IConfiguration _config;

        // The constructor accepts an IConfiguration object as a parameter. This class comes from the ASP.NET framework and is useful for retrieving things out of the appsettings.json file like connection strings.
        public QuestionRepository(IConfiguration config)
        {
            _config = config;
        }

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }
        public List<Question> GetAllQuestions()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                SELECT [id], userId, question, answer, wrong1, wrong2
                    FROM Question 
                       ";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Question> questions = new List<Question>();

                    while (reader.Read())
                    {
                        Question question = new Question
                        {
                            id = reader.GetInt32(reader.GetOrdinal("id")),
                            userId = reader.GetInt32(reader.GetOrdinal("userId")),
                            question = reader.GetString(reader.GetOrdinal("question")),
                            answer = reader.GetString(reader.GetOrdinal("answer")),
                            wrong1 = reader.GetString(reader.GetOrdinal("wrong1")),
                            wrong2 = reader.GetString(reader.GetOrdinal("wrong2")),
                        };

                        questions.Add(question);
                    }

                    reader.Close();

                    return questions;
                }
            }
        }

    }
}

