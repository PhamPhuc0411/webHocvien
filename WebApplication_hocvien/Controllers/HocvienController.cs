using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication_hocvien.Models;
using WebApplication_hocvien.MyModels;

namespace WebApplication_hocvien.Controllers
{
    public class HocvienController : Controller
    {
        private qlhvContext db = new qlhvContext(); 
        public IActionResult Index()
        {
            List<CHocvien> ds=db.Lyliches.Select(x=>CHocvien.chuyendoi(x)).ToList();
            //List<Lylich> ds = db.Lyliches.ToList();
            //foreach (var item in ds)
            //{
            //    item.MalopNavigation = db.Lops.Find(item.Malop);
            //}
            return View(ds);
        }
        public IActionResult formThemHocVien()
        {
            ViewBag.DSLop = new SelectList(db.Lops.ToList(), "Malop", "Tenlop");
            return View();
        }
        public IActionResult themHocVien(CHocvien x)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    db.Lyliches.Add(CHocvien.chuyendoi(x));
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch(Exception)
                {
                    ModelState.AddModelError("", "Loi khi them hoc vien!");
                }
                
            }
            ViewBag.DSLop = new SelectList(db.Lops.ToList(), "Malop", "Tenlop");
            return View("formThemHocVien");
        }
        public IActionResult formXoaHocvien (string id)
        {
            int dem = db.Diemthis.Count(t => t.Mshv == id);
            ViewBag.flagXoa = true;
            if(dem>0) ViewBag.flagXoa = false;

            Lylich hv = db.Lyliches.Find(id);
            return View(CHocvien.chuyendoi(hv));
        }
        public IActionResult xoaHocvien(string mshv)
        {
            try
            {
                Lylich hv = db.Lyliches.Find(mshv);
                db.Lyliches.Remove(hv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                
            }
            ErrorViewModel err = new ErrorViewModel();
            err.RequestId = "Khong the xoa hoc vien nay";
            return View("Error", err);
        }
        public IActionResult formSuaHocvien(string id)
        {
            ViewBag.DSLop = new SelectList(db.Lops.ToList(), "Malop", "Tenlop");
            Lylich hv = db.Lyliches.Find(id);
            return View(CHocvien.chuyendoi(hv));
        }
        public IActionResult suaHocvien(CHocvien hv)
        {
            if(ModelState.IsValid)
            {
                Lylich x = CHocvien.chuyendoi(hv);
                db.Lyliches.Update(x);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult xemDiemHocvien(string id)
        {
            Lylich hv = db.Lyliches.Find(id);
            hv.Diemthis = db.Diemthis.Where(t => t.Mshv == id).ToList();
            foreach(Diemthi d in hv.Diemthis)
            {
                d.MsmhNavigation = db.Monhocs.Find(d.Msmh);
            }
            return View(hv);
        }
    }
}
