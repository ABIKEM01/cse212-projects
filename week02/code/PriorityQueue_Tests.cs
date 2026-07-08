using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
   [TestMethod]
// Scenario: Enqueue several items with different priorities, then dequeue.
// Expected Result: Items come out highest priority first.
// Defect(s) Found: Dequeue did not remove the item, and the loop skipped the last item.
public void TestPriorityQueue_HighestPriorityFirst()
{
    var priorityQueue = new PriorityQueue();
    priorityQueue.Enqueue("Bob", 1);
    priorityQueue.Enqueue("Tim", 3);
    priorityQueue.Enqueue("Sue", 2);

    Assert.AreEqual("Tim", priorityQueue.Dequeue());
    Assert.AreEqual("Sue", priorityQueue.Dequeue());
    Assert.AreEqual("Bob", priorityQueue.Dequeue());
}

[TestMethod]
// Scenario: Enqueue multiple items that share the highest priority.
// Expected Result: Among equal priorities, the one added first comes out first (FIFO).
// Defect(s) Found: Using >= caused a later equal-priority item to be chosen instead of the earlier one.
public void TestPriorityQueue_TiePriorityFifo()
{
    var priorityQueue = new PriorityQueue();
    priorityQueue.Enqueue("Bob", 5);
    priorityQueue.Enqueue("Tim", 5);
    priorityQueue.Enqueue("Sue", 5);

    Assert.AreEqual("Bob", priorityQueue.Dequeue());
    Assert.AreEqual("Tim", priorityQueue.Dequeue());
    Assert.AreEqual("Sue", priorityQueue.Dequeue());
}

[TestMethod]
// Scenario: The highest priority item is at the very end of the queue.
// Expected Result: It is still found and returned.
// Defect(s) Found: The loop condition (Count - 1) skipped the last item.
public void TestPriorityQueue_HighestAtEnd()
{
    var priorityQueue = new PriorityQueue();
    priorityQueue.Enqueue("Bob", 1);
    priorityQueue.Enqueue("Tim", 2);
    priorityQueue.Enqueue("Sue", 5);

    Assert.AreEqual("Sue", priorityQueue.Dequeue());
}

[TestMethod]
// Scenario: Dequeue from an empty queue.
// Expected Result: InvalidOperationException with message "The queue is empty."
// Defect(s) Found: None for this requirement.
public void TestPriorityQueue_Empty()
{
    var priorityQueue = new PriorityQueue();
    try
    {
        priorityQueue.Dequeue();
        Assert.Fail("Exception should have been thrown.");
    }
    catch (InvalidOperationException e)
    {
        Assert.AreEqual("The queue is empty.", e.Message);
    }
    catch (AssertFailedException)
    {
        throw;
    }
    catch (Exception e)
    {
        Assert.Fail($"Unexpected exception of type {e.GetType()} caught: {e.Message}");
    }
}
}