import { BrowserRouter, Navigate, Route, Routes } from "react-router-dom";
import classes from "./App.module.css"
import KeyRegisterPage from "../pages/KeyRegisterPage/index";
import LoginPage from "../pages/LoginPage";

function App() {
  return (
    <div className={classes.App}>
      <BrowserRouter>
        <Routes>
          <Route path="/key-register" element={<KeyRegisterPage/>}/>
          <Route path="/login" element={<LoginPage/>}/>
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
