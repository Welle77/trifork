import { Card, CardContent, Typography } from "@mui/material";
import { Props } from "./interfaces";

const Comment = (props: Props) => {
  const { body, name, email } = props.comment;

  const headline = `${name} by ${email}`;
  return (
    <Card style={{ backgroundColor: "smokewhite" }}>
      <CardContent>
        <Typography variant="body2" fontWeight="bold">
          {headline}
        </Typography>
        <Typography variant="body2">{body}</Typography>
      </CardContent>
    </Card>
  );
};

export default Comment;
