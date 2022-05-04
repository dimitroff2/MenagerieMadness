import React, { useState } from "react";

export const QuestionContext = React.createContext();

export const QuestionProvider = (props) => {



  const [questions, setQuestions] = useState([]);

  const getAllQuestions = () => {
    return fetch("https://localhost:44361/api/Question")
      .then((res) => res.json())
      .then(setQuestions);
  };

  const addQuestion = (question) => {
    return fetch("/api/post", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(question),
    });
  };

  return (
    <QuestionContext.Provider value={{ questions, getAllQuestions, addQuestion }}>
      {props.children}
    </QuestionContext.Provider>
  );
};