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
    }
}
