import React, { useState, useEffect } from "react";
import MainChart from "../components/MainChart";
import AccountCard from "../components/AccountCard";
import TotalRecap from "../components/TotalRecap";

import Axios from "axios";

export default function Dashboard({token}) {
  // useState hooks that contains the data of accounts
  const [accounts, setAccounts] = useState([]);

  // runned when component is rendered
  useEffect(() => {
    // errrori nel passarre il token vedre come fare
    Axios.get("http://localhost:32001/api/Accounts", { headers: {"Authorization" : `Bearer ${token}`} }).then(response => {
      setAccounts(response.data);
    });
  }, []);

  return (
    <div className="Dashboard">
      <h1 className="Page-title">Dashboard 2021</h1>
      <div className="Total-recap-container Dashboard-component">
        <TotalRecap />
      </div>
      <div className="Main-chart-container Dashboard-component">
        <MainChart />
      </div>
      <div className="Accounts-container">
        {accounts.map((val) => {
          return (
            <div className="Account-container Dashboard-component">
              <AccountCard name={val.name}/>
            </div>
          );
        })}
      </div>
    </div>
  );
}
