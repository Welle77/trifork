import AppBar from "@mui/material/AppBar";
import Box from "@mui/material/Box";
import Toolbar from "@mui/material/Toolbar";
import NavigationButton from "./NavigationButton";
import { useHistory } from "react-router";

const NavigationBar = () => {
  const { push } = useHistory();

  return (
    <Box sx={{ flexGrow: 1 }}>
      <AppBar position="static">
        <Toolbar variant="dense">
          <NavigationButton onClick={() => push("/")} text="Posts" />
          <NavigationButton onClick={() => push("/albums")} text="Albums" />
        </Toolbar>
      </AppBar>
    </Box>
  );
};

export default NavigationBar;
