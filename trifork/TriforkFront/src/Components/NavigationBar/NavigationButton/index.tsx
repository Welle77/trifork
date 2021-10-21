import { Typography, Button } from "@mui/material";
import { Props } from "./interfaces";

const NavigationButton = (props: Props) => {
  const { text, onClick } = props;

  return (
    <Button color="secondary" onClick={onClick}>
      <Typography variant="h6">{text}</Typography>
    </Button>
  );
};

export default NavigationButton;
