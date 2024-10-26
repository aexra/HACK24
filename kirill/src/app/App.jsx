import { BrowserRouter, Route, Routes } from "react-router-dom";
import classes from "./App.module.css"
import LoginPage from "../pages/LoginPage/index";

function App() {
  return (
    <div className={classes.App}>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<LoginPage />} />
          <Route path="/challenges" element={<LoginPage />} />
          <Route path="/activity-log" element={<LoginPage />} />
          <Route path="/leaderboard" element={<LoginPage />} />
          <Route path="/teams" element={<LoginPage />} />
          <Route path="/profile" element={<LoginPage />} />
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
