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
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // PLAN (step-by-step) -------------------------------------------------
        // 1. Create an array of doubles with size 'length'.
        // 2. For each index i from 0 to length-1, compute the (i+1)-th multiple of 'number'.
        // - The first element should be number * 1, the second number * 2, etc.
        // 3. Store that multiple into the array at index i.
        // 4. After the loop completes, return the filled array.
        //
        // Notes / assumptions:
        // - The XML docs state that 'length' is a positive integer greater than 0, so no exception
        // handling is strictly necessary here. If you want defensive code, you can check and
        // throw an ArgumentException for length <= 0.
        // - Using doubles allows fractional numbers (e.g., MultiplesOf(2.5, 3) -> {2.5, 5.0, 7.5}).
        // --------------------------------------------------------------------


        // Optional defensive check (uncomment if you prefer strict validation):
        // if (length <= 0) throw new ArgumentException("length must be a positive integer greater than 0", nameof(length));


        // Step 1: create the result array
        double[] result = new double[length];


        // Step 2 & 3: fill the array with multiples of 'number'
        for (int i = 0; i < length; i++)
        {
        // (i + 1) because the sequence starts at 1 * number
        result[i] = number * (i + 1);
        }


        // Step 4: return the filled array
        return result;
            // TODO Problem 1 End
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
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // PLAN (step-by-step) -------------------------------------------------
        // 1. Understand the goal: rotate the list to the right by 'amount' positions.
        // - The element that was at index data.Count - amount should become index 0.
        // - The last 'amount' elements should move to the front in the same order.
        // 2. Validate assumptions (based on the problem statement):
        // - amount is guaranteed to be between 1 and data.Count (inclusive), so no
        // need for special handling of 0 or values larger than Count.
        // 3. Choose an approach: Use List slicing (GetRange / RemoveRange / InsertRange)
        // because it's simple and easy to read.
        // Steps using slicing:
        // a. Take a copy of the last 'amount' elements using GetRange(startIndex, count).
        // b. Remove those same elements from the end of the original list using RemoveRange.
        // c. Insert the copied elements at the beginning of the list using InsertRange(0, slice).
        // 4. Alternative approach (not implemented here):
        // - Create a new list and compute target index for each element using modulo:
        // newIndex = (i + amount) % data.Count
        // or perform in-place reversal algorithm (reverse whole list, reverse two partitions).
        // --------------------------------------------------------------------


        // Defensive check (optional): if you want to allow amounts larger than Count,
        // you could reduce it with: amount = amount % data.Count; but the problem guarantees
        // amount is between 1 and data.Count, inclusive.


        // Step a: copy the last 'amount' elements
        int startIndex = data.Count - amount;
        List<int> tail = data.GetRange(startIndex, amount);


        // Step b: remove those elements from the end
        data.RemoveRange(startIndex, amount);


        // Step c: insert the copied elements at the front
        data.InsertRange(0, tail);


        // After these steps, 'data' has been rotated right by 'amount'.
        // TODO Problem 2 End
    }
}
