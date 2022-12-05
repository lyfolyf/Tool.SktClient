using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lead.Tool.Interface;
using System.Resources;
using Lead.Tool.Resources;

namespace Lead.Tool.SktClient
{
    public class SktClientCreat : ICreat
    {
        public ITool GetInstance(string Name, string Path)
        {
                return new SktClientTool(Name,Path);
        }

        public Image Icon
        {
            get
            {
                return (Image)ImageManager.GetImage("客户端");
            }
        }

        public string Name
        {
            get
            {
                return "SktClient";
            }
        }
    }
}
