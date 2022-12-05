using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lead.Tool.XML;

namespace Lead.Tool.SktClient
{
    public partial class ConfigUI : UserControl
    {
        SktClientTool _Proxy = null;
        public ConfigUI(SktClientTool proxy)
        {
            InitializeComponent();
            if (proxy._Config == null)
            {
                throw new Exception("SktClient的proxy._config实例为空！");
            }
            else
            {
                _Proxy = proxy;
                textBoxIP.Text = _Proxy._Config.IP;
                textBoxPort.Text = _Proxy._Config.Port;
                textBoxHeart.Text = _Proxy._Config.Heart.ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _Proxy._Config.IP = textBoxIP.Text;
            _Proxy._Config.Port = textBoxPort.Text;
            _Proxy._Config.Heart = Convert.ToInt32(textBoxHeart.Text) ;
            XmlSerializerHelper.WriteXML(_Proxy._Config, _Proxy._path, typeof(Config));
            MessageBox.Show(_Proxy._Config.Name+"配置文件保存成功！");
        }
    }
}
