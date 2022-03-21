using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

class JewelGrid : GameObject
{
    Jewel[,] grid;
    int gridWidth, gridHeight, cellSize;
    

    public int Height { get { return gridHeight; } }
    public int Width { get { return gridWidth; } }
    public JewelGrid(int width, int height, int cellSize)
    {
        gridWidth = width;
        gridHeight = height;
        this.cellSize = cellSize;
        Reset();
    }
    public override void Reset()
    {
        grid = new Jewel[gridWidth,gridHeight];

        for (int x = 0; x < gridWidth; x++)
            for (int y = 0; y < gridHeight; y++)
            {
                grid[x, y] = new Jewel();
                grid[x, y].Parent = this;
                grid[x, y].LocalPosition = new Vector2(x * cellSize, y * cellSize);
            }
    }

    

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        foreach (Jewel jewel in grid)
            jewel.Draw(gameTime, spriteBatch);
    }
    public override void HandleInput(InputHelper inputHelper)
    {
        if (inputHelper.KeyPressed(Keys.Space))
        {
            int mid = Width / 2;
           for(int y = 0; y < Height - 2; y++)
           {
                if (IsValidCombination(grid[mid, y], grid[mid, y + 1], grid[mid, y + 2]))
                {
                    RemoveJewel(mid, y);
                    RemoveJewel(mid, y + 1);
                    RemoveJewel(mid, y + 2);
                    y += 2;
                }
            }           
        }
    }

    private void RemoveJewel(int x, int y)
    {
        for (int row = y; row > 0; row--)
        {
            grid[x, row] = grid[x, row-1];
            grid[x, row].LocalPosition = GetCellPosition(x, row);
        }
        AddJewel(x, 0);

    }

    void AddJewel(int x, int y)
    {
        // store the jewel in the grid
        grid[x, y] = new Jewel();

        // set the parent and position of the jewel
        grid[x, y].Parent = this;
        grid[x, y].LocalPosition = GetCellPosition(x, y);

    }

    bool IsValidCombination(Jewel a, Jewel b, Jewel c)
    {
            return IsConditionValid(a.ColorType, b.ColorType, c.ColorType)
            && IsConditionValid(a.ShapeType, b.ShapeType, c.ShapeType)
            && IsConditionValid(a.NumberType, b.NumberType, c.NumberType);
    }
    bool IsConditionValid(int a, int b, int c)
    {
        return AllEqual(a, b, c) || AllDifferent(a, b, c);
    }
    bool AllEqual(int a, int b, int c)
    {
        return a == b && b == c;
    }
    bool AllDifferent(int a, int b, int c)
    {
        return a != b && b != c && a != c;
    }
    private void MoveRowsDown()
    {

        for (int y = gridHeight - 1; y > 0; y--)
            for (int x = 0; x < gridWidth; x++)
                grid[x, y] = grid[x, y - 1];

        for (int x = 0; x < gridWidth; x++)
        {
            grid[x, 0] = new Jewel();
            grid[x, 0].Parent = this;
        }
            
    }
    public void ShiftRowRight(int selectedRow)
    {
        // store the rightmost jewel as a backup
        Jewel last = grid[Width - 1, selectedRow];
        // replace all jewels by their left neighbor
        for (int x = Width -1; x > 0; x--)
        {
            grid[x, selectedRow] = grid[x - 1, selectedRow];
            grid[x, selectedRow].LocalPosition = GetCellPosition(x, selectedRow);
        }
        // re−insert the old leftmost jewel on the right
        grid[0, selectedRow] = last;
        grid[0, selectedRow].LocalPosition = GetCellPosition(0, selectedRow);
    }

    public void ShiftRowLeft(int selectedRow)
    {
        // store the leftmost jewel as a backup
        Jewel first = grid[0, selectedRow];
        // replace all jewels by their right neighbor
        for (int x = 0; x < Width - 1; x++)
        {
            grid[x, selectedRow] = grid[x + 1, selectedRow];
            grid[x, selectedRow].LocalPosition = GetCellPosition(x, selectedRow);
        }
        // re−insert the old leftmost jewel on the right
        grid[Width - 1, selectedRow] = first;
        grid[Width - 1, selectedRow].LocalPosition = GetCellPosition(Width - 1, selectedRow);
    }
    public Vector2 GetCellPosition(int x, int y)
    {
        return LocalPosition + new Vector2(x * cellSize, y * cellSize);
    }

}
