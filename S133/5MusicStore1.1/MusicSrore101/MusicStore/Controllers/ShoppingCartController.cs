﻿using MusicStore.ViewModels;
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
    }
}