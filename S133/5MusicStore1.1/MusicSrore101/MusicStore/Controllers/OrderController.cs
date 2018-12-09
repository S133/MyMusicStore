using MusicStore.ViewModels;
using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class OrderController : Controller
    {
        private static readonly EntityDbContext _context = new EntityDbContext();
        // GET: Order
        public ActionResult Buy()
        {
            //1.确认用户是否登录,是否登录过期
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Buy", "Order") });
            //2.查询出当前用户Person 查询该用户的购物项
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var carts = _context.Carts.Where(x => x.Person.ID == x.Person.ID).ToList();
            //算出购物车总价
            decimal? totalPrice = (from item in carts select item.Count * item.Album.Price).Sum();
            //3.创建新Order对象,验证用户收件人、地址、电话
            var order = new Order()
            {
                AddressPerson = person.Name,
                MobilNumber = person.MobileNumber,
                Person = _context.Persons.Find(person.ID),
                TotalPrice = totalPrice ?? 0.00M,
            };
            //4.把购物项导入订单明细,供用户确认要购买专辑
            order.OrderDetails = new List<OrderDetail>();
            foreach(var item in carts)
            {
                var detail = new OrderDetail()
                {
                    AlbumID = item.AlbumID,
                    Album = _context.Albums.Find(item.Album.ID),
                    Count = item.Count,
                    Price = item.Album.Price
                };
                order.OrderDetails.Add(detail);
            }
            //将订单和明细在视图呈现,验证用户收件人、收货地址、电话,供用户确认要购买的专辑

            //当前订单未持久化,用会话
            Session["Order"] = order;
            return View(order);
        }
        [HttpPost]
        public ActionResult RemoveDetail(Guid id)
        {
            return Json("");
        }
        [HttpPost]
        public ActionResult Buy(Order oder)
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}