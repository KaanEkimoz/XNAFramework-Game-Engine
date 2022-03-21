using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

class GameObject
{
    protected Vector2 velocity;

    public Vector2 LocalPosition { get; set; }
    public bool Visible { get; set; }
    public GameObject Parent { get; set; }
    public Vector2 GlobalPosition
    {
        get
        {
            if (Parent == null)
                return LocalPosition;
            return LocalPosition + Parent.GlobalPosition;
        }
    }

    public GameObject()
    {
        LocalPosition = Vector2.Zero;
        velocity = Vector2.Zero;
    }

    public virtual void HandleInput(InputHelper inputHelper)
    {

    }
    public virtual void Update(GameTime gameTime)
    {
        LocalPosition += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
    }

    public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {

    }
    public virtual void Reset()
    {
        velocity = Vector2.Zero;
    }
}
