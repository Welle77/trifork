import { RouteProps } from "react-router-dom";
import Albums from "../../Pages/Albums";
import AlbumPage from "../../Pages/Albums/AlbumPage";
import NotFound from "../../Pages/NotFound";
import Posts from "../../Pages/Posts";

export interface AuthenticatedRouteProps extends RouteProps {
  isPrivate: boolean;
}

const publicRoutes: AuthenticatedRouteProps[] = [
  {
    path: "/",
    component: Posts,
    isPrivate: false,
    exact: true,
  },
  {
    path: "/albums",
    component: Albums,
    isPrivate: false,
    exact: true,
  },
  {
    path: "/albums/:id",
    component: AlbumPage,
    isPrivate: false,
    exact: true,
  },
];

const privateRoutes: AuthenticatedRouteProps[] = [
  {
    path: "/*",
    component: NotFound,
    isPrivate: true,
    exact: true,
  },
];

export const routes = publicRoutes.concat(privateRoutes);
