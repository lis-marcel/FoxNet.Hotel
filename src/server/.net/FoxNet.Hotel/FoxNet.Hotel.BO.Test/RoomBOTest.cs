using FoxNet.Hotel.BO;
using FoxNet.Hotel.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace FoxNet.Hotel.BO.Test
{
    [TestClass]
    public class RoomBOTest
    {
        #region Test objects
        Room room = new Room()
        {
            RoomId = 1,
            RoomNumber = "101",
            Beds = "3",
            Price = "149.99D",
            Bathroom = true,
        };
        #endregion

        #region Test methods
        /*[TestMethod]
        public void CheckRoomNumber()
        {
            var db = new DbStorage();
            db.Database.EnsureCreated();

            db.Rooms.Add(room);
            db.SaveChanges();

            var foundElement = db.Rooms.Find(1);

            Assert.AreEqual(101, foundElement.Number);

            db.Database.EnsureDeleted();
        }

        [TestMethod]
        public void CheckChangingBedsAmount()
        {
            var decreaseBeds = 2;
            var db = new DbStorage();
            db.Database.EnsureCreated();

            db.Rooms.Add(room);
            db.SaveChanges();

            var foundElement = db.Rooms.Find(1);

            foundElement.BedsAmount -= decreaseBeds;

            db.Rooms.Update(foundElement);
            db.SaveChanges();

            foundElement = db.Rooms.Find(1);

            Assert.AreEqual(1, foundElement.BedsAmount);

            db.Database.EnsureDeleted();
        }

        [TestMethod]
        public void ChangeBookedMarker()
        {
            var db = new DbStorage();
            db.Database.EnsureCreated();

            db.Rooms.Add(room);
            db.SaveChanges();

            var foundElement = db.Rooms.Find(1);
            foundElement.Booked = false;

            db.SaveChanges();
            foundElement = db.Rooms.Find(1);

            Assert.AreEqual(false, foundElement.Booked);

            db.Database.EnsureDeleted();
        }*/
        #endregion
    }
}
