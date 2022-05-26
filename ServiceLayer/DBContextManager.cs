using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace ServiceLayer
{
    public static class DBContextManager
    {
        private static GameDbContext _context;
        private static GameContext _gameContext;
        private static GenreContext _genreContext;
        private static UserContext _userContext;

        #region DB Context
        public static GameDbContext CreateContext()
        {
            _context = new GameDbContext();
            return _context;
        }

        public static GameDbContext GetContext() 
        {
            return _context;
        }

        public static void SetChangeTracking(bool value) 
        {
            _context.ChangeTracker.AutoDetectChangesEnabled = value;
        }

        #endregion

        #region TContext

        public static GameContext CreateGameContext(GameDbContext context) 
        {
            _gameContext = new GameContext(context);
            return _gameContext;
        }

        public static GameContext GetGameContext() 
        {
            return _gameContext;
        }

        public static GenreContext CreateGenreContext(GameDbContext context) 
        {
            _genreContext = new GenreContext(context);
            return _genreContext;
        }

        public static GenreContext GetGenreContext() 
        {
            return _genreContext;
        }

        public static UserContext CreateUserContext(GameDbContext context) 
        {
            _userContext = new UserContext(context);
            return _userContext;
        }

        public static UserContext GetUserContext() 
        {
            return _userContext;
        }

        #endregion

    }
}
