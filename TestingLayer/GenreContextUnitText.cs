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
    public class GenreContextUnitTest
    {
        private GameDbContext dbContext;
        private GenreContext genreContext;
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
            genreContext = new GenreContext(dbContext);
        }

        [Test]
        public void TestCreateGenre()
        {
            int genresBefore = genreContext.ReadAll().Count();

            genreContext.Create(new Genre("MMORPG"));

            int genresAfter = genreContext.ReadAll().Count();

            Assert.IsTrue(genresBefore != genresAfter);
        }

        [Test]
        public void TestReadGenre()
        {
            genreContext.Create(new Genre("FPS"));

            Genre genre = genreContext.Read(1);

            Assert.That(genre != null, "There is no genre with ID of ''1'' ");
        }

        [Test]
        public void TestUpdateGenre()
        {
            genreContext.Create(new Genre("Action"));

            Genre genre = genreContext.Read(1);

            genre.Name = "Visual Novel";

            genreContext.Update(genre);

            Genre genre1 = genreContext.Read(1);

            Assert.IsTrue(genre1.Name == "Visual Novel", "Genre Update() does not change the genre! СЧУПЕНО Е!!!!!!!!!!!");


        }

        [Test]
        public void TestDeleteGenre()
        {
            genreContext.Create(new Genre("Delete genre!"));

            int genreBeforeDeletion = genreContext.ReadAll().Count();

            genreContext.Delete(1);

            int genreAfterDeletion = genreContext.ReadAll().Count();

            Assert.AreNotEqual(genreBeforeDeletion, genreAfterDeletion);
        }
    }
}