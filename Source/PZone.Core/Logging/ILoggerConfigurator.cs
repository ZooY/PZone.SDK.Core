namespace PZone.Logging
{
    public interface ILoggerConfigurator
    {
        bool Configured { get; }

        void Configure();
        void Configure(string settings);
    }
}
