using System;
using System.Linq;

namespace TerraTex_RL_RPG.Lib.Threads
{
    public class ConsoleReader
    {
        // Declare the delegate (if using non-generic pattern).
        public delegate void OnConsoleMessageEventHandler(string cmd, string[] args);

        // Declare the event.
        public static event OnConsoleMessageEventHandler OnConsoleMessageEvent;

        private bool _interuped = false;

        public void DoWork()
        {
            while (!_interuped)
            {
                string s = Console.ReadLine();
                if (s != null)
                {
                    if (s.StartsWith("/"))
                    {
                        s = s.Substring(1);
                        string[] parts = s.Split(' ');
                        string cmd = parts[0];
                        parts = parts.Skip(1).ToArray();
                        OnConsoleMessageEvent?.Invoke(cmd, parts);

                    }
                    else
                    {
                        TTRPG.Api.sendChatMessageToAll("<span style='font-weight: bold'>[SERVER-INFORMATION]: " + s + "</span>");
                        TTRPG.Api.consoleOutput("Sending Message: [SERVER - INFORMATION]: " + s);
                    }
                }
            }
        }

        public void StopThread()
        {
            _interuped = true;
        }
    }
}