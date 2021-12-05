using Microsoft.VisualStudio.TestTools.UnitTesting;
using LruCache;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EmptyCache_Pop_ThrowsEmptyCacheException()
        {
            ILruCache<int, int> squareRoots = new LruCache<int, int>(3);

            Assert.ThrowsException<CacheEmptyException>(() => squareRoots[16]);
        }

        [TestMethod]
        public void EmptyCache_Add_CountOneAndPopTheSame()
        {
            ILruCache<int, int> squareRoots = new LruCache<int, int>(3);

            squareRoots.Add(4, 2);

            int root4 = squareRoots[4];
            int count = squareRoots.Count();

            Assert.AreEqual(2, root4);
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void FullCache_Add_RemovedFirstAdded()
        {
            ILruCache<int, int> squareRoots = new LruCache<int, int>(3);
            squareRoots.Add(1, 1);
            squareRoots.Add(4, 2);
            squareRoots.Add(9, 3);

            squareRoots.Add(16, 4);
            int root16 = squareRoots[16];
            int root9 = squareRoots[9];
            int root4 = squareRoots[4];
            int count = squareRoots.Count();
            bool contains1 = squareRoots.Contains(1);

            Assert.AreEqual(4, root16);
            Assert.AreEqual(3, root9);
            Assert.AreEqual(2, root4);
            Assert.AreEqual(3, count);
            Assert.IsFalse(contains1);
        }
    }
}
