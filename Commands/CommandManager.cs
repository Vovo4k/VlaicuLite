using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VlaicuOS.Commands
{
    public class CommandManager
    {

        private List<Command> commands;

        public CommandManager() { 

            this.commands=new List<Command>(4);
            this.commands.Add(new Help("help"));
            this.commands.Add(new fetch("fetch"));
            this.commands.Add(new File("file"));

        }

        public String proccesInput (String input)
        {
            String[] split = input.Split(' ');

            String label = split[0];

            List<String> args=new List<string>();

            int ctr = 0;
            foreach (String s in split) {


                if (ctr!=0)
                    args.Add(s);

                ++ctr;

            }

            foreach (Command cmd in this.commands)
            {

                if (cmd.name == label)
                    return cmd.execute(args.ToArray());

            }

            return "Your Command \""+label+"\" does not exist!";

        }

    }
}
