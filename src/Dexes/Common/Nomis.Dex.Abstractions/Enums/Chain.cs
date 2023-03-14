// ------------------------------------------------------------------------------------------------------
// <copyright file="Chain.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

// ReSharper disable InconsistentNaming

namespace Nomis.Dex.Abstractions.Enums
{
    /// <summary>
    /// Blockchain.
    /// </summary>
    public enum Chain :
        long
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,

        /// <summary>
        /// Ethereum Mainnet.
        /// </summary>
        Ethereum = 1,

        /// <summary>
        /// Optimism.
        /// </summary>
        Optimism = 10,

        /// <summary>
        /// Flare Mainnet.
        /// </summary>
        Flare = 14,

        /// <summary>
        /// Songbird Canary-Network.
        /// </summary>
        Songbird = 19,

        /// <summary>
        /// Cronos Mainnet Beta.
        /// </summary>
        Cronos = 25,

        /// <summary>
        /// RSK Mainnet.
        /// </summary>
        RSK = 30,

        /// <summary>
        /// Telos.
        /// </summary>
        Telos = 40,

        /// <summary>
        /// XinFin XDC Network.
        /// </summary>
        XDC = 50,

        /// <summary>
        /// CoinEx Smart Chain Mainnet.
        /// </summary>
        CSC = 52,

        /// <summary>
        /// Binance Smart Chain Mainnet.
        /// </summary>
        BSC = 56,

        /// <summary>
        /// Ethereum Classic Mainnet.
        /// </summary>
        EthereumClassic = 61,

        /// <summary>
        /// OKXChain Mainnet.
        /// </summary>
        OKXChain = 66,

        /// <summary>
        /// POA Network Core.
        /// </summary>
        POACore = 99,

        /// <summary>
        /// Gnosis.
        /// </summary>
        Gnosis = 100,

        /// <summary>
        /// Velas EVM Mainnet.
        /// </summary>
        Velas = 106,

        /// <summary>
        /// Fuse Mainnet.
        /// </summary>
        Fuse = 122,

        /// <summary>
        /// Huobi ECO Chain Mainnet.
        /// </summary>
        Huobi = 128,

        /// <summary>
        /// Polygon Mainnet.
        /// </summary>
        Polygon = 137,

        /// <summary>
        /// BitTorrent Chain Mainnet.
        /// </summary>
        BitTorrent = 199,

        /// <summary>
        /// Fantom Opera.
        /// </summary>
        Fantom = 250,

        /// <summary>
        /// Boba Network.
        /// </summary>
        Boba = 288,

        /// <summary>
        /// Shiden.
        /// </summary>
        Shiden = 336,

        /// <summary>
        /// Astar.
        /// </summary>
        Astar = 592,

        /// <summary>
        /// Karura Network.
        /// </summary>
        Karura = 686,

        /// <summary>
        /// Acala Network.
        /// </summary>
        Acala = 787,

        /// <summary>
        /// Metis Andromeda Mainnet.
        /// </summary>
        Metis = 1088,

        /// <summary>
        /// Step Network.
        /// </summary>
        Step = 1234,

        /// <summary>
        /// Moonbeam.
        /// </summary>
        Moonbeam = 1284,

        /// <summary>
        /// Cube Chain Mainnet.
        /// </summary>
        Cube = 1818,

        /// <summary>
        /// Dogechain Mainnet.
        /// </summary>
        Dogechain = 2000,

        /// <summary>
        /// Moonriver.
        /// </summary>
        Moonriver = 1285,

        /// <summary>
        /// CloudWalk Mainnet.
        /// </summary>
        Cloudwalk = 2009,

        /// <summary>
        /// Kava EVM.
        /// </summary>
        Kava = 2222,

        /// <summary>
        /// Mantle.
        /// </summary>
        Mantle = 5000,

        /// <summary>
        /// Canto.
        /// </summary>
        Canto = 7700,

        /// <summary>
        /// Klaytn Mainnet Cypress.
        /// </summary>
        Klaytn = 8217,

        /// <summary>
        /// Evmos.
        /// </summary>
        Evmos = 9001,

        /// <summary>
        /// Haqq Network.
        /// </summary>
        HAQQ = 11235,

        /// <summary>
        /// Trust EVM Testnet.
        /// </summary>
        TrustEVM = 15555,

        /// <summary>
        /// OasisChain Mainnet.
        /// </summary>
        Oasis = 26863,

        /// <summary>
        /// Arbitrum One.
        /// </summary>
        ArbitrumOne = 42161,

        /// <summary>
        /// Arbitrum Nova.
        /// </summary>
        ArbitrumNova = 42170,

        /// <summary>
        /// Celo Mainnet.
        /// </summary>
        Celo = 42220,

        /// <summary>
        /// Avalanche C-Chain.
        /// </summary>
        Avalanche = 43114,

        /// <summary>
        /// Base Goerli.
        /// </summary>
        Base = 84531,

        /// <summary>
        /// Solana.
        /// </summary>
        Solana = 111111,

        /// <summary>
        /// Æternity.
        /// </summary>
        Aeternity = 111112,

        /// <summary>
        /// Hedera networks.
        /// </summary>
        Hedera = 111113,

        /// <summary>
        /// Ripple.
        /// </summary>
        Ripple = 111114,

        /// <summary>
        /// TRON.
        /// </summary>
        Tron = 111115,

        /// <summary>
        /// NEAR Protocol.
        /// </summary>
        Near = 111116,

        /// <summary>
        /// Aptos.
        /// </summary>
        Aptos = 111117,

        /// <summary>
        /// Waves.
        /// </summary>
        Waves = 111118,

        /// <summary>
        /// Ton.
        /// </summary>
        Ton = 111119,

        /// <summary>
        /// Algorand.
        /// </summary>
        Algorand = 111120,

        /// <summary>
        /// Flow.
        /// </summary>
        Flow = 111121,

        /// <summary>
        /// Aurora Mainnet.
        /// </summary>
        Aurora = 1313161554,

        /// <summary>
        /// Harmony Mainnet Shard 0.
        /// </summary>
        Harmony = 1666600000,

        /// <summary>
        /// Palm.
        /// </summary>
        Palm = 11297108109
    }
}