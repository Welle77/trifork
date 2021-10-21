import styled from "@emotion/styled";
import {
  Button,
  Card,
  CardActions,
  CardContent,
  Collapse,
  Link,
  Typography,
} from "@mui/material";
import { useEffect, useState } from "react";
import api from "../../../Api/Main";
import { IComment, IUser } from "../../../Api/Main/interfaces";
import Comments from "./Comments";
import { Props } from "./interfaces";

const ExpandMore = styled((props: any) => {
  const { expand, ...other } = props;
  return <Button {...other} />;
})(({ theme }) => ({
  marginLeft: "auto",
  transition: theme.transitions.create("transform", {
    duration: theme.transitions.duration.short,
  }),
}));

const Post = (props: Props) => {
  const { body, title, userId, id } = props.post;

  const [user, setUser] = useState<IUser>();
  const [comments, setComments] = useState<IComment[]>([]);
  const [expanded, setExpanded] = useState(false);

  useEffect(() => {
    const getPostData = async () => {
      const { data: user } = await api.get<IUser>(`/users/${userId}`);
      setUser(user);

      const { data: comment } = await api.get<IComment[]>(
        `posts/${id}/comments`
      );
      setComments(comment);
    };

    getPostData();
  }, [id, userId]);

  const handleExpandClick = () => {
    setExpanded(!expanded);
  };

  return (
    <Card variant="outlined">
      <CardContent>
        <Typography variant="h5">{title}</Typography>
        <Link href="#" underline="hover" color="black">
          {`By  ${user?.name}`}
        </Link>
        <Typography variant="body1">{body}</Typography>
      </CardContent>
      <CardActions disableSpacing>
        <ExpandMore
          expand={expanded}
          onClick={handleExpandClick}
          aria-expanded={expanded}
          aria-label="show more"
        >
          <Typography variant="button">
            {expanded ? "Close Comments" : "Open Comments"}
          </Typography>
        </ExpandMore>
      </CardActions>
      <Collapse in={expanded} timeout="auto" unmountOnExit>
        <Comments comments={comments}></Comments>
      </Collapse>
    </Card>
  );
};

export default Post;
