using Core;

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
            // TODO: Make this project run as a service
            // Detemine the OS and run OS specific services

            //STEP1: Register HOTKEY
            Registrar.Initialize("Window");

            IGlobalHotKey globalHotKey = Registrar.GetInstance<IGlobalHotKey>();
            globalHotKey.RegisterAsync("");
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
        }
    }
}