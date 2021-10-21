import { Props } from "./interfaces";
import { BrowserRouter, Switch } from "react-router-dom";
import Routes from "./Routes";
import { routes } from "./Routes/routes";

const Router = (props: Props) => {
  return (
    <BrowserRouter>
      {props.children}
      <Switch>
        {routes.map(({ path, component, isPrivate, exact }, index) => (
          <Routes
            key={index}
            path={path}
            component={component}
            isPrivate={isPrivate}
            exact={exact}
          />
        ))}
      </Switch>
    </BrowserRouter>
  );
};

export default Router;
