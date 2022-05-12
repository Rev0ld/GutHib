using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class GenreContext : IDB<Genre, int>
    {
        private GameDbContext _context;

        public GenreContext(GameDbContext context) 
        {
            _context = context;
        }

        public void Create(Genre item)
        {
            try
            {
                _context.Genres.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Genre Read(int key, bool noTracking = false, bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<Genre> query = _context.Genres;

                if (noTracking) 
                {
                    query = query.AsNoTrackingWithIdentityResolution();
                }
                if (useNavigationProperties) 
                {
                    query = query.Include(a => a.Users);
                }
                return query.SingleOrDefault(a => a.ID == key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Genre> Read(int skip, int take, bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<Genre> query = _context.Genres.AsNoTrackingWithIdentityResolution();
                if (useNavigationProperties) 
                {
                    query = query.Include(a => a.Users);
                }
                return query.Skip(skip).Take(take).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<Genre> ReadAll(bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<Genre> query = _context.Genres.AsNoTracking();
                if (useNavigationProperties) 
                {
                    query = query.Include(a => a.Users);
                }
                return query.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(Genre item, bool useNavigationProperties = false)
        {
            try
            {
                Genre genreFromDB = Read(item.ID, useNavigationProperties);

                if (useNavigationProperties) 
                {
                    List<User> users = new List<User>();

                    foreach (User user in item.Users) 
                    {
                        User userFromDB = _context.Users.Find(user.ID);
                        if (userFromDB != null)
                        {
                            users.Add(userFromDB);
                        }
                        else 
                        {
                            users.Add(user);
                        }
                    }

                    genreFromDB.Users = users;
                }

                _context.Entry(genreFromDB).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Delete(int key)
        {
            try
            {
                _context.Genres.Remove(Read(key));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
