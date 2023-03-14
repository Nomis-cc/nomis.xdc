import React from "react";

import Image from "next/image";

import UserAddress from "./UserAddress";
import UserStats from "./UserStats";

const userpick1 = "/userpicks/userpick1.svg";
const userpick2 = "/userpicks/userpick2.svg";
const userpick3 = "/userpicks/userpick3.svg";

import MintScoreEvm from "./MintScoreEvm";
import MintScoreXrp from "./MintScoreXrp";

export default function WalletUser({
  wallet,
  blockchainSlug,
  blockchain,
  ecoTokenAddress,
  group,
  address,
  fullAddress,
  action,
  apiHost,
  xummApiKey,
}) {
  const [random, setRandom] = React.useState();
  React.useEffect(() => {
    setRandom(Math.random());
  }, []);

  const randImg =
    random < 1 / 3 ? userpick1 : random < 2 / 3 ? userpick2 : userpick3;
  return (
    <>
      <section className="WalletUser">
        <div className="bio">
          <div className="userpick">
            <img
              src={
                wallet.stats.cyberConnectProfile &&
                wallet.stats.cyberConnectProfile.metadataInfo.avatar
                  ? wallet.stats.cyberConnectProfile.metadataInfo.avatar
                  : randImg
              }
              width={128}
              height={128}
              style={{ borderRadius: 999 }}
            />
          </div>
          <div className="meta">
            {wallet.stats.cyberConnectProfile &&
              wallet.stats.cyberConnectProfile.metadataInfo.displayName && (
                <h4 style={{ marginBottom: "-1rem" }}>
                  {wallet.stats.cyberConnectProfile.metadataInfo.displayName}
                </h4>
              )}
            <UserAddress address={address} fullAddress={fullAddress} />
            {wallet.stats.cyberConnectProfile &&
              wallet.stats.cyberConnectProfile.externalMetadataInfo.personal
                .organization && (
                <div style={{ display: "flex", gap: ".5rem" }}>
                  <img
                    src={
                      wallet.stats.cyberConnectProfile.externalMetadataInfo
                        .personal.organization.avatar
                    }
                    width={32}
                    height={32}
                    style={{ borderRadius: 999 }}
                  />
                  <div
                    style={{
                      display: "flex",
                      flexDirection: "column",
                      lineHeight: "1em",
                      gap: ".125rem",
                    }}
                  >
                    <div>
                      {
                        wallet.stats.cyberConnectProfile.externalMetadataInfo
                          .personal.organization.name
                      }
                    </div>
                    <div style={{ fontSize: ".75rem", opacity: 0.4 }}>
                      {
                        wallet.stats.cyberConnectProfile.externalMetadataInfo
                          .personal.title
                      }
                    </div>
                  </div>
                </div>
              )}
            {wallet.stats.cyberConnectProfile && (
              <div style={{ display: "flex", gap: "1rem" }}>
                <div>
                  {wallet.stats.cyberConnectProfile.followerCount} followers
                </div>
                <div>
                  {wallet.stats.cyberConnectProfile.subscriberCount} follows
                </div>
              </div>
            )}
            <UserStats
              wallet={wallet}
              blockchain={blockchainSlug}
              group={group}
            />
          </div>
        </div>
        {blockchainSlug === "ripple" ? (
          <MintScoreXrp
            blockchainSlug={blockchainSlug}
            blockchain={blockchain}
            action={action}
            apiHost={apiHost}
            xummApiKey={xummApiKey}
          />
        ) : (
          <MintScoreEvm
            blockchainSlug={blockchainSlug}
            blockchain={blockchain}
            ecoTokenAddress={ecoTokenAddress}
            action={action}
            apiHost={apiHost}
          />
        )}
        {wallet.stats.cyberConnectEssences && (
          <div style={{ minWidth: "100%" }}>
            <h4 style={{ marginBottom: "1rem" }}>Essences</h4>
            {wallet.stats.cyberConnectEssences.map((essence) => {
              return (
                <a
                  style={{ marginTop: ".5rem", display: "block" }}
                  href={essence.tokenURI}
                >
                  {essence.symbol} - {essence.metadata.name}
                </a>
              );
            })}
          </div>
        )}
      </section>
    </>
  );
}
