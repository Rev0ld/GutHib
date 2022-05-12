using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using BusinessLayer;

namespace DataLayer
{
    public class UserContext : IDB<User, int>
    {
        private GameDbContext _context;

        public UserContext(GameDbContext context)
        {
            this._context = context;
        }


        public void Create(User item)
        {
            try
            {
                _context.Users.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User Read(int key, bool noTracking = false, bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<User> query = _context.Users;

                if (noTracking) 
                {
                    query = query.AsNoTrackingWithIdentityResolution();
                }

                if (useNavigationProperties) 
                {
                    query = query.Include(a => a.Games).Include(a => a.Friends);
                }
                User userFromDB = query.SingleOrDefault(a => a.ID == key);

                if (userFromDB == null) 
                {
                    throw new ArgumentException("ThErE iS nO uSeR wItH tHaT kEy¡ ");
                }

                return userFromDB;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<User> Read(int skip, int take, bool useNavigationProperties = false) 
        {
            try
            {
                IQueryable<User> query = _context.Users.AsNoTrackingWithIdentityResolution();

                if (useNavigationProperties) 
                {
                    query = query.Include(a => a.Games).Include(a => a.Friends);
                }

                return query.Skip(skip).Take(take).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<User> ReadAll(bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<User> query = _context.Users.AsNoTracking();

                if (useNavigationProperties) 
                {
                    query = query.Include(a => a.Games).Include(a => a.Friends);
                }
                return query.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(User item, bool useNavigationProperties = false)
        {
            /*try
            {
                User userFromDB = Read(item.ID, useNavigationProperties);

                _context.Entry(userFromDB).CurrentValues.SetValues(item);

                if (useNavigationProperties)
                {
                    List<User> userPreviousFriends = userFromDB.Friends.ToList();
                    List<User> game = new List<User>(item.Friends.Count());

                    foreach (User friend in item.Friends) 
                    {
                        User friendFromDB = _context.Users.Include(a => a.Friends).SingleOrDefault(a => a.ID ==friend.ID);
                        if (friendFromDB == null) 
                        {
                            _context.Entry(friend).Collection(a => a.)
                        }
                    }


                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            */
            
            throw new NotImplementedException();
        }

        public void Delete(int key)
        {
            try
            {
                _context.Users.Remove(Read(key));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        
    }
}
