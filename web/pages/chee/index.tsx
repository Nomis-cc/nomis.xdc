import { CheePage } from "../../chee";

import { createClient, configureChains, WagmiConfig, Chain } from "wagmi";

import { publicProvider } from "wagmi/providers/public";

import { CoinbaseWalletConnector } from "wagmi/connectors/coinbaseWallet";
import { InjectedConnector } from "wagmi/connectors/injected";
import { MetaMaskConnector } from "wagmi/connectors/metaMask";
import { WalletConnectConnector } from "wagmi/connectors/walletConnect";

export default function Page() {
  const celo: Chain = {
    id: 42220,
    network: "celo",
    name: "Celo",
    nativeCurrency: {
      name: "Celo",
      symbol: "CELO",
      decimals: 18,
    },
    rpcUrls: {
      default: {
        http: ["https://forno.celo.org	"],
      },
      public: {
        http: ["https://forno.celo.org	"],
      },
    },
    blockExplorers: {
      default: {
        name: "Celo Explorer",
        url: "https://explorer.celo.org",
      },
    },
  };
  const { chains, provider, webSocketProvider } = configureChains(
    [celo],
    [publicProvider()]
  );

  const client = createClient({
    provider,
    webSocketProvider,
    autoConnect: true,
    connectors: [
      new InjectedConnector({ chains, options: { name: "Extension" } }),
      new WalletConnectConnector({
        chains,
        options: {
          qrcode: true,
        },
      }),
      new CoinbaseWalletConnector({
        chains,
        options: {
          appName: "Nomis",
          reloadOnDisconnect: false,
          darkMode: true,
        },
      }),
      new MetaMaskConnector({ chains }),
    ],
  });

  return (
    <WagmiConfig client={client}>
      <CheePage />
    </WagmiConfig>
  );
}
