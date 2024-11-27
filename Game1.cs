using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tracking__Time__and_Sound
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        Texture2D bombTexture;
        Rectangle bombRect;
        Texture2D explosionTexture;
        Rectangle explosionRect;
        SpriteFont timeFont;

        SoundEffect explode;

        float seconds;

        bool exploded;

        MouseState mouseState;
        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

           
            exploded = false;

            base.Initialize();
            explosionRect = new Rectangle(50, 50, 700, 400);
            bombRect = new Rectangle(50, 50, 700, 400);
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 500;  
            _graphics.ApplyChanges();
            seconds = 0f;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            bombTexture = Content.Load<Texture2D>("bomb");
            timeFont = Content.Load<SpriteFont>("File");
            explode = Content.Load<SoundEffect>("explosion");
            explosionTexture = Content.Load<Texture2D>("images");
           
          
            
        }

        protected override void Update(GameTime gameTime)
            
        {
            seconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (seconds > 15)
            {
                seconds = 0f;
                explode.Play();
                exploded = true;
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            if (seconds > 10 && exploded)
            {
                Exit();
            }

            // TODO: Add your update logic here

            mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                seconds = 0f;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.Draw(bombTexture, bombRect, Color.White);
            _spriteBatch.DrawString(timeFont, (15 - seconds).ToString("00.0"), new Vector2(270, 200), Color.Black);
            
            if (exploded)
            {
                _spriteBatch.Draw(explosionTexture, explosionRect, Color.White);
                
            }
              
         
            

            
            
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
