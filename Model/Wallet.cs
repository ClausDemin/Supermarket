namespace Supermarket.Model
{
    public class Wallet
    {
        public Wallet(float balance = 0)
        {
            Balance = balance;
        }

        public float Balance { get; private set; }

        public bool TryWithdrawMoney(float amount)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(amount);

            if (Balance >= amount)
            {
                Balance -= amount;
                return true;
            }

            return false;
        }

        public void AddMoney(float amount)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(amount);

            Balance += amount;
        }
    }
}
