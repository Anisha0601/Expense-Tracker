using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrackerExpenseMVC.Models
{
    public class CategoryMVC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CategoryMVC()
        {
            this.Expenses = new HashSet<ExpenseMVC>();
        }

        public int CId { get; set; }
        [Required(ErrorMessage = "Please enter the category name")]
        public string CName { get; set; }
        [Required(ErrorMessage = "Please enter the category expense limit")]
        public int CExpenseLimit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExpenseMVC> Expenses { get; set; }
    }
}