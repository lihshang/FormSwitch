using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Collections;
using System.Threading;

namespace SineWave
{
    public partial class Form1 : Form
    {
        public ArrayList inputs = new ArrayList();
        private Thread _thread;
        private Random ran;
        private delegate void CanIJust();
        private CanIJust _doit;
        private double SinCnt = 0.0;
        private bool flag = false;

        public Form1()
        {
            InitializeComponent();

            ran = new Random();

            Start();
        }

        private void Start()
        {
            _doit += new CanIJust(AddSin);
            DateTime now = new DateTime();

            chart1.ChartAreas[0].AxisX.Minimum = now.ToOADate();
            chart1.ChartAreas[0].AxisX.Minimum = now.AddSeconds(10).ToOADate();

            _thread = new Thread(new ThreadStart(SinThread));
            _thread.Start();
        }

        private void AddSin()
        {
            DateTime now = DateTime.Now;

            chart1.ResetAutoValues();

            if (chart1.Series[0].Points.Count > 0)
            {
                while (chart1.Series[0].Points[0].XValue + 9 < SinCnt)
                {
                    chart1.Series[0].Points.RemoveAt(0);

                    chart1.ChartAreas[0].AxisX.Minimum = chart1.Series[0].Points[0].XValue;
                    chart1.ChartAreas[0].AxisX.Maximum = SinCnt + 1;
                }
            }

            chart1.Series[0].Points.AddXY(SinCnt, Math.Sin(SinCnt));
            SinCnt += 0.1;
        }

        private void SinThread()
        {
            while(true)
            {
                try
                {
                    Thread.Sleep(100);
                    if (flag) continue;
                    chart1.Invoke(_doit);
                }
                catch(Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Exception : " + e.ToString());

                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            this.AutoSize = true;

            Series sSin = chart1.Series.Add("sin");
            sSin.ChartType = SeriesChartType.Line;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Processing")
            {
                button1.Text = "Stop";
                flag = true;
            }
            else
            {
                button1.Text = "Processing";
                flag = false;
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
