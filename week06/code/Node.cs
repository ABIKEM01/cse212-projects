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
    if (value == Data)
    {
        // Value already exists — do not add a duplicate.
        return;
    }

    if (value < Data)
    {
        if (Left is null)
            Left = new Node(value);
        else
            Left.Insert(value);
    }
    else
    {
        if (Right is null)
            Right = new Node(value);
        else
            Right.Insert(value);
    }
}
public bool Contains(int value)
{
    if (value == Data)
    {
        return true; // Found it
    }
    if (value < Data)
    {
        // Look left; if nothing there, it's not in the tree.
        return Left is not null && Left.Contains(value);
    }
    else
    {
        // Look right; if nothing there, it's not in the tree.
        return Right is not null && Right.Contains(value);
    }
}
    public int GetHeight()
{
    int leftHeight = Left is null ? 0 : Left.GetHeight();
    int rightHeight = Right is null ? 0 : Right.GetHeight();
    // This node's height is 1 plus the taller subtree.
    return 1 + Math.Max(leftHeight, rightHeight);
}
}