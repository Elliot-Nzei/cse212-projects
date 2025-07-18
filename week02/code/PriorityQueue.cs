using System;
using System.Collections.Generic;
using System.Linq;

public class PriorityQueue<T>
{
    private List<(T item, int priority, int index)> queue = new();
    private int insertionIndex = 0;

    public void Enqueue(T item, int priority)
    {
        queue.Add((item, priority, insertionIndex));
        insertionIndex++;
    }

    public T Dequeue()
    {
        if (queue.Count == 0)
            throw new InvalidOperationException("The queue is empty.");

        var highest = queue
            .OrderByDescending(x => x.priority)
            .ThenBy(x => x.index)
            .First();

        queue.Remove(highest);
        return highest.item;
    }

    public int Count => queue.Count;
}