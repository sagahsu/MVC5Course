using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC5Course.Model.ViewModel
{
    /// <summary>
    /// Product的VM,用來承載UI的輸入資料
    /// </summary>
    public class ProductVM
    {

        [Required]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "請輸入商品名稱")]
        public string ProductName { get; set; }

        public Nullable<decimal> Price { get; set; }
        public Nullable<bool> Active { get; set; }
        [Required]
        public Nullable<decimal> Stock { get; set; }


    }
}