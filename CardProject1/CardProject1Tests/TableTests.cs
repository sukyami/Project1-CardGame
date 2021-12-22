using Microsoft.VisualStudio.TestTools.UnitTesting;
using CardProject1;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardProject1.Tests
{
    [TestClass()]
    public class TableTests
    {
        [TestMethod()]
        public void TableTest()
        {
            Table table = new Table();

            Assert.IsTrue(table.Empty());
        }
        [TestMethod()]
        public void playGameTest()
        {
            Table table = new Table();
            table.playGame();

            Assert.IsTrue(table.Empty());
        }

        [TestMethod()]
        public void getGameTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void getPlayerNameTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void getCardTest()
        {
            Table table = new Table();
            table.getCard(1);

            Assert.IsTrue(!table.Empty());
        }

        [TestMethod()]
        public void PrintCardTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void replaceCardTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void remainCardTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void getCardValueTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EmptyTest()
        {
            Table table = new Table();
            table.getCard(1);

            Assert.IsTrue(!table.Empty());
        }

        
    }
}