import { BrowserRouter, Route, Routes } from "react-router-dom";
import classes from "./App.module.css"
import KeyRegisterPage from "../pages/KeyRegisterPage/index";
import LoginPage from "../pages/LoginPage";
import Header from "../modules/Header/Header";
import ProfilePage from "../pages/ProfilePage/ProfilePage";
import Teams from "../pages/Teams/Teams";
import MyTeams from "../pages/MyTeams/MyTeams";

function App() {
  return (
    <div className={classes.App}>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Header />}>
            <Route index element={<ProfilePage />} />
          </Route>
          <Route path="/teams" element={<Header />}>
            <Route index element={<Teams />} />
          </Route>
          <Route path="/my-teams" element={<Header />}>
            <Route index element={<MyTeams />} />
          </Route>
          <Route path="/key-register" element={<KeyRegisterPage />} />
          <Route path="/login" element={<LoginPage />} />
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
