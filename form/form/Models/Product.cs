using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace form.Models
{
    public class Product
    {
        public int Id { get; set; }

        //Độ dài max là 60,nhỏ là 3
        [Required, StringLength(60, MinimumLength = 3)]
        public string Ten { get; set; }
        //bắt buộc phải ghi vào độ dài tối thiểu là 5
        [Required, StringLength(5)]
        public string NhaCungCap { get; set; }
        //số lượng trong khoảng 1-100
        [Range(1, 100), DataType(DataType.Currency)]
        public int Soluong { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime NgayNhap { get; set; }
        [Range(1, 100), DataType(DataType.Currency)]
        public double Gia { get; set; }
 

    }
    }