using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VlaicuOS.Commands
{
    public class Help : Command
    {

        public Help (String name) : base (name) { }

        public override String execute (String[] args)
        {
            return "file (crd - create directory, rrd - remove directory, \n file writestr - write text in file, \n file create - create a file \nfile delete delete a file \nfile readstr - read text file), \ngui, \nfetch";
        }

    }
}
