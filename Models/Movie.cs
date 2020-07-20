using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models
{
    public class Movie
    {
        public int Id { get; set; }

        //Required 和 MinimumLength 特性表示属性必须有值；但用户可输入空格来满足此验证。
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        //Range 特性将值限制在指定范围内。
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        //RegularExpression 特性用于限制可输入的字符。 在上述代码中，即“Genre”（分类）：
        //只能使用字母。
        //第一个字母必须为大写。 不允许使用空格、数字和特殊字符。
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Required]
        [StringLength(30)]
        public string Genre { get; set; }

        //RegularExpression“Rating”（分级）：
        //要求第一个字符为大写字母。
        //允许在后续空格中使用特殊字符和数字。 “PG-13”对“分级”有效，但对于“分类”无效。
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(5)]
        [Required]
        public string Rating { get; set; }
    }

    public class MovieGenreViewModel
    {
        public List<Movie> Movies { get; set; }
        public SelectList Genres { get; set; }
        public string MovieGenre { get; set; }
        public string SearchString { get; set; }
    }
}