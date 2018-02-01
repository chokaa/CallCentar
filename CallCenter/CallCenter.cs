using CallCenter.CallCenterClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CallCenter
{
    public partial class CallCenter : Form
    {
        public CallCenter()
        {
            InitializeComponent();
        }
        

        PregledProblema Pregled = new PregledProblema();
        private void Form1_Load(object sender, EventArgs e)
        {
            //prilikom loadovanja forme se popunjava grid sa podacima
            GridView.DataSource = Pregled.VratiGridPregleda();
            VremePocetkaValue.MinDate = DateTime.Now;
            VremeZavrsetkaValue.MinDate = DateTime.Now;
            VremePocetkaValue.Value = DateTime.Now;
            VremeZavrsetkaValue.Value = DateTime.Now;
        }
        private void Clear() {
            //cistimo formu za unos problema
            ImeValue.Text = "";
            PrezimeValue.Text = "";
            TipZahtevaValue.Text = "";
            BrojTelefonaValue.Text = "";
            OpisProblemaValue.Text="";
        }
        private void RefreshGridView() {

            //cistimo grid podatke i dovlacimo nove nakon unosa korisnika
            GridView.DataSource = new DataGridView();

            PregledProblema NoviPregled = new PregledProblema();

            GridView.DataSource = NoviPregled.VratiGridPregleda();
        }
        private void DugmeUnesiProblem_Click(object sender, EventArgs e)
        {

            if (ValidacijaProblema())
            {

                UnosProblema unos = new UnosProblema(this.ImeValue.Text, this.PrezimeValue.Text, this.BrojTelefonaValue.Text, this.TipZahtevaValue.Text, this.OpisProblemaValue.Text);
                
                Clear();

                RefreshGridView();
            }
            else {
                MessageBox.Show("Ime, broj telefona, opis problema i tip zahteva su obavezna polja");
                return;
            }

        }

        private void DugmePretraziProbleme_Click(object sender, EventArgs e)
        {
            //Cistimo podatke iz grida i dovlacimo nove iz baze na osnovu unete reci u pretragu
            string keyword = PretraziProblemeValue.Text;

            Pregled.OcistiPregled();

            Pregled.PostaviGridPregleda(Pregled.PretraziProbleme(keyword));

            GridView.DataSource = Pregled.VratiGridPregleda();
        }

        private void GridView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataTable DT = (DataTable)GridView.DataSource;
            IDProblemaReadOnly.Text = DT.Rows[e.RowIndex]["IDProblema"].ToString();
        }

        private void UnesiResenje_Click(object sender, EventArgs e)
        {
            if (IDProblemaReadOnly.Text == "")
                MessageBox.Show("Morate odabrati problem iz tabele!");
            else if (!ValidacijaResenja())
            {
                MessageBox.Show("Status zavrsetka je obavezno polje!");
            }
            else
            {
                ResenjeProblema RP = new ResenjeProblema(KomentarValue.Text, VremePocetkaValue.Value, VremeZavrsetkaValue.Value, StatusZavrsetkaValue.Text, Int32.Parse(IDProblemaReadOnly.Text));
                ClearResenja();
            }
        }

        private void ClearResenja()
        {
            //cistimo ui nakon unosa podataka u bazu
            KomentarValue.Text = "";
            VremePocetkaValue.Value = DateTime.Now;
            VremeZavrsetkaValue.Value = DateTime.Now;
            StatusZavrsetkaValue.Text = "";
            IDProblemaReadOnly.Text = "";
        }
        public bool ValidacijaProblema() {

            if (ImeValue.Text == "" || TipZahtevaValue.Text == "" || BrojTelefonaValue.Text == "" || OpisProblemaValue.Text == "")
                return false;
            else
                return true;

        }
        public bool ValidacijaResenja()
        {

            if (this.StatusZavrsetkaValue.Text == "")
                return false;
            else
                return true;

        }

        private void GenerisiIzvestaj_Click(object sender, EventArgs e)
        {
            Izvestaj Izv = new Izvestaj();
        }

    }
}
