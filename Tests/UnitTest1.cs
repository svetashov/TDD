using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
