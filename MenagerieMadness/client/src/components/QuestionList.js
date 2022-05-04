import React, { useContext, useEffect } from "react";
import { QuestionContext } from "../providers/QuestionProvider";
import Question from "./Question";


const QuestionList = () => {
  const { questions, getAllQuestions } = useContext(QuestionContext);

  useEffect(() => {
    getAllQuestions();
  }, []);

  return (
    <div className="container">
      {questions.map((question) => (
        <div key={question.id}>
          
          <p>
            <strong>{question.question} ?</strong>
            <p>{question.answer}</p>
            <p>{question.wrong1}</p>
            <p>{question.wrong2}</p>
            <p>{question.userId}</p>
          </p>
          
        </div>
      ))}
    </div>
  );
};

export default QuestionList;