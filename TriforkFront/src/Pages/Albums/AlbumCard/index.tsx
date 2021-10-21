import { Button, Card, CardContent, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import { useHistory } from "react-router";
import api from "../../../Api/Main";
import { IUser } from "../../../Api/Main/interfaces";
import { Props } from "./interfaces";

const AlbumCard = (props: Props) => {
  const { title, id, userId } = props.album;
  const [user, setUser] = useState<IUser>();

  useEffect(() => {
    const getUser = async () => {
      try {
        const { data, status } = await api.get<IUser>(`/users/${userId}`);
        if (status === 200) setUser(data);
      } catch (error) {
        console.log("40* thrown backend", error);
      }
    };
    getUser();
  }, [userId]);

  const { push } = useHistory();

  const onClick = () => {
    push(`albums/${id}`);
  };

  return (
    <Card variant="outlined">
      <CardContent>
        <div style={{ display: "flex", justifyContent: "space-between" }}>
          <div>
            <Typography variant="h5">{title}</Typography>
            <Typography variant="body1">{`By ${user?.name}`}</Typography>
          </div>
          <Button onClick={onClick}>GO TO ALBUM</Button>
        </div>
      </CardContent>
    </Card>
  );
};

export default AlbumCard;
