﻿using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
    public class Order
    {
        [ScaffoldColumn(false)]
        public Guid ID { get; set; }
        [ScaffoldColumn(false)]
        public DateTime OrderDateTime { get; set; }//订单时间
        public virtual Person Person { get; set; }//所属用户
        [Display(Name ="收件人")]
        [Required(ErrorMessage ="收件人不能为空。")]
        public string AddressPerson { get; set; }//收件人

        [Display(Name = "收件人地址")]
        [Required(ErrorMessage = "收件人地址不能为空。")]
        public string Address { get; set; }//收件人地址

        [Display(Name = "手机号")]
        [Required(ErrorMessage = "手机号不能为空。")]

        
        public string MobilNumber { get; set; }//收件人手机
        [ScaffoldColumn(false)]
        public decimal TotalPrice { get; set; }//总价
        [ScaffoldColumn(false)]
        public string TradeNo { get; set; }//支付流水号
        [ScaffoldColumn(false)]
        public bool PaySuccess { get; set; }//是否支付成功
        [ScaffoldColumn(false)]
        public virtual EnumOrderStatus EnumOrderStatus { get; set; }

        //购买专辑明细
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public Order()
        {
            OrderDateTime = DateTime.Now;
            TradeNo = OrderDateTime.ToString("yyyyMMddhhmmssffff");
        }
    }
}
