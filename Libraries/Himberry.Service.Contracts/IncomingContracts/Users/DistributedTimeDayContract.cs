namespace Himberry.Service.Contrcts.IncomingContracts.Users
{
    public sealed class DistributedTimeDayContract
    {
        public int Sleep { get; set; }
        public int Work { get; set; }
        public int Active { get; set; }
        public int Passive { get; set; }
    }
}
