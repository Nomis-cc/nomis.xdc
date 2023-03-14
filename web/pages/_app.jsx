import { ThemeProvider } from "next-themes";
import { createContext, useState } from "react";
import "../styles/index.scss";
import { GoogleAnalytics } from "nextjs-google-analytics";

export const WalletContext = createContext();

export default function App({ Component, pageProps }) {
  const [wallet, setWallet] = useState();

  return (
    <WalletContext.Provider value={{ wallet, setWallet }}>
      <ThemeProvider>
        <GoogleAnalytics trackPageViews gaMeasurementId={"G-F44FK1J7E1"} />
        <Component {...pageProps} />
      </ThemeProvider>
    </WalletContext.Provider>
  );
}
