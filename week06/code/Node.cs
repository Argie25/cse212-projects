public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
    if (value < Data)
    {
        if (Left is null)
            Left = new Node(value);
        else
            Left.Insert(value);
    }
    else if (value > Data)  // Only insert if value is greater
    {
        if (Right is null)
            Right = new Node(value);
        else
            Right.Insert(value);
    }
    // else: value == Data -> do nothing (skip duplicates)
    }

    public bool Contains(int value)
    {
    if (value == Data)
        return true;
    else if (value < Data)
        return Left?.Contains(value) ?? false; // If Left is null, return false
    else // value > Data
        return Right?.Contains(value) ?? false; // If Right is null, return false
    }

    public int GetHeight()
    {
    int leftHeight = Left?.GetHeight() ?? 0;   // Height of left subtree
    int rightHeight = Right?.GetHeight() ?? 0; // Height of right subtree

    return 1 + Math.Max(leftHeight, rightHeight); // Height of current node
    }
}