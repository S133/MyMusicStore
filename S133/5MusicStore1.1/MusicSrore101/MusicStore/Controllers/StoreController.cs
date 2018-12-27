using MusicStore.ViewModels;
using MusicStoreEntity;
using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class StoreController : Controller
    {
        private static readonly EntityDbContext _context = new EntityDbContext();
        // GET: Store
        public ActionResult Detail(Guid id)
        {
            var detail = _context.Albums.Find(id);
            var cmt = _context.Replys.Where(x => x.Album.ID == id && x.ParentReply == null)
                .OrderByDescending(x => x.CreateDateTime).ToList();
            
            ViewBag.Cmt = _GetHtml(cmt);
            return View(detail);
        }
        public string _GetHtml(List<Reply> cmt)
        {
            var htmlString = "";
            htmlString += "<ul class='media-list'>";
            foreach (var item in cmt)
            {
                htmlString += "<li class='media'>";
                htmlString += "<div class='media-left'>";
                htmlString += "<img class='media-object' src='" + item.Person.Avarda +
                    "'alt='头像' style='width:40px;border-radius:50%;'>";
                htmlString += "</div>";
                htmlString += "<div class='media-body'>";
                htmlString += "<h5 class='media-heading'>" + item.Person.Name + "发表于" +
                    item.CreateDateTime.ToString("yyyy年MM月dd日 hh点mm分ss秒") + "</h5>";
                htmlString += item.Content;
                //查询当前回复的下级
                var sonCmt = _context.Replys.Where(x => x.ParentReply.ID == item.ID).ToList();
                htmlString += "<h6>回复(<a href='#'>" + sonCmt.Count + "</a>)条" + "<a href='#'><i class='glyphicon glyphicon-thumbs-up'></i></a>(" +
                    item.Like + ")<a href='#'><i class='glyphicon glyphicon-thumbs-down'></i></a>(" + item.Hate + ")</h6>";
                htmlString += "</div>";
                htmlString += "</li>";
            }
            htmlString += "</ul>";
            return htmlString;
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddCmt(string id,string cmt,string reply)
        {
            if (Session["LoginUserSessionModel"] == null)
                return Json("nologin");

            var person = _context.Persons.Find((Session["LoginUserSessionModel"] as
                LoginUserSessionModel). Person.ID);
            var album = _context.Albums.Find(Guid.Parse(id));

            var r = new Reply()
            {
                Album = album,
                Person = person,
                Content = cmt,
                Title = ""
            };
            if (string.IsNullOrEmpty(reply))
            {
                r.ParentReply = null;
            }
            else
            {
                r.ParentReply = _context.Replys.Find(Guid.Parse(reply));
            }
            _context.Replys.Add(r);
            _context.SaveChanges();

            var replies = _context.Replys.Where(x => x.Album.ID == album.ID && x.ParentReply
              ==null).OrderByDescending(x=>x.CreateDateTime).ToList();

            return Json(_GetHtml(replies));
        }
        public ActionResult Browser(Guid id)
        {
            var list = _context.Albums.Where(x => x.Genre.ID == id)
                .OrderByDescending(x => x.PublisherDate).ToList();
            return View(list);
        }
        public ActionResult Index()
        {
            var genres = _context.Genres.OrderBy(x => x.Name).ToList();
            return View(genres);

            
        }
    }
}