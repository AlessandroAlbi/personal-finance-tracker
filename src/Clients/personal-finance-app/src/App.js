import React, { useState } from "react";
import "./App.css";
import AppRouter from "./routes/AppRouter";
import Login from "./pages/Login";
import useToken from './util/useToken';

function App() {
  const { token, setToken } = useToken();

  if(!token) {
    return <Login setToken={setToken} />
  }

  return (
    <div className="App">
      <AppRouter token={token}/>
    </div>
  );
}

export default App;
