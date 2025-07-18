using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class TakingTurnsQueue_Tests
{
    [TestMethod]
    public void PersonWithFiniteTurnsEventuallyLeaves()
    {
        // ✅ Expect "Alice" to appear 3 times then stop
        var queue = new TakingTurnsQueue();
        queue.AddPerson("Alice", 3);

        Assert.AreEqual("Alice", queue.GetNextPerson());
        Assert.AreEqual("Alice", queue.GetNextPerson());
        Assert.AreEqual("Alice", queue.GetNextPerson());

        // Now Alice is done, next call should throw
        Assert.ThrowsException<InvalidOperationException>(() => queue.GetNextPerson());
    }

    [TestMethod]
    public void PersonWithInfiniteTurnsNeverLeaves()
    {
        // ✅ Expect "Bob" to keep returning forever
        var queue = new TakingTurnsQueue();
        queue.AddPerson("Bob", -1);

        for (int i = 0; i < 5; i++)
        {
            Assert.AreEqual("Bob", queue.GetNextPerson());
        }
    }

    [TestMethod]
    public void MultiplePeopleTakeTurns()
    {
        // ✅ Expect fair rotation
        var queue = new TakingTurnsQueue();
        queue.AddPerson("Alice", 2);  // Appears 2 times
        queue.AddPerson("Bob", 1);    // Appears 1 time
        queue.AddPerson("Carol", 3);  // Appears 3 times

        Assert.AreEqual("Alice", queue.GetNextPerson());  // Alice(1)
        Assert.AreEqual("Bob", queue.GetNextPerson());    // Bob(0)
        Assert.AreEqual("Carol", queue.GetNextPerson());  // Carol(2)
        Assert.AreEqual("Alice", queue.GetNextPerson());  // Alice(0)
        Assert.AreEqual("Carol", queue.GetNextPerson());  // Carol(1)
        Assert.AreEqual("Carol", queue.GetNextPerson());  // Carol(0)

        Assert.ThrowsException<InvalidOperationException>(() => queue.GetNextPerson());
    }
}