import { Card, CardContent, Typography } from "@mui/material";
import { Props } from "./interface";

const Post = (props: Props) => {
  const { body, title } = props.post;

  return (
    <Card variant="outlined">
      <CardContent>
        <Typography variant="h5">{title}</Typography>
        <Typography variant="body1">{body}</Typography>
      </CardContent>
    </Card>
  );
};

export default Post;
