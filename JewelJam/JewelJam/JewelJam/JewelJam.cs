using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

class JewelJam : ExtendedGame
{
    public JewelJam()
    {
        
        Content.RootDirectory = "Content";
        IsMouseVisible = true;   
    }
    protected override void LoadContent()
    {
        base.LoadContent();
        worldSize = GameWorld.Size;
        FullScreen = false;
    }
}
