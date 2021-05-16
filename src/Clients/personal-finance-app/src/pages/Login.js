import React, { useState } from "react";
import PropTypes from "prop-types";
import Axios from "axios";
export default function Login({ setToken }) {
  const [username, setUserName] = useState();
  const [password, setPassword] = useState();
  let [loginError, setLoginError] = useState();


  const handleSubmit = async (e) => {
    e.preventDefault();
    const token = await await Axios.post(
      "https://localhost:32004/api/Authenticate/login",
      {
        username: username,
        password: password,
      }
    ).then(
      (response) => {
        return response.data;
      },
      (error) => {
        return "err";
      }
    );

    if (token !== "err") {
      setToken(token);
    } else {
      loginError = setLoginError(() => {
        return true;
      });
    }
  };

  return (
    <div className="login-container">
      <div className="login-container-left">
        <h1 className="login-title">Login</h1>
        <h2 className="login-subtitle">Personal Finance Tracker</h2>
      </div>
      <div className="login-container-right">
        <form className="login" onSubmit={handleSubmit}>
          <label>
            <p>Username</p>
            <input
              className="username"
              type="text"
              onChange={(e) => setUserName(e.target.value)}
            />
          </label>
          <label>
            <p>Password</p>
            <input
              className="password"
              type="password"
              onChange={(e) => setPassword(e.target.value)}
            />
          </label>
          <div>
            <button type="submit">Submit</button>
          </div>
        </form>
        <div>
          {loginError ? (
            <h2 style={{ color: "red" }}>Username or password are incorrect</h2>
          ) : null}
        </div>
      </div>
    </div>
  );
}

Login.propTypes = {
  setToken: PropTypes.func.isRequired,
};
