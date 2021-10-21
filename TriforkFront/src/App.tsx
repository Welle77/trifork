import Router from "./Router";
import { ThemeProvider } from "@mui/material";
import { themeTrifork } from "./Themes/themeTrifork";
import NavigationBar from "./Components/NavigationBar";

function App() {
  return (
    <ThemeProvider theme={themeTrifork}>
      <Router>
        <NavigationBar />
      </Router>
    </ThemeProvider>
  );
}

export default App;
