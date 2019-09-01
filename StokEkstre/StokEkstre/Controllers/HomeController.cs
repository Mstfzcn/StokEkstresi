using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace StokEkstre.Controllers
{
    public class HomeController : Controller
    {
        public string malkod = "10086 SİEMENS";
        public string baslangicTarih = "2017-01-01";
        public string bitisTarih = "2017-12-31";
        // GET: Home
        public ActionResult Index(string malkodu = "", string baslangicTarihi = "", string bitisTarihi = "")
        {
            if(!malkodu.Trim().Equals(""))
            {
                malkod = malkodu;
            }
            if (!baslangicTarihi.Trim().Equals(""))
            {
                baslangicTarih = baslangicTarihi;
            }
            if (!bitisTarihi.Trim().Equals(""))
            {
                bitisTarih = bitisTarihi;
            }
            DataSet ds = new DataSet();
            string constr = "Server=DESKTOP-0C197I0; Initial Catalog=Test; Integrated Security=SSPI";
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "exec SP_SearchStok '" + malkod.Trim() + "', '" + baslangicTarih +"', '" + bitisTarih + "'";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                    }
                }
            }

            return View(ds);
        }

    }
}