using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace project_sem_3.Models
{
    public class Category : BaseDate
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ECategoryStatus Status { get; set; }
    }

    public enum ECategoryStatus
    {
        Active = 1,
        Deactive = 2
    }
}