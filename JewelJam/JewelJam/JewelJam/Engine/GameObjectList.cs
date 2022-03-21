using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

class GameObjectList : GameObject
{
    List<GameObject> children;
    public GameObjectList()
    {
        children = new List<GameObject>();
    }
    public void AddChild(GameObject child)
    {
        children.Add(child);
    }
    public override void Update(GameTime gameTime)
    {
        foreach(GameObject child in children)
        {
            child.Update(gameTime);
        }
    }
    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        foreach (GameObject child in children)
        {
            child.Draw(gameTime,spriteBatch);
        }
    }
    public override void HandleInput(InputHelper inputHelper)
    {
        foreach (GameObject child in children)
        {
            child.HandleInput(inputHelper);
        }
    }
    public override void Reset()
    {
        foreach (GameObject child in children)
        {
            child.Reset();
        };
    }
}
