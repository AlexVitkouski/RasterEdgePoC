namespace RasterEdgePoC.Logger
{
    interface ILogger
    {
        void LogInfo(string message);
        void LogError(string message);
    }
}
