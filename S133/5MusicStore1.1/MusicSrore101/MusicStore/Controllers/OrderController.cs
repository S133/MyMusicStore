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
            //会话为空，则刷新页面
            if (Session["Order"] == null)
                return RedirectToAction("buy");
            //读取会话中的Order对象
            var order = Session["Order"] as Order;
            var deleteDetail = order.OrderDetails.SingleOrDefault(x => x.ID == id);
            //从订单明细列表中移除明细记录
            order.OrderDetails.Remove(deleteDetail);
            //根据新的order对象重新生成Html脚本,返回json数据,局部刷新视图
            var htmlString = "";
            var totalPrice = (from item in order.OrderDetails select item.Count * item.Album.Price).Sum();
            Session["Order"] = order;
            foreach (var item in order.OrderDetails)
            {
                htmlString += "<tr>";
                htmlString += "<td><a href='"+Url.Action("Detail","Store",new { id=item.Album.ID})+"'>"
                    +item.Album.Title+"</a></td>";
                htmlString += "<td>" + item.Album.Price.ToString("C") + "</td>";
                htmlString += "<td>" + item.Count + "</td>";
                htmlString += "<td><a href='#' onclick='RemoveDetail('"+item.ID+"');'><i class='glyphicon glyphicon-remove'></i>我不喜欢它了</a></td>";
                htmlString += "</tr>";
            }
            htmlString += "<td><td></td><td></td><td>总价</td><td>" + order.TotalPrice.ToString("C") + "</td></tr>";
            return Json(htmlString);
        }
        [HttpPost]
        public ActionResult Buy(Order order)
        {
            //判断用户登录是否过期,如果过期跳转回登录页,登录成功后返回确认购买页
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Buy", "Order") });
            //读出当前用户Person
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            order.Person = _context.Persons.Find(person.ID);
            //从会话中读出订单明细列表
            order.OrderDetails = new List<OrderDetail>();
            order.TotalPrice = 0.00M;

            var details = (Session["Order"] as Order).OrderDetails;
            foreach(var item in details)
            {
                item.Album = _context.Albums.Find(item.Album.ID);
                order.OrderDetails.Add(item);
            }
            order.TotalPrice= (from item in order.OrderDetails select item.Count * item.Album.Price).Sum();
            //如果表单验证通过,则保存order到数据库
            if (ModelState.IsValid)
            {
                LockedHelp.ThreadLocked(order.ID);
                try
                {
                    _context.Orders.Add(order);
                    _context.SaveChanges();
                }
                catch
                {

                }
                finally
                {
                    LockedHelp.ThreadUnLocked(order.ID);
                }
                return RedirectToAction("Alipay", "Pay", new { id = order.ID });
            }
            //验证不通过,返回视图

            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}