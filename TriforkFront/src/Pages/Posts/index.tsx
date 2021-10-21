import { useEffect, useState } from "react";
import api from "../../Api/Main";
import { IPost } from "../../Api/Main/interfaces";
import { Props } from "./interfaces";
import Post from "./Post";

const Posts = (props: Props) => {
  const [posts, setPosts] = useState<IPost[]>([]);

  useEffect(() => {
    const getPosts = async () => {
      const { data } = await api.get<IPost[]>("/posts");
      setPosts(data.slice(12, 22));
    };

    getPosts();
  }, []);

  return (
    <div style={{ justifyContent: "center" }}>
      {posts.map((post) => (
        <Post key={post.id} post={post}></Post>
      ))}
    </div>
  );
};

export default Posts;
