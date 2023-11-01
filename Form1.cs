using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Speech;
using System.Speech.Synthesis;

namespace Wikipediai
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer speech = new SpeechSynthesizer();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebClient wikia = new WebClient();
            var a = wikia.DownloadString("https://en.wikipedia.org/w/api.php?action=opensearch&servh=" + textBox1.Text);
            var b = Newtonsoft.Json.JsonConvert.DeserializeObject(a);
            string[] c = b.ToString().Split('[');
            var i = c[3];
            label2.Text = i;
            speech.SpeakAsync(i);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            speech.SpeakAsyncCancelAll();
        }
    }
}
