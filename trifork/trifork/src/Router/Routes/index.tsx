import { Redirect, Route } from "react-router";
import { AuthenticatedRouteProps } from "./routes";

const Routes = (props: AuthenticatedRouteProps) => {
  const { isPrivate, component: Component, exact, path, ...rest } = props;

  //This is normally done to check for login tokens and stuff
  const isRoutePrivate = isPrivate;

  return (
    <Route
      exact={exact}
      path={path}
      render={(props) =>
        isRoutePrivate ? (
          <Redirect to={{ pathname: "/" }} />
        ) : Component ? (
          <Component {...props} />
        ) : null
      }
      {...rest}
    />
  );
};

export default Routes;
