import { BrowserRouter, Route, Routes } from "react-router-dom";
import classes from "./App.module.css"
import KeyRegisterPage from "../pages/KeyRegisterPage/index";
import LoginPage from "../pages/LoginPage";
import Header from "../modules/Header/Header";
import HomePage from "../pages/HomePage/HomePage/HomePage";
import RegisterPage from "../pages/RegisterPage";

function App() {
  return (
    <div className={classes.App}>
      <BrowserRouter>
        <Routes>
          <Route path="/user" element={<Header/>}>
            <Route index element={<HomePage/>}/>
          </Route>
          <Route path="/key-register" element={<KeyRegisterPage/>}/>
          <Route path="/register" element={<RegisterPage/>}/>
          <Route path="/" element={<LoginPage/>}/>
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
