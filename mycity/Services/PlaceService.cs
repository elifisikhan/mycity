using mycity.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mycity.Services
{
    public class PlaceService
    {

        private readonly mycityDbContext _context;

        public PlaceService(mycityDbContext context)
        {
            this._context = context;
        }

        public Places Add(Places entity)
        {
            this._context.Add(entity);
            this._context.SaveChanges();

            return entity;
        }

        public void Delete(Places entity)
        {
            this._context.Remove(entity);
        }

        public Places GetById(int id)
        {
            return this._context.Places.Where(c => c.PlacesId == id).FirstOrDefault();
        }

        public IEnumerable<Places> ListAll()
        {
            return this._context.Places.ToList();
        }

        public void Update(Places entity)
        {
            this._context.Places.Update(entity);
            this._context.SaveChanges();
        }
    }
}