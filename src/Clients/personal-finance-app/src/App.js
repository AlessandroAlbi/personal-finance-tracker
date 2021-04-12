import React, { useState } from "react";
import "./App.css";
import { BrowserRouter, Switch, Route, Link } from "react-router-dom";
import Dashboard from "./pages/Dashboard";
import Movements from "./pages/Movements";

function App() {
  return (
      <BrowserRouter>
        <div className="App">
          <header className="App-header">
            <h1 className="App-title">Personal finance tracker</h1>
            <nav className="Main-nav">
              <ul className="Main-nav-list">
                <Link style={{ color: "white" }} to="/">
                  <li>Dashboard</li>
                </Link>
                <Link style={{ color: "white" }} to="/movements">
                  <li>Movements</li>
                </Link>
              </ul>
            </nav>
          </header>
          <main className="Main-container">
            <Switch>
              <Route exact path="/" component={Dashboard} />
              <Route path="/movements" component={Movements} />
            </Switch>
          </main>
        </div>
      </BrowserRouter>
  );
}

export default App;
