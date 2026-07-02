public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
public static double[] MultiplesOf(double number, int length)
{
    // Plan:
    // 1. We know exactly how many values we need (length), so make an
    //    array of that size up front.
    // 2. Loop from index 0 up to length - 1.
    // 3. At each index i, the multiple is number * (i + 1) because the
    //    first multiple (index 0) should be number * 1, not number * 0.
    // 4. Store that value in the array at index i.
    // 5. Return the filled array.

    double[] multiples = new double[length];
    for (int i = 0; i < length; i++)
    {
        multiples[i] = number * (i + 1);
    }
    return multiples;
}

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
 public static void RotateListRight(List<int> data, int amount)
{
    // Plan:
    // 1. Rotating right by 'amount' means the last 'amount' items should
    //    move to the front, and the remaining items follow after them.
    //    Example: {1,2,3,4,5,6,7,8,9} rotated by 3 -> {7,8,9,1,2,3,4,5,6}
    //    The last 3 items {7,8,9} moved to the front.
    // 2. Grab the tail: the last 'amount' items. They start at index
    //    (Count - amount) and there are 'amount' of them.
    // 3. Grab the head: everything before that, from index 0 up for
    //    (Count - amount) items.
    // 4. Clear the list, then add the tail first, then the head.
   

    List<int> tail = data.GetRange(data.Count - amount, amount);
    List<int> head = data.GetRange(0, data.Count - amount);

    data.Clear();
    data.AddRange(tail);
    data.AddRange(head);
}
}
