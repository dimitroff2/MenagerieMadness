import React from "react";
import { Card, CardImg, CardBody } from "reactstrap";

const Question = ({ question }) => {
  return (
<Card className="m-4">
<p className="text-left px-2">Posted by: {question.userId}</p>
<CardBody>
        <p>
          <strong>{question.question}</strong>
        </p>
        <p>{question.answer}</p>
        <p>{question.wrong1}</p>
        <p>{question.wrong2}</p>
      </CardBody>
    </Card>
  
  );
};

export default Question;