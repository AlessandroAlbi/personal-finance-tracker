import React, { useState } from "react";
import "./App.css";
import AppRouter from "./routes/AppRouter";
import Login from "./pages/Login";

function App() {
  const [token, setToken] = useState();

  if(!token) {
    return <Login setToken={setToken} />
  }

  return (
    <div className="App">
      <AppRouter />
    </div>
  );
}

export default App;
