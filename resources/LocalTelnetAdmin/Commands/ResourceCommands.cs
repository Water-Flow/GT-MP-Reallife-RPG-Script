﻿using System;
using System.Linq;
using System.Net.Sockets;
using GrandTheftMultiplayer.Server.API;

namespace LocalTelnetAdmin.Commands
{
    public class ResourceCommands : Script
    {
        public ResourceCommands()
        {
            LocalTelnetAdmin.RegisterNewCommand("stopresource", new Command("StopResource", "ResourceCommands"));
            LocalTelnetAdmin.RegisterNewCommand("startResource", new Command("StartResource", "ResourceCommands"));
            LocalTelnetAdmin.RegisterNewCommand("restartResource", new Command("RestartResource", "ResourceCommands"));
            LocalTelnetAdmin.RegisterNewCommand("listRunningResources", new Command("ListRunningResources", "ResourceCommands"));
        }

        public void StopResource(NetworkStream stream, String[] args)
        {
            if (args.Length > 0)
            {
                if (this.DoesResourceExist(args[0]))
                {
                    if (API.isResourceRunning(args[0]))
                    {
                        API.stopResource(args[0]);
                        LocalTelnetAdmin.SendResponse(stream, ConsoleColors.GREEN + "Success: Resource " + args[0] + " stopped successfully.");
                    }
                    else
                    {
                        LocalTelnetAdmin.SendResponse(stream, ConsoleColors.RED + "Error: Resource " + args[0] + " is not running.");
                    }
                }
                else
                {
                    LocalTelnetAdmin.SendResponse(stream, ConsoleColors.RED + "Error: Resource " + args[0] + " does not exist.");
                }
            }
            else
            {
                LocalTelnetAdmin.SendResponse(stream, ConsoleColors.RED + "Error: No ResourceName sendet.");
            }
        }

        public void StartResource(NetworkStream stream, String[] args)
        {
            if (args.Length > 0)
            {
                if (this.DoesResourceExist(args[0]))
                {
                    if (!API.isResourceRunning(args[0]))
                    {
                        API.startResource(args[0]);
                        LocalTelnetAdmin.SendResponse(stream, ConsoleColors.GREEN + "Success: Resource " + args[0] + " started successfully.");
                    }
                    else
                    {
                        LocalTelnetAdmin.SendResponse(stream, ConsoleColors.RED + "Error: Resource " + args[0] + " is already running.");
                    }
                }
                else
                {
                    LocalTelnetAdmin.SendResponse(stream, ConsoleColors.RED + "Error: Resource " + args[0] + " does not exist.");
                }
            }
            else
            {
                LocalTelnetAdmin.SendResponse(stream, ConsoleColors.RED + "Error: No ResourceName sendet.");
            }
        }

        public void RestartResource(NetworkStream stream, String[] args)
        {
            if (args.Length > 0)
            {
                if (this.DoesResourceExist(args[0]))
                {
                    API.stopResource(args[0]);
                    LocalTelnetAdmin.SendResponse(stream, ConsoleColors.GREEN + "Success: Resource " + args[0] + " stopped successfully.");
                    API.startResource(args[0]);
                    LocalTelnetAdmin.SendResponse(stream, ConsoleColors.GREEN + "Success: Resource " + args[0] + " started successfully.");
                }
                else
                {
                    LocalTelnetAdmin.SendResponse(stream, ConsoleColors.RED + "Error: No ResourceName sendet.");
                }
            }
            else
            {
                LocalTelnetAdmin.SendResponse(stream, ConsoleColors.RED + "Error: No ResourceName sendet.");
            }
        }

        public void ListRunningResources(NetworkStream stream, String[] args)
        {

        }

        private Boolean DoesResourceExist(String resourceName)
        {
            string[] resourcesList = API.getAllResources();
            return resourcesList.Contains(resourceName);
        }
    }
}