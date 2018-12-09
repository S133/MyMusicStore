using MusicStore.ViewModels;
using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        private static readonly EntityDbContext _context = new EntityDbContext();
        // GET: ShoppingCart
        [HttpPost]
        public ActionResult AddCart(Guid id)
        {
            Thread.Sleep(2000);
            if (Session["LoginUserSessionModel"] == null)
                return Json("nologin");

            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var cartItem = _context.Carts.SingleOrDefault(x => x.Person.ID == x.Person.ID && x.Album.ID == id);
            var message = "";
            if (cartItem == null)
            {
                cartItem = new Cart()
                {
                    AlbumID = id.ToString(),
                    Album = _context.Albums.Find(id),
                    Person = _context.Persons.Find(person.ID),
                    Count = 1,
                    CartID = (_context.Carts.Where(x => x.Person.ID == person.ID).ToList().Count() + 1.ToString())
                };
                _context.Carts.Add(cartItem);
                _context.SaveChanges();
                message = "添加" + _context.Albums.Find(id).Title + "到购物车成功!";

            }
            else
            {
                cartItem.Count++;
                _context.SaveChanges();
                message = _context.Albums.Find(id).Title + "已在购物车中，为您+1";
            }
            return Json(message);
        }
        public ActionResult Index()
        {
            //判断用户是否登录
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("index", "ShoppingCart") });
            //查询出当前登录用户
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            //查询出该用户的购物车
            var carts = _context.Carts.Where(x => x.Person.ID == x.Person.ID).ToList();
            //算出购物车的总价
            decimal? totalprice = (from item in carts select item.Count * item.Album.Price).Sum();
            //创建视图模型
            var cartVM = new ShoppingCartViewModel()
            {
                CartItems = carts,
                CartTotalPrice = totalprice ?? decimal.Zero
            };

            return View(cartVM);
        }

        [HttpPost]
        public ActionResult RemoveCart(Guid id)
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("index", "ShoppingCart") });
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var cartitem = _context.Carts.Find(id);
            if (cartitem.Count > 1)
                cartitem.Count--;
            else
                _context.Carts.Remove(cartitem);
            _context.SaveChanges();

            var carts = _context.Carts.Where(x => x.Person.ID == person.ID).ToList();
            var totalPrice = (from item in carts select item.Count * item.Album.Price).Sum();
            var htmlString = "";
            foreach(var item in carts)
            {
                htmlString += "<tr>";
                htmlString += "<td><a href='../store/detail" + item.ID + "'>" + item.Album.Title + "</a></td>";
                htmlString += "<td>" + item.Album.Price.ToString("C") + "</td>";
                htmlString += "<td>" + item.Count + "</td>";
                htmlString += "<td><a href=\"#\"onclick=\"removeCart('" + item.ID + "');\"><i class=\"glyphicon  glyphicon-remove\"></i>移除购物车</a></td><tr>";
            }
            htmlString += "<tr><td></td><td></td><td>总价</td><td>" + totalPrice.ToString("C") + "</td></tr>";
            return Json(htmlString);
        }
    }
}