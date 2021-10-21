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
    <div style={{ margin: "1rem" }}>
      {posts.map((post) => (
        <div key={post.id} style={{ margin: "0.5rem" }}>
          <Post post={post}></Post>
        </div>
      ))}
    </div>
  );
};

export default Posts;
