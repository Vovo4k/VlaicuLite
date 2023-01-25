using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using VlaicuOS.Commands;
using Cosmos.System.FileSystem;

namespace VlaicuOS
{
    public class Kernel : Sys.Kernel
    {

        private CommandManager commandManager;
        private CosmosVFS vfs;

        protected override void BeforeRun()
        {
            this.vfs=new CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(this.vfs);
            Console.Clear();
            this.commandManager = new CommandManager();

            Console.WriteLine("Welcome To Vlaicu OS");
            


        }

        protected override void Run()
        {
            String response;
            String input = Console.ReadLine();
            response = this.commandManager.proccesInput(input);
            Console.WriteLine(response);
        }
    }
}
