import Landing from "../components/Landing/Landing";
import classes from "./App.module.css"

function App() {
  return (
    <div className={classes.App}>
      <Landing className={classes.Landing} header={"HUI"}>Aboba</Landing>
    </div>
  );
}

export default App;
