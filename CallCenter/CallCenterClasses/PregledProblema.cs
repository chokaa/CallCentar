using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CallCenter.CallCenterClasses
{
    class PregledProblema : Problem
    {

        private DataTable GridPodaci { get; set; }

        public PregledProblema()
        {
            GridPodaci = PregledajProbleme();
        }

        private DataTable PregledajProbleme()
        {

            DataTable DT = new DataTable();

            SqlConnection conn = new SqlConnection(MyConnectionString);
            
            string sql = "Select k.ImeKorisnika,k.PrezimeKorisnika,p.TipZahteva,k.BrojTelefona,p.OpisProblema,p.IDProblema  from problem p join korisnik k on p.IDKorisnika=k.IDKorisnika";

            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            adapter.Fill(DT);

            conn.Close();

            return DT;
        }

        public DataTable PretraziProbleme(string QueryString)
        {

            SqlConnection conn = new SqlConnection(MyConnectionString);

            string sql = "Select k.ImeKorisnika,k.PrezimeKorisnika,p.TipZahteva,k.BrojTelefona,p.OpisProblema,p.IDProblema from problem p join korisnik k on p.IDKorisnika=k.IDKorisnika where k.ImeKorisnika like N'%" + QueryString + "%' or k.PrezimeKorisnika like N'%" + QueryString + "%' or p.OpisProblema like N'%" + QueryString + "%' ";

            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            adapter.Fill(GridPodaci);

            conn.Close();

            return GridPodaci;
        }

        public DataTable VratiGridPregleda()
        {
            return GridPodaci;
        }
        public void OcistiPregled()
        {
            GridPodaci = new DataTable();
        }

        public void PostaviGridPregleda(DataTable DT)
        {
            GridPodaci = DT;
        }


    }
}
