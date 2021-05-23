namespace InterestCalculator.Domain.Services
{
    public class EndpointAddress
    {
        public string Url { get; private set; }

        public EndpointAddress(string url) =>
            Url = url;
    }
}