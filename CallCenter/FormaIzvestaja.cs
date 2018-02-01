using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CallCenter.CallCenterClasses;

namespace CallCenter
{
    public partial class FormaIzvestaja : Form
    {
        public FormaIzvestaja(Izvestaj izvestaj)
        {
            InitializeComponent();
            //Popunjavamo interfejs podacima iz izvestaja
            GridViewIzvestaja.DataSource = izvestaj.VratiGridIzvestaja();
            ProsecnoVremeValue.Text = (((int)izvestaj.VratiProsecnoVreme()/60).ToString()+":"+ ((izvestaj.VratiProsecnoVreme() % 60)).ToString()).Substring(0,5);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
