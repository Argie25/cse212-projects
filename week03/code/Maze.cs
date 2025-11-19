using System;
using System.Collections.Generic;

public class Maze
{
    private Dictionary<(int, int), bool[]> map;
    private int x, y;

    public Maze(Dictionary<(int, int), bool[]> map)
    {
        this.map = map;
        this.x = 1;  // Starting position
        this.y = 1;
    }

    public string GetStatus()
    {
        return $"Current location (x={x}, y={y})";
    }

    public void MoveUp()
    {
        var newPos = (x, y - 1);
        if (!map.ContainsKey(newPos) || !map[newPos][2])  // Check if target exists and "down" wall is open (since we're entering from below)
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        y--;
    }

    public void MoveDown()
    {
        var newPos = (x, y + 1);
        if (!map.ContainsKey(newPos) || !map[newPos][0])  // Check if target exists and "up" wall is open (since we're entering from above)
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        y++;
    }

    public void MoveLeft()
    {
        var newPos = (x - 1, y);
        if (!map.ContainsKey(newPos) || !map[newPos][1])  // Check if target exists and "right" wall is open (since we're entering from the right)
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        x--;
    }

    public void MoveRight()
    {
        var newPos = (x + 1, y);
        if (!map.ContainsKey(newPos) || !map[newPos][3])  // Check if target exists and "left" wall is open (since we're entering from the left)
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        x++;
    }
}