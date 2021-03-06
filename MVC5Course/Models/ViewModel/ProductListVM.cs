﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MVC5Course.Model.ViewModel
{
    /// <summary>
    /// Product的VM,用來承載UI的輸入資料
    /// </summary>
    public class ProductListVM
    {

            [Required]
            public int ProductId { get; set; }

            [StringLength(80, ErrorMessage = "欄位長度不得大於 80 個字元")]
            [Required(ErrorMessage = "請輸入商品名稱")]
            [MinLength(3), MaxLength(30)]
            [RegularExpression("(.+)-(.+)")]
            public string ProductName { get; set; }
            [Range(0, 9999)]
            [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
            public Nullable<decimal> Price { get; set; }
            public Nullable<bool> Active { get; set; }
            [Required]
            [Range(0, 100, ErrorMessage = "請設定正確的商品價格名稱")]
            public Nullable<decimal> Stock { get; set; }

    }
}