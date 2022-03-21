using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
class JewelJamGameWorld : GameObjectList
{
    const int GridWidth = 5;
    const int GridHeight = 10;
    const int CellSize = 85;
    public Point Size { get; set; }
    public int Score { get; set; }
    public JewelJamGameWorld()
    {
        //add the background
        SpriteGameObject background = new SpriteGameObject("spr_background");
        Size = new Point(background.Width,background.Height);
        AddChild(background);

        GameObjectList playingField = new GameObjectList();
        playingField.LocalPosition = new Vector2(85, 150);
        AddChild(playingField);

        JewelGrid grid = new JewelGrid(GridWidth, GridHeight, CellSize);
        playingField.AddChild(grid);

        playingField.AddChild(new RowSelector(grid));

        // add a background sprite for the score object
        SpriteGameObject scoreFrame = new SpriteGameObject("spr_scoreframe");
        scoreFrame.LocalPosition = new Vector2(20, 20);
        AddChild(scoreFrame);

        // add the object that displays the score
        ScoreGameObject scoreObject = new ScoreGameObject();
        scoreObject.LocalPosition = new Vector2(270, 30);
        AddChild(scoreObject);

        Reset();

    }
    public void AddScore(int points)
    {
        Score += points;
    }
    public override void Reset()
    {
        base.Reset();
        Score = 0;
    }
}
