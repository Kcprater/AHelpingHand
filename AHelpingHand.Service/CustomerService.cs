using A.Helping.Hand.Data;
using AHelpingHand.Data;
using AHelpingHand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHelpingHand.Service
{
    public class CustomerService
    {
        private readonly Guid _userID;

        public CustomerService(Guid userID)
        {
            _userID = userID;
        }
        public bool CreateCustomer(CustomerCreate model)
        {
            var ctx = new ApplicationDbContext();
            var customer = new Customer()
            {
                OwnerId = _userID,
                Name = model.Name,
                Email = model.Email,
                Category = model.Category,
                Subcategory = model.Subcategory,
                Skill = model.Skill,
            };
            ctx.Customers.Add(customer);

            return ctx.SaveChanges() == 1;
        }
        public IEnumerable<CustomerListItem> GetCustomers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Customers
                    .Where(e => e.OwnerId == _userID)
                    .Select(e =>
                        new CustomerListItem
                        {
                            CustomerID = e.CustomerID,
                            Name = e.Name,
                            Email = e.Email,
                            Category = e.Category,
                            Subcategory = e.Subcategory,
                            Skill = e.Skill,
                        }
                     );
                return query.ToArray();
            }
        }
        public IEnumerable<HelpListItem> GetAllHelp()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Helps
                    .Select(e =>
                   new HelpListItem
                   {
                       HelpID = e.HelpID,
                       Category = e.Category,
                       Subcategory = e.Subcategory,
                       Experience = e.Experience,
                       Rate = e.Rate,
                       NewClients = e.NewClients,
                   }
                  );
                return query.ToArray();
            }
        }
        public CustomerDetail GetCustomerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerID == id && e.OwnerId == _userID);
                return
                    new CustomerDetail
                    {
                        CustomerID = entity.CustomerID,
                        Name = entity.Name,
                        Email = entity.Email,
                        Category = entity.Category,
                        Subcategory = entity.Subcategory,
                        Skill = entity.Skill,
                    };
            }
        }
        public ProviderDetail GetProvider(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Providers
                    .Single(e => e.ProviderID == id);
                return
                    new ProviderDetail
                    {
                        ProviderID = entity.ProviderID,
                        Name = entity.Name,
                        Company = entity.Company,
                        Email = entity.Email,
                        Phone = entity.Phone,
                    };
            }
        }
        public bool UpdateCustomer(CustomerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerID == model.CustomerID && e.OwnerId == _userID);
                entity.Name = model.Name;
                entity.Email = model.Email;
                entity.Category = model.Category;
                entity.Subcategory = model.Subcategory;
                entity.Skill = model.Skill;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteCustomer(int customerID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerID == customerID && e.OwnerId == _userID);

                ctx.Customers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}