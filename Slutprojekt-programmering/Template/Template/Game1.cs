using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
    using System.Collections.Generic;

namespace Template
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //KOmentar
        private Texture2D racer;
        private Texture2D enemy;

        private Vector2 racerPos = new Vector2(350, 300);
        private Vector2 enemyPos = new Vector2(200,  100);
        private Vector2 enemyPos2 = new Vector2(300,  100);
        private Vector2 enemyPos3 = new Vector2(400,  100);

        KeyboardState kNewState;
        KeyboardState kOldState;


        public Game1()
        {

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            racer = Content.Load<Texture2D>("racer");
            enemy = Content.Load<Texture2D>("racer");

            // TODO: use this.Content to load your game content here 
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            kNewState = Keyboard.GetState();

            // TODO: Add your update logic here
            if (kNewState.IsKeyDown(Keys.Right) && kOldState.IsKeyUp(Keys.Right)){
                enemyPos.X -= 200;
                enemyPos2.X -= 200;
                enemyPos3.X -= 200;
                }//flyttar motståndare och boarder till vänster för att använadren ska flyttas till höger
            
            if (kNewState.IsKeyDown(Keys.Left) && kOldState.IsKeyUp(Keys.Left)){
                enemyPos.X += 200;
                enemyPos2.X += 200;
                enemyPos3.X += 200;
            } //flyttar motståndare och boarder till höger för att använadren ska flyttas till väster


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here.
            spriteBatch.Begin();



            spriteBatch.Draw(racer, racerPos, Color.White);
            spriteBatch.Draw(enemy, enemyPos, Color.White);
            spriteBatch.Draw(enemy, enemyPos2, Color.White);
            spriteBatch.Draw(enemy, enemyPos3, Color.White);
             
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
