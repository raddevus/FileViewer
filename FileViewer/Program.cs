using PhotinoNET;
using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HelloPhotinoApp
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Window title declared here for visibility
            string windowTitle = "Photino for .NET Demo App";

            // Creating a new PhotinoWindow instance with the fluent API
            var window = new PhotinoWindow()
                .SetTitle(windowTitle)
                // Resize to a percentage of the main monitor work area
                .SetUseOsDefaultSize(false)
                .SetSize(new Size(800, 600))
                // Center window in the middle of the screen
                .Center()
                // Users can resize windows by default.
                // Let's make this one fixed instead.
                .SetResizable(true)
                
                // Most event handlers can be registered after the
                // PhotinoWindow was instantiated by calling a registration 
                // method like the following RegisterWebMessageReceivedHandler.
                // This could be added in the PhotinoWindowOptions if preferred.
                .RegisterWebMessageReceivedHandler((object sender, string message) => {
                    var window = (PhotinoWindow)sender;
                    // response = String.Empty;
                    WindowMessage wm = JsonSerializer.Deserialize<WindowMessage>(message);
                    
                    Console.WriteLine($"wm.Command: {wm.Command}");
                    switch (wm.Command){
                        case "getInitialPath" :{
                            var userHome = FileSystem.GetUserHome();
                            
                            FileSystem fs = new FileSystem(userHome);
                            var response = new {command=wm.Command,data=userHome,fsi=fs.GetAllFileSystemItems()};
                            //Console.WriteLine(JsonSerializer.Serialize(fs.GetAllFileSystemItems()));
                            
                            //fs.GetAllFileSystemItems();
                            window.SendWebMessage(JsonSerializer.Serialize( response));
                            break;
                        }
                        case "getPathData" :{
                            FileSystem fs = new FileSystem(wm.Data);
                            var outPath = wm.Data;
                            
                            var response = new {command=wm.Command,data=outPath,fsi=fs.GetAllFileSystemItems()};
                            window.SendWebMessage(JsonSerializer.Serialize(response));
                            break;
                        }
                        default:{
                            // The message argument is coming in from sendMessage.
                            // "window.external.sendMessage(message: string)"
                             var response = new {command=wm.Command,
                                data=wm.Data};
                            // Send a message back the to JavaScript event handler.
                            // "window.external.receiveMessage(callback: Function)"
                            window.SendWebMessage(JsonSerializer.Serialize( response));
                            break;
                        }                        
                    }
                    
                    
                })
                .Load("wwwroot/index.html"); // Can be used with relative path strings or "new URI()" instance to load a website.

            window.WaitForClose(); // Starts the application event loop
        }
    }
}
