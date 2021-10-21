import { useEffect, useState } from "react";
import api from "../../Api/main";
import { IPost, Props } from "./interfaces";
import Post from "./Post";

const Posts = (props: Props) => {
  const [posts, setPosts] = useState<IPost[]>([]);

  useEffect(() => {
    const getPosts = async () => {
      const { data } = await api.get<IPost[]>("/posts");
      setPosts(data);
    };

    getPosts();
  }, []);

  return (
    <div style={{ justifyContent: "center" }}>
      {posts.map((post) => (
        <div style={{ margin: "1rem" }}>
          <Post post={post}></Post>
        </div>
      ))}
    </div>
  );
};

export default Posts;
