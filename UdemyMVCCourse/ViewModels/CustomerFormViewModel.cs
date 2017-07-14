using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UdemyMVCCourse.Models;

namespace UdemyMVCCourse.ViewModels
{
    public class CustomerFormViewModel
    { 
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
        public string Title
        {
            get
            {
                return this.Customer.Id != 0 ? "Edit Customer" : "New Customer";
            }
        }

        public CustomerFormViewModel()
        {
            this.Customer = new Customer();
        }

        public CustomerFormViewModel(Customer customer)
        {
            this.Customer = customer;
        }
    }
}