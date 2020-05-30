using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace project_sem_3.Models
{
    public class Discount : BaseDate
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public double Value { get; set; }
        public DateTime ExprirationDate { get; set; }
        public double MinTotal { get; set; }
        public double UseTime { get; set; }
        public EDiscountStatus Status { get; set; }
    }

    public enum EDiscountStatus
    {
        Active = 1,
        Deactive = 2
    }
}