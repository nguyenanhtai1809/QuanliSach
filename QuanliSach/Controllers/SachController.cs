using QuanliSach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuanliSach.Controllers
{
    public class SachController : ApiController
    {
        Sach[] sachs = new Sach[]
 {
            new Sach { Id = 1, Title = "Tôi thấy hoa vàng trên cỏ xanh", AuthorName ="Nguyễn Nhật Ánh", Price = 1, Content="Truyện kể về Tuổi thơ..." },
            new Sach { Id = 2, Title = "Pro ASP.NET MVC5", AuthorName = "Adam Freeman", Content= "The ASP.NET MVC 5 Framework is the latest evolution of Microsoft’sASP.NET web platform.", Price = 3.75M },
 };
        public IEnumerable<Sach> GetAll()
        {
            return sachs;
        }
        public IHttpActionResult GetSach(int id)
        {
            var sach = sachs.FirstOrDefault((p) => p.Id == id);
            if (sach == null)
            {
                return NotFound();
            } 
            return Ok(sach);
        }
        [HttpGet]
        public List<Sach> GetSachLists()
        {
            dbsach1DataContext db = new dbsach1DataContext();
            return db.dbsach1.ToList();
        }
        [HttpPut]
        public bool UpdateSach(int id, string Content, string Title, string AuthorName, decimal Price)
        {
            try
            {
                dbsach1DataContext db = new dbsach1DataContext();
                Sach sach = dbsach1.FirstOrDefault(p => p.Id == id);
                if (sach == null) return false;
                sach.AuthorName = AuthorName;
                sach.Title = Title;
                sach.Content = Content;
                sach.Price = Price;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        [HttpDelete]
        public bool DeleteSach(int id)
        {
            dbsach1DataContext db = new dbsach1DataContext();
            //lấy food tồn tại ra
            Sach sach = db.dbsach1.FirstOrDefault(x => x.Id == id);
            if (sach == null) return false;
            db.dbsach1.DeleteOnSubmit(sach);
            db.SubmitChanges();
            return true;
        }
    }

}
   
