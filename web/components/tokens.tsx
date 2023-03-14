import styles from "./tokens.module.scss";

type IProps = {
  wallet: any;
};
const Tokens = (props: IProps) => {
  const {
    wallet: { data },
  } = props;
  const { tokenBalances } = data.stats;

  if (tokenBalances !== undefined) {
    return (
      <div className={styles.tokens}>
        <h2>Tokens</h2>
        <div className={styles.list}>
          
          {tokenBalances.map((token: any, id: number) => {
            if (token.symbol && token.totalAmountPrice > 1)
              return (
                <div className={styles.token} key={token.tokenId}>
                  <span className={styles.amount}>
                    {Math.round(token.amount * 100) / 100}
                  </span>
                  <span className={styles.symbol}>{token.symbol}</span>
                  <span className={styles.usd}>
                    ${Math.round(token.totalAmountPrice * 100) / 100}
                  </span>
                </div>
              );
          })}
        </div>
      </div>
    );  
  }
};

export default Tokens;
