using MenagerieMadness.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System;
using MenagerieMadness.Repositories;

namespace MenagerieMadness.Repositories
{
    public class QuestionRepository : BaseRepository, IQuestionRepository
    {

        public QuestionRepository(IConfiguration config) : base(config) { }

        // The constructor accepts an IConfiguration object as a parameter. This class comes from the ASP.NET framework and is useful for retrieving things out of the appsettings.json file like connection strings.


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

        //get question by id
        public Question GetById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT [id], userId, question, answer, wrong1, wrong2 
                          FROM Question
                         WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    var reader = cmd.ExecuteReader();

                    Question newQuestion = null;
                    if (reader.Read())
                    {
                        newQuestion = new Question()
                        {
                            id = reader.GetInt32(reader.GetOrdinal("id")),
                            userId = reader.GetInt32(reader.GetOrdinal("userId")),
                            question = reader.GetString(reader.GetOrdinal("question")),
                            answer = reader.GetString(reader.GetOrdinal("answer")),
                            wrong1 = reader.GetString(reader.GetOrdinal("wrong1")),
                            wrong2 = reader.GetString(reader.GetOrdinal("wrong2")),
                        };

                        reader.Close();


                    }
                    return newQuestion;
                }
            }

        }
        public void Add(Question question)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO Question ( userId, question, answer, wrong1, wrong2)
                        OUTPUT INSERTED.ID
                        VALUES ( @userId, @question, @wrong1, @wrong2)";
                    cmd.Parameters.AddWithValue("@userId", question.userId);
                    cmd.Parameters.AddWithValue("@question", question.question);
                    cmd.Parameters.AddWithValue("@answer", question.answer);
                    cmd.Parameters.AddWithValue("@wrong1", question.wrong1);
                    cmd.Parameters.AddWithValue("@wrong2", question.wrong2);


                    question.id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Update(Question question)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                       UPDATE Question
                                        SET userId = @userId,
                                            question = @question,
                                            answer= @answer,
                                            wrong1 = @wrong1,
                                            wrong2 = @wrong2
                                        WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", question.id);
                    cmd.Parameters.AddWithValue("@userId", question.userId);
                    cmd.Parameters.AddWithValue("@answer", question.answer);
                    cmd.Parameters.AddWithValue("@wrong1", question.wrong1);
                    cmd.Parameters.AddWithValue("@wrong2", question.wrong2);

                    cmd.ExecuteNonQuery();
                }
            }





        }

        public void Delete(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Question WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

