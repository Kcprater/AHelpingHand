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
    public class HelpService
    {
        private readonly Guid _userID;

        public HelpService(Guid userID)
        {
            _userID = userID;
        }
        public bool CreateHelp(HelpCreate model)
        {
            var ctx = new ApplicationDbContext();
            var provider = new Provider()
            {
                Name = model.Name,
                Company = model.Company,
                Email = model.Email,
                Phone = model.Phone,

            };
            ctx.Providers.Add(provider);

            var help = new Help()
            {
                OwnerId = _userID,
                Category = model.Category,
                Subcategory = model.Subcategory,
                Experience = model.Experience,
                Rate = model.Rate,
                NewClients = model.NewClients,
            };
            ctx.Helps.Add(help);

            return ctx.SaveChanges() >= 1;
        }
        public IEnumerable<HelpListItem> GetHelps()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Helps
                    .Where(e => e.OwnerId == _userID)
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
        public HelpDetail GetHelpById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Helps
                        .Single(e => e.HelpID == id && e.OwnerId == _userID);
                return
                    new HelpDetail
                    {
                        HelpID = entity.HelpID,
                        Category = entity.Category,
                        Subcategory = entity.Subcategory,
                        Experience = entity.Experience,
                        Rate = entity.Rate,
                        NewClients = entity.NewClients,
                        Provider = entity.Providers.Where(e => e.HelpID == entity.HelpID).ToList(),
                    };
            }
        }
        public bool UpdateHelp(HelpEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Helps
                        .Single(e => e.HelpID == model.HelpID && e.OwnerId == _userID);
                entity.Category = model.Category;
                entity.Subcategory = model.Subcategory;
                entity.Experience = model.Experience;
                entity.Rate = model.Rate;
                entity.NewClients = model.NewClients;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteHelp(int helpID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Helps
                        .Single(e => e.HelpID == helpID && e.OwnerId == _userID);

                ctx.Helps.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}