using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CallCenter.CallCenterClasses
{
    class UnosProblema : Problem
    {

        private Korisnik Korisnik { get; set; }

        private string TipZahteva { get; set; }

        private string OpisProblema { get; set; }

        private int IDProblema;

        public UnosProblema(string ImeKorisnika, string PrezimeKorisnika, string BrojTelefona, string TipZahteva, string OpisProblema) {
            Korisnik = new Korisnik(ImeKorisnika, PrezimeKorisnika, BrojTelefona, MyConnectionString);
            this.TipZahteva = TipZahteva;
            this.OpisProblema = OpisProblema;
            IDProblema = UnesiProblem(this);
        }

        private int UnesiProblem(UnosProblema P)
        {


            SqlConnection conn = new SqlConnection(P.MyConnectionString);
         
                string sql = "INSERT INTO problem (IDKorisnika,TipZahteva,OpisProblema,IDOperatera)" +
                    " OUTPUT INSERTED.IDProblema " +
                              " VALUES (@IDKorisnika,@TipZahteva,@OpisProblema,@IDOperatera)";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@IDKorisnika", Korisnik.VratiIDKorisnika());

                cmd.Parameters.AddWithValue("@TipZahteva", P.TipZahteva);

                cmd.Parameters.AddWithValue("@OpisProblema", P.OpisProblema);

                cmd.Parameters.AddWithValue("@IDOperatera", P.IDOperatera);

                conn.Open();

                int ID = Int32.Parse(cmd.ExecuteScalar().ToString());

                conn.Close();

                MessageBox.Show("Uspesno ste uneli problem!");
            return ID;


            
        }
    }
}
