using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheTurtleChallange;

namespace TheTurtleChallangeTests
{
    [TestClass]
    public class GeneralTests
    {
        [TestMethod]
        public void GetOppositeDirection()
        {
            Direction d = Direction.North;
            Assert.IsTrue(~d == Direction.South);

            d = Direction.East;
            Assert.IsTrue(~d == Direction.West);
        }
    }
}
