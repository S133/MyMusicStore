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
                htmlString += "<div class='media-body' id='Content-"+item.ID+"'>";
                htmlString += "<h5 class='media-heading'>" + item.Person.Name + "发表于" +
                    item.CreateDateTime.ToString("yyyy年MM月dd日 hh点mm分ss秒") + "</h5>";
                htmlString += item.Content;
                htmlString += "</div>";
                //查询当前回复的下级
                var sonCmt = _context.Replys.Where(x => x.ParentReply.ID == item.ID).ToList();
                htmlString += "<h6><a href='#div-editor' class='reply' onclick=\"javascript:GetQuote('" + item.ID +
                              "');\">回复</a>(<a href='#' class='reply'  onclick=\"javascript:ShowCmt('" + item.ID + "');\">" + sonCmt.Count + "</a>)条" +
                              "<a href='#' class='reply' style='margin:0 20px 0 40px'><i class='glyphicon glyphicon-thumbs-up'></i>(" +
                              item.Like + ")</a><a href='#' class='reply' style='margin:0 20px'><i class='glyphicon glyphicon-thumbs-down'></i>(" + item.Hate + ")</a></h6>";

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

        [HttpPost]
        public ActionResult showCmts(string pid)
        {
            var htmString = "";
            Guid id = Guid.Parse(pid);
            var cmts = _context.Replys.Where(x => x.ParentReply.ID == id).OrderByDescending(x => x.CreateDateTime).ToList();
            var pcmt = _context.Replys.Find(id);
            htmString += "<div class=\"modal-header\">";
            htmString += "<button type=\"button\"class=\"close\"data-dismiss=\"modal\"aria-hidden=\"true\">";
            htmString += "<h4 class=\"modal-title\"id=\"myModalLabel\">";
            htmString += pcmt.Person.Name + "发表于" + pcmt.CreateDateTime.ToString("yyyy年MM月dd日 hh点mm分ss秒") + ":<br/>" + pcmt.Content;
            htmString += "</h4></div>";
            htmString += "<div class=\"modal-body\">";
            htmString += "</div><div class=\"modal-footer\"></div>";
            return Json(htmString);
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