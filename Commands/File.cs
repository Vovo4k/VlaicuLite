using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Sys = Cosmos.System;

namespace VlaicuOS.Commands
{
    internal class File : Command
    {

        public File (String name) : base (name) { }

        public override String execute(String[] args) {


            //file create Myfile.txt

            String response = "";

            switch (args[0])
            {
                case "create":

                    try
                    {
                        Sys.FileSystem.VFS.VFSManager.CreateFile(args[1]);
                        response = "The file " + args[1] + " was created!";
                    }
                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }

                    break;

                case "delete":
                    try
                    {
                        Sys.FileSystem.VFS.VFSManager.DeleteFile(args[1]);
                        response = "The file " + args[1] + " was removed!";
                    }
                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }

                    break;

                case "crd":
                    try
                    {
                        Sys.FileSystem.VFS.VFSManager.CreateDirectory(args[1]);
                        response = "The Directory " + args[1] + " has been created!";
                    }

                    catch(Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }





                    break;

                case "rrd":
                    try
                    {
                        Sys.FileSystem.VFS.VFSManager.DeleteDirectory(args[1], true);
                        response = "The Directory " + args[1] + " has been deleted!";
                    }

                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }





                    break;


                case "writestr":

                    try
                    {
                        FileStream fs=(FileStream)Sys.FileSystem.VFS.VFSManager.GetFile(args[1]).GetFileStream();

                        if (fs.CanWrite)
                        {

                            int ctr = 0;
                            StringBuilder sb = new StringBuilder();

                            foreach (String s in args)
                            {
                                if (ctr>1)
                                    sb.Append(s+' ');

                                ++ctr;
                            }

                            String txt= sb.ToString();
                            Byte[] data = Encoding.ASCII.GetBytes(txt.Substring(0,txt.Length-1));

                            fs.Write(data,0, data.Length);
                            fs.Close();

                            response = "File writed!";
                        }

                        else
                        {
                            response = "Unable to write to file! Not open for writing.";
                            break;
                        }
                    }

                    catch (Exception ex) { 
                        response = ex.ToString();
                        break;
                    }


                    break;


                case "readstr":

                    try
                    {

                        FileStream fs = (FileStream)Sys.FileSystem.VFS.VFSManager.GetFile(args[1]).GetFileStream();

                        if (fs.CanRead)
                        {
                            Byte[] data = new Byte[256];

                            fs.Read(data, 0, data.Length);
                            response = Encoding.ASCII.GetString(data);
                        }
                        else
                        {
                            response = "Unable to read from file! Not open for reading";
                        }

                        break;

                    }

                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }

                default:
                    response = "Unexpected argument:" + args[0];
                    break;


            }

            return response;

        }

    }
}
