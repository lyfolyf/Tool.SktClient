using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lead.Tool.Log;

namespace Lead.Tool.SktClient
{
    public partial class DebugUI : UserControl
    {
        private SktClientTool _proxy = null;
        public DebugUI(SktClientTool control)
        {
            InitializeComponent();
            _proxy = control;
            _proxy.MesEvent += new MesRecved(ShowRecived);
        }

        private void ShowRecived(string mes)
        {
            this.BeginInvoke(new Action(()=> {
                richTextBoxRecive.Text = mes;
            } )  );
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            _proxy.SendInfo("", richTextBoxSend.Text);
        }

        private void ButtonInit_Click(object sender, EventArgs e)
        {
            _proxy.Init();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            _proxy.Start();
        }

        private void buttonTerminate_Click(object sender, EventArgs e)
        {
            _proxy.Terminate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_proxy.State == Interface.IToolState.ToolInit)
            {
                ButtonInit.BackColor = Color.Green;
                buttonStart.BackColor = Color.Gray;
                buttonTerminate.BackColor = Color.Gray;
            }
            if (_proxy.State == Interface.IToolState.ToolRunning)
            {
                ButtonInit.BackColor = Color.Green;
                buttonStart.BackColor = Color.Green;
                buttonTerminate.BackColor = Color.Gray;
            }
            if (_proxy.State == Interface.IToolState.ToolTerminate)
            {
                ButtonInit.BackColor = Color.Gray;
                buttonStart.BackColor = Color.Gray;
                buttonTerminate.BackColor = Color.Red;
            }
        }
    }
}
