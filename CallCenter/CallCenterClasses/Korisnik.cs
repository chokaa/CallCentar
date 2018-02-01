using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CallCenter.CallCenterClasses
{
    class Korisnik
    {

        private int IDKorisnika { get; set; }
        private string Ime { get; set; }
        private string Prezime { get; set; }
        private string BrojTelefona { get; set; }

        public int VratiIDKorisnika() {
            return IDKorisnika;
        }
        public Korisnik(string Ime, string Prezime, string BrojTelefona,string ConnectionString) {
            this.Ime = Ime;
            this.Prezime = Prezime;
            this.BrojTelefona = BrojTelefona;
            //unosimo korisnika u bazu i postavljamo mu ID koji nam baza vrati
            IDKorisnika = UnesiKorisnika(this, ConnectionString);
        }
        private int UnesiKorisnika(Korisnik  k,string ConnectionString)
        {


            SqlConnection conn = new SqlConnection(ConnectionString);

            string sql = "INSERT INTO korisnik (ImeKorisnika,PrezimeKorisnika,BrojTelefona) " +
                " OUTPUT INSERTED.IDKorisnika " +
                                        " VALUES(@ImeKorisnika,@PrezimeKorisnika,@BrojTelefona)";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@ImeKorisnika", this.Ime);

            cmd.Parameters.AddWithValue("@PrezimeKorisnika", this.Prezime);

            cmd.Parameters.AddWithValue("@BrojTelefona", this.BrojTelefona);

            conn.Open();
            
            int ID = Int32.Parse(cmd.ExecuteScalar().ToString());

            conn.Close();

            return ID;

        }
    }
}
