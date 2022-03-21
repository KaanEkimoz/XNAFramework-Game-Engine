using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

class ScoreGameObject : TextGameObject
{
    public ScoreGameObject() : base("JewelJamFont", Color.White, Alignment.Right) 
    { 
    }

    public override void Update(GameTime gameTime)
    {
        Text = JewelJam.GameWorld.Score.ToString();
    }
}
