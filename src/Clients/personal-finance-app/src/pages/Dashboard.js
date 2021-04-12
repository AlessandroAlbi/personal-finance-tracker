import React from "react";
import MainChart from "../components/MainChart";
import AccountCard from "../components/AccountCard";
import TotalRecap from "../components/TotalRecap";

export default function Dashboard() {
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
        <div className="Account-container Dashboard-component">
          <AccountCard />
        </div>
        <div className="Account-container Dashboard-component">
          <AccountCard />
        </div>
        <div className="Account-container Dashboard-component">
          <AccountCard />
        </div>
        <div className="Account-container Dashboard-component">
          <AccountCard />
        </div>
      </div>
    </div>
  );
}
