using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

class RowSelector : SpriteGameObject
{
    int selectedRow;
    JewelGrid grid;

    public RowSelector(JewelGrid grid) : base("spr_selector_frame")
    {
        this.grid = grid;
        selectedRow = 0;
        origin = new Vector2(10, 10);


    }
    public override void HandleInput(InputHelper inputHelper)
    {
        selectedRow = MathHelper.Clamp(selectedRow, 0, grid.Height - 1);
        LocalPosition = grid.GetCellPosition(0, selectedRow);
        if (inputHelper.KeyPressed(Keys.Up))
            selectedRow--;
        else if (inputHelper.KeyPressed(Keys.Down))
            selectedRow++;
        if (inputHelper.KeyPressed(Keys.Left))
            grid.ShiftRowLeft(selectedRow);
        else if (inputHelper.KeyPressed(Keys.Right))
            grid.ShiftRowRight(selectedRow);
    }
}
