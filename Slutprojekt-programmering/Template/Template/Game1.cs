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


        private Vector2 racerPos = new Vector2(350, 200);
        private Vector2 enemyPos = new Vector2(150,  100);
        private Vector2 enemyPos2 = new Vector2(350,  100);
        private Vector2 enemyPos3 = new Vector2(550,  100);

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
                }//flyttar motståndare till vänster för att använadren ska flyttas till höger
            
            if (kNewState.IsKeyDown(Keys.Left) && kOldState.IsKeyUp(Keys.Left)){
                enemyPos.X += 200;
                enemyPos2.X += 200;
                enemyPos3.X += 200;
            } //flyttar motståndare till höger för att använadren ska flyttas till väster

            if (enemyPos3.X  < 350){
                enemyPos.X = -50;
                enemyPos2.X = 150;
                enemyPos3.X = 350;
            }//begränsar området du kan flytta dig till höger i X led

            if (enemyPos.X > 350){ 
                enemyPos.X = 350;
                enemyPos2.X = 550;
                enemyPos3.X = 750;
                }//begränsar området du kan flytta dig till vänster i X led

            if (enemyPos.Y >= 500) { 
                enemyPos.Y=-100;
                enemyPos2.Y=-100;
                enemyPos3.Y=-100;
            }

            enemyPos.Y+=2;
            enemyPos2.Y+=2;
            enemyPos3.Y+=2;

            

             kOldState = kNewState;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here.
            spriteBatch.Begin();



            spriteBatch.Draw(racer, new Rectangle(racerPos.ToPoint(), new Point(50,100)), Color.White);
            spriteBatch.Draw(enemy, new Rectangle(enemyPos.ToPoint(), new Point(50,100)), Color.White);
            spriteBatch.Draw(enemy, new Rectangle(enemyPos2.ToPoint(), new Point(50,100)), Color.White);
            spriteBatch.Draw(enemy, new Rectangle(enemyPos3.ToPoint(), new Point(50,100)), Color.White);
             
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
