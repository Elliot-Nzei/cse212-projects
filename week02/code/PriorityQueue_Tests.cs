using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueue_Tests
{
    [TestMethod]
    public void EnqueueAndDequeue_HighestPriorityFirst()
    {
        var pq = new PriorityQueue<string>();
        pq.Enqueue("Low", 1);
        pq.Enqueue("High", 5);
        pq.Enqueue("Medium", 3);

        // ✅ High should come out first
        Assert.AreEqual("High", pq.Dequeue());
        Assert.AreEqual("Medium", pq.Dequeue());
        Assert.AreEqual("Low", pq.Dequeue());
    }

    [TestMethod]
    public void SamePriority_RespectsOrderAdded()
    {
        var pq = new PriorityQueue<string>();
        pq.Enqueue("First", 2);
        pq.Enqueue("Second", 2);
        pq.Enqueue("Third", 2);

        // ✅ Order added should be respected
        Assert.AreEqual("First", pq.Dequeue());
        Assert.AreEqual("Second", pq.Dequeue());
        Assert.AreEqual("Third", pq.Dequeue());
    }

    [TestMethod]
    public void EmptyQueue_ThrowsException()
    {
        var pq = new PriorityQueue<int>();
        Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
    }
}