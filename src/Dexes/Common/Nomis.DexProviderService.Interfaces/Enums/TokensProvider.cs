// ------------------------------------------------------------------------------------------------------
// <copyright file="TokensProvider.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

// ReSharper disable InconsistentNaming
namespace Nomis.DexProviderService.Interfaces.Enums
{
    /// <summary>
    /// Tokens provider.
    /// </summary>
    public enum TokensProvider :
        byte
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,

        /// <summary>
        /// 1inch.
        /// </summary>
        OneInch,

        /// <summary>
        /// Aave token list.
        /// </summary>
        Aave,

        /// <summary>
        /// Blockchain Association ERC20 SEC Action.
        /// </summary>
        BlockchainAssociation,

        /// <summary>
        /// CMC DeFi.
        /// </summary>
        CmcDeFi,

        /// <summary>
        /// CMC Stablecoin.
        /// </summary>
        CmcStablecoin,

        /// <summary>
        /// CMC200 ERC20.
        /// </summary>
        Cmc200Erc20,

        /// <summary>
        /// Agora dataFi Tokens.
        /// </summary>
        AgoraDataFi,

        /// <summary>
        /// CoinGecko.
        /// </summary>
        CoinGecko,

        /// <summary>
        /// Compound.
        /// </summary>
        Compound,

        /// <summary>
        /// Defiprime.
        /// </summary>
        Defiprime,

        /// <summary>
        /// Dharma Token List.
        /// </summary>
        Dharma,

        /// <summary>
        /// Furucombo.
        /// </summary>
        Furucombo,

        /// <summary>
        /// Gemini Token List.
        /// </summary>
        Gemini,

        /// <summary>
        /// Kleros Tokens.
        /// </summary>
        Kleros,

        /// <summary>
        /// Messari Verified.
        /// </summary>
        Messari,

        /// <summary>
        /// MyCrypto Token List.
        /// </summary>
        MyCrypto = 16,

        /// <summary>
        /// Optimism.
        /// </summary>
        Optimism,

        /// <summary>
        /// Roll Social Money
        /// </summary>
        RollSocialMoney,

        /// <summary>
        /// Set.
        /// </summary>
        Set,

        /// <summary>
        /// Synthetix.
        /// </summary>
        Synthetix,

        /// <summary>
        /// Testnet Token List.
        /// </summary>
        Testnet,

        /// <summary>
        /// Token Name Service.
        /// </summary>
        TokenNameService,

        /// <summary>
        /// Uniswap Labs Default.
        /// </summary>
        Uniswap,

        /// <summary>
        /// Uniswap Token Pools.
        /// </summary>
        UniswapPools,

        /// <summary>
        /// Uniswap Token Pairs.
        /// </summary>
        UniswapPairs,

        /// <summary>
        /// Wrapped Tokens.
        /// </summary>
        WrappedTokens,

        /// <summary>
        /// Zerion.
        /// </summary>
        Zerion,

        /// <summary>
        /// UMA.
        /// </summary>
        Uma,

        /// <summary>
        /// Balancer Vetted Token List.
        /// </summary>
        Balancer,

        /// <summary>
        /// QuickSwap Default Token List.
        /// </summary>
        QuickSwap,

        /// <summary>
        /// Tracer.
        /// </summary>
        Tracer,

        /// <summary>
        /// Netswap Top 100 Tokens.
        /// </summary>
        NetswapTop100,

        /// <summary>
        /// SonarWatch list.
        /// </summary>
        SonarWatch,

        /// <summary>
        /// Solana Token List.
        /// </summary>
        Solana,

        /// <summary>
        /// LibraX Extended.
        /// </summary>
        LibraX,

        /// <summary>
        /// Ubeswap.
        /// </summary>
        Ubeswap,

        /// <summary>
        /// PancakeSwap.
        /// </summary>
        PancakeSwap,

        /// <summary>
        /// Comethswap Default List.
        /// </summary>
        Comethswap,

        /// <summary>
        /// Jarvis Network.
        /// </summary>
        Jarvis,

        /// <summary>
        /// Dfyn Default list.
        /// </summary>
        Dfyn,

        /// <summary>
        /// Pangolin Token list.
        /// </summary>
        Pangolin,

        /// <summary>
        /// Trader Joe Default.
        /// </summary>
        TraderJoe,

        /// <summary>
        /// SpookySwap Default List.
        /// </summary>
        SpookySwap,

        /// <summary>
        /// Arb Whitelist Era.
        /// </summary>
        Arbitrum,

        /// <summary>
        /// ParaSwap Community Token Lists.
        /// </summary>
        ParaSwap,

        /// <summary>
        /// ParaSwap Community Stablecoin Lists.
        /// </summary>
        ParaSwapStablecoins,

        /// <summary>
        /// PowerSwap token List.
        /// </summary>
        PowerSwap,

        /// <summary>
        /// SushiSwap Menu.
        /// </summary>
        SushiSwap,

        /// <summary>
        /// SushiSwap Token Pools.
        /// </summary>
        SushiSwapPools,

        /// <summary>
        /// SushiSwap Token Pairs.
        /// </summary>
        SushiSwapPairs,

        /// <summary>
        /// Via Protocol.
        /// </summary>
        ViaProtocol,

        /// <summary>
        /// SoulSwap.
        /// </summary>
        SoulSwap,

        /// <summary>
        /// PlasmaSwap.
        /// </summary>
        PlasmaSwap,

        /// <summary>
        /// GoSwap.
        /// </summary>
        GoSwap,

        /// <summary>
        /// MochiSwap.
        /// </summary>
        MochiSwap,

        /// <summary>
        /// ShibaSwap
        /// </summary>
        ShibaSwap,

        /// <summary>
        /// FalconSwap.
        /// </summary>
        FalconSwap,

        /// <summary>
        /// Alvis Finance.
        /// </summary>
        AlvisFinance,

        /// <summary>
        /// Impossible Finance.
        /// </summary>
        ImpossibleFinance,

        /// <summary>
        /// WrappedFi.
        /// </summary>
        WrappedFi,

        /// <summary>
        /// YetiSwap.
        /// </summary>
        YetiSwap,

        /// <summary>
        /// Evmosis.
        /// </summary>
        Evmosis,

        /// <summary>
        /// VertoDex.
        /// </summary>
        VertoDex,

        /// <summary>
        /// DiffusionFi.
        /// </summary>
        DiffusionFi,

        /// <summary>
        /// OpenXswap.
        /// </summary>
        OpenXswap,

        /// <summary>
        /// ActaFi.
        /// </summary>
        ActaFi,

        /// <summary>
        /// ZappyFinance.
        /// </summary>
        ZappyFinance,

        /// <summary>
        /// LeetSwap.
        /// </summary>
        LeetSwap,

        /// <summary>
        /// Yearn.
        /// </summary>
        Yearn,

        /// <summary>
        /// Yearn Extended.
        /// </summary>
        YearnExtended,

        /// <summary>
        /// Wido.
        /// </summary>
        Wido,

        /// <summary>
        /// Tokenlistooor.
        /// </summary>
        Tokenlistooor,

        /// <summary>
        /// Portals.
        /// </summary>
        Portals,

        /// <summary>
        /// Ledger.
        /// </summary>
        Ledger,

        /// <summary>
        /// DefiLlama.
        /// </summary>
        DefiLlama,

        /// <summary>
        /// Curve.
        /// </summary>
        Curve,

        /// <summary>
        /// CoWSwap.
        /// </summary>
        CoWSwap,

        /// <summary>
        /// Euler.
        /// </summary>
        Euler,

        /// <summary>
        /// VenomSwap.
        /// </summary>
        VenomSwap,

        /// <summary>
        /// LootSwap.
        /// </summary>
        LootSwap,

        /// <summary>
        /// Increment.
        /// </summary>
        IncrementFi,

        /// <summary>
        /// Zircon.
        /// </summary>
        Zircon
    }
}