import React from "react";
import "./App.css";
import { QuestionProvider } from "./providers/QuestionProvider";
import QuestionList from "./components/QuestionList";

function App() {
  return (
    <div className="App">
      <QuestionProvider>
        <QuestionList />
      </QuestionProvider>
    </div>
  );
}

export default App;