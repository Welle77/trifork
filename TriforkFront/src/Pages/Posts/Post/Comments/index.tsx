import { Props } from "./interfaces";
import Comment from "./Comment";

const Comments = (props: Props) => {
  return (
    <div style={{ justifyContent: "center" }}>
      {props.comments.map((comment) => (
        <Comment key={comment.id} comment={comment}></Comment>
      ))}
    </div>
  );
};

export default Comments;
