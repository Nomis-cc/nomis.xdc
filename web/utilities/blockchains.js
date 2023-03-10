export const blockchains = [
  {
    group: "finance",
    groupLabel: "Finance",
    item: "XDC Network",
    slug: "xdc",
    apiSlug: "xdc",
    icon: "/blockchains/xdc.svg",
    placeholder: "0x... or xdc... address",
    coin: "XDC",
    hide: false,
    chainId: 50,
    networkData: {
      chainId: "0x32",
      chainName: "XinFin XDC Network",
      nativeCurrency: {
        name: "XDC",
        symbol: "XDC",
        decimals: 18,
      },
      rpcUrls: ["https://rpc.xinfin.network"],
      blockExplorerUrls: ["https://explorer.xinfin.network"],
    },
  },
];
