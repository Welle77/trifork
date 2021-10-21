import { Card, CardContent, Typography } from "@mui/material";
import { Props } from "./interfaces";

const Comment = (props: Props) => {
  const { body, name, email } = props.comment;

  return (
    <Card style={{ backgroundColor: "smokewhite" }}>
      <CardContent>
        <Typography variant="body1" fontWeight="bold">
          {name}
        </Typography>
        <Typography variant="body2">{`By ${email}`}</Typography>
        <Typography variant="body2">{body}</Typography>
      </CardContent>
    </Card>
  );
};

export default Comment;
