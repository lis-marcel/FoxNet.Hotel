using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxNet.Hotel.BO.Test
{
    [TestClass]
    public class DbStorageBOTest
    {
        [TestMethod]
        public void TestDbConstructor()
        {
            var db = new DbStorage.DbStorage();

            var dbCreated = db.Database.EnsureCreated();

            Assert.AreEqual(true, dbCreated);

            db.Database.EnsureDeleted();
        }
    }
}
