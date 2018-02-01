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
    class ResenjeProblema : Problem
    {

        private string Komentar { get; set; }
        private DateTime VremePocetka { get; set; }
        private DateTime VremeZavrsetka { get; set; }
        private string StatusZavrsetka { get; set; }
        private int IDProblema { get; set; }

        public ResenjeProblema(string Komentar, DateTime VremePocetka, DateTime VremeZavrsetka, string StatusZavrsetka, int IDProblema)
        {
            this.Komentar = Komentar;
            this.VremePocetka = VremePocetka;
            this.VremeZavrsetka = VremeZavrsetka;
            this.StatusZavrsetka = StatusZavrsetka;
            this.IDProblema = IDProblema;
            //unosimo podatke u bazu
            UnesiResenje(this);
        }

        private void UnesiResenje(ResenjeProblema rp)
        {

            DataTable DT = new DataTable();

            SqlConnection conn = new SqlConnection(MyConnectionString);

            bool StatusZavrsetka;

            if (rp.StatusZavrsetka == "Zavrsen")
                StatusZavrsetka = true;
            else
                StatusZavrsetka = false;


            string sqlCheck = "select * from ResenjeProblema where IDProblema =@IDProblema";


            SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn);

            cmdCheck.Parameters.AddWithValue("@IDProblema", rp.IDProblema);

            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(cmdCheck);

            adapter.Fill(DT);


            if (DT.Rows.Count == 0)
            {

                string sql = "INSERT INTO ResenjeProblema (Komentar,VremePocetka,VremeZavrsetka,StatusZavrsetka,IDProblema)" +
                                     " VALUES (@Komentar,@VremePocetka,@VremeZavrsetka,@StatusZavrsetka,@IDProblema)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Komentar", rp.Komentar);

                cmd.Parameters.AddWithValue("@VremePocetka", rp.VremePocetka);

                cmd.Parameters.AddWithValue("@VremeZavrsetka", rp.VremeZavrsetka);

                cmd.Parameters.AddWithValue("@StatusZavrsetka", StatusZavrsetka);

                cmd.Parameters.AddWithValue("@IDProblema", rp.IDProblema);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Uspesno uneto resenje problema!");

            }
            else
            {

                DataRow DR = DT.Rows[0];

                if ((bool)DR["StatusZavrsetka"] == true )
                {
                    MessageBox.Show("Problem je vec resen!");
                }
                else
                {
                    string sqlUpdate = "update ResenjeProblema set VremeZavrsetka = @VremeZavrsetka,StatusZavrsetka = @StatusZavrsetka where IDProblema = @IDProblema ";

                    SqlCommand cmd = new SqlCommand(sqlUpdate, conn);


                    cmd.Parameters.AddWithValue("@IDProblema", rp.IDProblema);

                    cmd.Parameters.AddWithValue("@VremeZavrsetka", rp.VremeZavrsetka);

                    cmd.Parameters.AddWithValue("@StatusZavrsetka", StatusZavrsetka);

                    cmd.ExecuteNonQuery();


                    MessageBox.Show("Uspesno uneto resenje problema!");

                }
            }

            conn.Close();
            
       
        }
    }
}
