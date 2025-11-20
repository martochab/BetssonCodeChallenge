namespace Betsson.OnlineWallets.Data.Models
{
    public class OnlineWalletEntry
    {
        public string Id { get; set; }
        public DateTimeOffset EventTime { get; set; } = DateTimeOffset.Now.UtcDateTime;

        public decimal Amount { get; set; }
        public decimal BalanceBefore { get; set; }

        public OnlineWalletEntry()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
