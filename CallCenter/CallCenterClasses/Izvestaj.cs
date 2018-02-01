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
    public class Izvestaj : Problem
    {
        private DataTable GridIzvestaja;
        private double ProsecnoVreme;

        public DataTable VratiGridIzvestaja() {
            return GridIzvestaja;
        }
        public double VratiProsecnoVreme()
        {
            return ProsecnoVreme;
        }

        public Izvestaj() {
            //podatke iz baze popunjavamo u izvestaj
            GridIzvestaja = VratiIzvestaj(this);

            if (GridIzvestaja.Rows.Count == 0) {
                MessageBox.Show("Nema resenih problema!");
                return;
            }

            //izracunavamo prosecno vreme za resavanje problema u minutima
            ProsecnoVreme = GridIzvestaja.AsEnumerable().Average(r=>r.Field<int>(GridIzvestaja.Columns["RadniMinuti"]));
            //otvaramo novu formu za izvestaj
            FormaIzvestaja Forma = new FormaIzvestaja(this);
            Forma.Show();
        }

        private DataTable VratiIzvestaj(Problem p)
        {
            DataTable DT = new DataTable();

            SqlConnection conn = new SqlConnection(MyConnectionString);

            string sql = "select datediff(minute,0, DATEADD(minute,  ((DATEDIFF(dd,  dateadd(d,1,VremePocetka) , VremeZavrsetka)) - 	   (( DATEDIFF(wk,  dateadd(d,1,VremePocetka) , VremeZavrsetka) * 2) -        case when datepart(dw,  dateadd(d,1,VremePocetka) ) = 7 then 1 else 0 end -       case when datepart(dw, VremeZavrsetka) = 7 then -1 else 0 end))*8*60 +  DATEDIFF(minute,  dateadd(d,1,VremePocetka) , dateadd(hh,17,cast(convert(varchar(10),  dateadd(d,1,VremePocetka) , 110) as datetime)))+	   DATEDIFF(minute, dateadd(hh,9,cast(convert(varchar(10),  VremeZavrsetka, 110) as datetime)),VremeZavrsetka) , 0))/60 as RadniSati , datediff(minute,0,	   DATEADD(minute, 	((DATEDIFF(dd,  dateadd(d,1,VremePocetka) , VremeZavrsetka)) - 	   (( DATEDIFF(wk,  dateadd(d,1,VremePocetka) , VremeZavrsetka) * 2) -        case when datepart(dw,  dateadd(d,1,VremePocetka) ) = 7 then 1 else 0 end -       case when datepart(dw, VremeZavrsetka) = 7 then -1 else 0 end))*8*60 +  DATEDIFF(minute,  dateadd(d,1,VremePocetka) , dateadd(hh,17,cast(convert(varchar(10),  dateadd(d,1,VremePocetka) , 110) as datetime)))+	   DATEDIFF(minute, dateadd(hh,9,cast(convert(varchar(10),  VremeZavrsetka, 110) as datetime)),VremeZavrsetka) , 0))  as RadniMinuti,IDProblema,Komentar from ResenjeProblema where StatusZavrsetka = 1";

            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            adapter.Fill(DT);

            conn.Close();

            return DT;
        }



    }

   

}
