import React, { useState } from "react";
import PropTypes from "prop-types";

async function loginUser(username, password) {
  var details = {
    username: username,
    password: password,
    grant_type: "password",
    client_id: "react-app",
    scope: "openid",
  };

  var formBody = [];
  for (var property in details) {
    var encodedKey = encodeURIComponent(property);
    var encodedValue = encodeURIComponent(details[property]);
    formBody.push(encodedKey + "=" + encodedValue);
  }
  formBody = formBody.join("&");

  return fetch(
    "http://localhost:8080/auth/realms/personal-finance-tracker/protocol/openid-connect/token",
    {
      method: "POST",
      headers: {
        "Content-Type": "application/x-www-form-urlencoded;charset=UTF-8",
      },
      body: formBody,
    }
  )
    .then(function (response) {
      if (!response.ok) {
        throw Error(response.statusText);
      }
      return response.json();
    })
    .catch((err) => "err");
}

export default function Login({ setToken }) {
  const [username, setUserName] = useState();
  const [password, setPassword] = useState();

  const handleSubmit = async (e) => {
    e.preventDefault();
    const token = await loginUser(username, password);

    if (token !== "err") {
      setToken(token);
    } else {
      window.location.reload();
    }
  };

  return (
    <div className="login-container">
      <div className="login-container-left">
        <h1 className="login-title">Login</h1>
        <h2 className="login-subtitle">
          Personal Finance Tracker
        </h2>
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
            <button type="submit">
              Submit
            </button>
          </div>
        </form>
      </div>
    </div>
  );
}

Login.propTypes = {
  setToken: PropTypes.func.isRequired,
};
