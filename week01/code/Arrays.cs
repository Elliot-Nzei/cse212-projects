public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // PLAN for Problem 1: MultiplesOf
        // Step 1: Create a new array of size 'length'
        // Step 2: Loop from 0 to length - 1
        // Step 3: For each index i, set array[i] = number * (i + 1)
        // Step 4: Return the array

        double[] result = new double[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  
    /// For example, if the data is List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and amount is 3 
    /// then the list after the function runs should be List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.
    ///
    /// Because a list is dynamic, this function will modify the existing data list 
    /// rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // PLAN for Problem 2: RotateListRight
        // Step 1: Calculate split index = data.Count - amount
        // Step 2: Slice the list into two parts using GetRange:
        //         - tail = data.GetRange(split, amount)
        //         - head = data.GetRange(0, split)
        // Step 3: Clear the original list
        // Step 4: Add tail then head back into data using AddRange

        int splitIndex = data.Count - amount;
        List<int> tail = data.GetRange(splitIndex, amount);
        List<int> head = data.GetRange(0, splitIndex);

        data.Clear();
        data.AddRange(tail);
        data.AddRange(head);
    }
}
