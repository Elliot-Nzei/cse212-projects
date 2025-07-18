using System;
using System.Collections.Generic;

public class TakingTurnsQueue
{
    private Queue<(string name, int turns)> queue = new Queue<(string, int)>();

    public void AddPerson(string name, int turns)
    {
        queue.Enqueue((name, turns));
    }

    public string GetNextPerson()
    {
        if (queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        var (name, turns) = queue.Dequeue();

        if (turns == -1)  // Infinite turns
        {
            queue.Enqueue((name, turns));
        }
        else if (turns > 1)  // Has more turns left
        {
            queue.Enqueue((name, turns - 1));
        }

        return name;
    }
}