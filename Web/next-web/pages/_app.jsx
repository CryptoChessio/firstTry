import "../styles/globals.css";
import Layout from "../components/layout";
import Moralis from "moralis";
import { Provider } from "react-redux";
import { store } from "../redux/store";
function MyApp({ Component, pageProps }) {
  // Moralis.initialize("XdXC23U4SiRFenvHOPrk5Mtp8arlfIbMtdAI0UpO"); // Application id from moralis.io
  // Moralis.serverURL = "https://kqv1hqmigpho.usemoralis.com:2053/server"; //Server url from moralis.io
  return (
    <Provider store={store}>
      <Layout>
        <Component {...pageProps} />
      </Layout>
    </Provider>
  );
}

export default MyApp;
