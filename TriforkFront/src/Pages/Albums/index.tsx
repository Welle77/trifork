import { useEffect, useState } from "react";
import api from "../../Api/Main";
import { IAlbum } from "../../Api/Main/interfaces";
import AlbumCard from "./AlbumCard";
import { Props } from "./interfaces";

const Albums = (props: Props) => {
  const [albums, setAlbums] = useState<IAlbum[]>([]);

  useEffect(() => {
    const getAlbums = async () => {
      try {
        const { data: albumsData } = await api.get<IAlbum[]>("/albums");
        setAlbums(albumsData.slice(15, 25));
      } catch (error) {
        console.log("40* thrown backend", error);
      }
    };

    getAlbums();
  }, []);

  return (
    <div style={{ margin: "1rem" }}>
      {albums.map((album) => (
        <div key={album.id} style={{ margin: "0.5rem" }}>
          <AlbumCard album={album}></AlbumCard>
        </div>
      ))}
    </div>
  );
};

export default Albums;
