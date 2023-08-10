namespace TheOrganizer
{
    internal class MainService
    {
        /// <summary>
        /// Main entry point
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            OperatingSystem os = Environment.OSVersion;

            if (os.Platform == PlatformID.Win32NT)
            {
                IOSMain main = new WindowsMain();
            }
            else if (os.Platform == PlatformID.Unix)
            {
                // implement for linux
            }
            else if (os.Platform == PlatformID.MacOSX)
            {
                // implement of Mac
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}