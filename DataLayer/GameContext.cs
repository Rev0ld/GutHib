using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class GameContext : IDB<Game, int>
    {
        public GameDbContext _context;

        public GameContext(GameDbContext context) 
        {
            _context = context; 
        }

        public void Create(Game item)
        {
            /*
             * try
            {
                Genre genreFromDB = _context.Genres.Find(item.ID);

                if (genreFromDB != null) 
                {
                    item.Gernes = (IEnumerable<Genre>)genreFromDB;
                }    
            }
            catch (Exception ex)
            {

                throw ex;
            }
            */
            try
            {
                _context.Games.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Game Read(int key, bool noTracking = false, bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<Game> query = _context.Games;

                if (noTracking)
                {
                    query = query.AsNoTrackingWithIdentityResolution(); 
                }
                if (useNavigationProperties)
                {
                    query = query.Include(a => a.Gernes).Include(a => a.Users);
                }
                return query.SingleOrDefault(a => a.ID == key);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<Game> Read(int skip, int take, bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<Game> query = _context.Games.AsNoTrackingWithIdentityResolution();

                if (useNavigationProperties) 
                {
                    query = query.Include(a => a.Gernes).Include(a => a.Users);
                }

                return query.Skip(skip).Take(take).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<Game> ReadAll(bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<Game> query = _context.Games.AsNoTracking();

                if (useNavigationProperties)
                {
                    query = query.Include(a => a.Gernes).Include(a => a.Users);
                }

                return query.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(Game item, bool useNavigationProperties = false)
        {
            try
            {
                Game gameFromDB = Read(item.ID, useNavigationProperties);

                if (useNavigationProperties)
                {
                    gameFromDB.Gernes = item.Gernes;

                    List<User> users = new List<User>();

                    foreach (User user in gameFromDB.Users) 
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
                    gameFromDB.Users = users;
                }
                _context.Entry(gameFromDB).CurrentValues.SetValues(item);
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
                _context.Games.Remove(Read(key));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
