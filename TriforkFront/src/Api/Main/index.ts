import axios from "axios";

const api = axios.create({
  baseURL:
    process.env.NODE_ENV === "development"
      ? "https://jsonplaceholder.typicode.com"
      : "https://jsonplaceholder.typicode.com",
});

//Other initilazations and such.

export default api;
