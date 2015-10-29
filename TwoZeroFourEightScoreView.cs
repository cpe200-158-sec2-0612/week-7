using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace twozerofoureight
{
    public partial class TwoZeroFourEightScoreView : Form, View
    {
        public TwoZeroFourEightScoreView()
        {
            InitializeComponent();
        }
        public void UpdateScoreView(int score) //changing score
        {
            string s;
            s = score.ToString();
            label3.Text = s;
        }


        public void Notify(Model m)
        {
            UpdateScoreView(((TwoZeroFourEightModel)m).getScore());
        }

        private void TwoZeroFourEightScoreView_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
