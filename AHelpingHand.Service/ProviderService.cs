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
    public class ProviderService
    {
        private readonly Guid _userID;

        public ProviderService(Guid userID)
        {
            _userID = userID;
        }
        public ProviderDetail GetProviderByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Providers
                    .Single(e => e.ProviderID == id);
                return new ProviderDetail
                {
                    ProviderID = entity.ProviderID,
                    Name = entity.Name,
                    Company = entity.Company,
                    Email = entity.Email,
                    Phone = entity.Phone,
                };
            }
        }
        public bool EditProvider(ProviderEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Providers
                    .Single(e => e.ProviderID == model.ProviderID);

                entity.ProviderID = model.ProviderID;
                entity.Name = model.Name;
                entity.Company = model.Company;
                entity.Email = model.Email;
                entity.Phone = model.Phone;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteProvider(int providerID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Providers
                    .Single(e => e.ProviderID == providerID);
                ctx.Providers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}