using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApplication
{
    public partial class frmGMap : Form
    {
        public frmGMap()
        {
            InitializeComponent();

            GMap.NET.WindowsForms.GMapControl map = new GMap.NET.WindowsForms.GMapControl();
            map.Width = 500;
            map.Height = 400;

            this.Controls.Add(map);
        }
    }
}
