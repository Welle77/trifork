import { ImageList, ImageListItem, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import api from "../../../Api/Main";
import { IPhoto } from "../../../Api/Main/interfaces";

const AlbumPage = () => {
  const { id } = useParams<{ id: string }>();
  const [photos, setPhotos] = useState<IPhoto[]>();

  useEffect(() => {
    const getPhotos = async () => {
      const { data } = await api.get<IPhoto[]>(`photos?albumId=${id}`);
      setPhotos(data);
    };
    getPhotos();
  }, [id]);

  return (
    <div>
      {photos?.length ? (
        <ImageList cols={6}>
          {photos.map(({ title, url, id }) => (
            <ImageListItem key={id}>
              <img
                src={`${url}`}
                srcSet={`${url}`}
                alt={title}
                loading="lazy"
              />
            </ImageListItem>
          ))}
        </ImageList>
      ) : (
        <div>
          <Typography>NO PHOTOS ARE IN THIS ALMBUM</Typography>
        </div>
      )}
    </div>
  );
};

export default AlbumPage;
