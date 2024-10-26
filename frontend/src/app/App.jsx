import { BrowserRouter, Navigate, Route, Routes } from "react-router-dom";
import classes from "./App.module.css"
import LoginPage from "../pages/LoginPage/index";

function App() {
  return (
    <div className={classes.App}>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<LoginPage/>}/>
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
