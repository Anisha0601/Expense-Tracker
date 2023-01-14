using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace TrackerExpenseMVC.Models
{
    public class TotalExpenseMVC
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the total expense limit")]
        public int TExpenseLimit { get; set; }
    }
}