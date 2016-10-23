using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkSniffer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //SnifferForm sf = new SnifferForm();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SnifferForm());
        }

        public class SnifferForm : Form
        {
            const int packetBufferSize = 65536;
            byte[] packetBuffer = new byte[packetBufferSize];
            Label l1 = new Label();
            ComboBox selectIp = new ComboBox();
            Button startBtn = new Button();
            Button endBtn = new Button();
            Button saveBtn = new Button();
            Button resetBtn = new Button();
            ListBox results = new ListBox();
            Socket socket;
            Thread sniffer;
            NameValueCollection DNSCache = new NameValueCollection();
            CheckBox DnsResolve = new CheckBox();
            CheckBox LooseQueue = new CheckBox();

            public SnifferForm(): base()
            {
                Text = "Sniffer";
                Width = 400;
                l1.Top = 5;
                l1.Left = 5;
                l1.Text = "Select IP";
                Controls.Add(l1);
                selectIp.Top = 5;
                selectIp.Left = 50;
                Controls.Add(selectIp);
                //Fetch Info about the host
                GetHostEntry(selectIp);
                Controls.Add(saveBtn);
                startBtn.Top = 4;
                startBtn.Left = 230;
                startBtn.Text = "Start";
                startBtn.Click += new EventHandler(OnStartClicked);
                Controls.Add(endBtn);
                endBtn.Top = 4;
                endBtn.Left = 310;
                endBtn.Text = "Stop";
                endBtn.Click += new System.EventHandler(OnEndClicked);
                endBtn.Enabled = false;
                Controls.Add(DnsResolve);
                DnsResolve.Top = 28;
                DnsResolve.Left = 4;
                DnsResolve.Width = 130;
                DnsResolve.Text = "Resolve Host Names";
                Controls.Add(LooseQueue);
                LooseQueue.Top = 28;
                LooseQueue.Left = 134;
                LooseQueue.Width = 96;
                LooseQueue.Text = "Loose Queue";
                Controls.Add(saveBtn);
                saveBtn.Top = 28;
                saveBtn.Left = 230;
                saveBtn.Text = "Save";
                saveBtn.Click += new EventHandler(OnSaveClicked);
                Controls.Add(resetBtn);
                resetBtn.Top = 28;
                resetBtn.Left = 310;
                resetBtn.Text = "Reset";
                resetBtn.Click += new EventHandler(OnResetClicked);
                Controls.Add(results);
                results.Top = 54;
                results.Left = 4;
                results.Width = 384;
                results.Height = 224;
                results.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            }

            private void OnResetClicked(object sender, EventArgs e)
            {
                throw new NotImplementedException();
            }

            private void OnStartClicked(object sender, EventArgs e)
            {
                
            }

            private void OnEndClicked(object sender, EventArgs e)
            {
               endBtn.Enabled = false;
            }

            private void OnSaveClicked(object sender, EventArgs e)
            {
                throw new NotImplementedException();
            }

            private void GetHostEntry(ComboBox selectBox)
            {
                IPHostEntry HostEntry = Dns.GetHostEntry(Dns.GetHostName());
                if (HostEntry.AddressList.Length > 0)
                    for (int i = 0; i < HostEntry.AddressList.Length; i++)
                        selectBox.Items.Add(HostEntry.AddressList[i].ToString());
            }
        }
    }
}
