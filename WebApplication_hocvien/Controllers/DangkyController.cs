using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication_hocvien.Models;
using WebApplication_hocvien.MyModels;

namespace WebApplication_hocvien.Controllers
{
    public class DangkyController : Controller
    {
        private qlhvContext db = new qlhvContext();
        public IActionResult Index()
        {
            ViewBag.DSLop = new SelectList(db.Lops.ToList(), "Malop", "Malop");
            ViewBag.DSMonhoc = new SelectList(db.Monhocs.ToList(), "Msmh", "Tenmh");
            return View();
        }
        public IActionResult hienthiDSHocvien([FromBody] CLopMonhoc x)
        {
            List<Lylich> dsDaDangky = new List<Lylich>();
            List<Lylich> dsChuaDangky = new List<Lylich>();
            foreach (Lylich a in db.Lyliches.Where(t => t.Malop == x.malop).ToList())
            {
                List<Diemthi> dsDiem = db.Diemthis.Where(t=>t.Msmh==x.msmh && a.Mshv==t.Mshv).ToList();
                if(dsDiem.Count > 0)
                {
                    dsDaDangky.Add(a);
                }
                else
                {
                    dsChuaDangky.Add(a);
                }
            }
            ViewBag.MaMonhoc = x.msmh;
            ViewBag.DSDaDangky = dsDaDangky;
            ViewBag.DSChuaDangky = dsChuaDangky;
            return PartialView();
        }
        public IActionResult huyDangky(string mshv, string msmh)
        {
            Diemthi d = db.Diemthis.Find(mshv, msmh);
            if (d != null)
            {
                db.Diemthis.Remove(d);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult dangkyMonhoc(string mshv, string msmh)
        {
            Diemthi d = new Diemthi();
            d.Mshv= mshv;
            d.Msmh = msmh;
            d.Diem = "";
            db.Diemthis.Add(d);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
