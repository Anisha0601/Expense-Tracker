using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrackerExpenseMVC.Models
{
    public class ExpenseMVC
    {
        public int EId { get; set; }
        [Required(ErrorMessage = "Please enter the Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter the description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter the amount")]
        public int Amount { get; set; }
        [Required(ErrorMessage = "Please enter the category")]
        public int CId { get; set; }

        public virtual CategoryMVC Category { get; set; }
    }
}