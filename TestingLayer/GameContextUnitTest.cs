using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace TestingLayer
{
    public class GameContextUnitTest
    {
        private GameDbContext dbContext;
        private GameContext gameContext;
        DbContextOptionsBuilder builder;

        [OneTimeSetUp]
        public void OneTimeSetUp() 
        {
            
        }
        [SetUp]
        public void Setup() 
        {
            builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());

            dbContext = new GameDbContext(builder.Options);
            gameContext = new GameContext(dbContext);
        }

        [Test]
        public void TestCreateGame() 
        {
            int gamesBefore = gameContext.ReadAll().Count();

            gameContext.Create(new Game("Azur Lane"));

            int gamesAfter = gameContext.ReadAll().Count();

            Assert.IsTrue(gamesBefore != gamesAfter);   
        }

        [Test]
        public void TestReadGame() 
        {
            gameContext.Create(new Game("Blue Archive"));

            Game game = gameContext.Read(1);

            Assert.That(game != null, "There is no game with ID of ''1'' ");
        }

        [Test]
        public void TestUpdateGame() 
        {
            gameContext.Create(new Game("GTA 5"));

            Game game = gameContext.Read(1);

            game.Name = "GTA 6";

            gameContext.Update(game);

            Game game1 = gameContext.Read(1);

            Assert.IsTrue(game1.Name == "GTA 6", "Game Update() does not change the game! СЧУПЕНО Е!!!!!!!!!!!");

            
        }

        [Test]
        public void TestDeleteGame() 
        {
            gameContext.Create(new Game("Delete game!"));

            int gameBeforeDeletion = gameContext.ReadAll().Count();

            gameContext.Delete(1);

            int gameAfterDeletion = gameContext.ReadAll().Count();

            Assert.AreNotEqual(gameBeforeDeletion, gameAfterDeletion);
        }
    }
}
