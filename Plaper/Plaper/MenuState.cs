﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plaper {

    //game state class
    class MenuState : State {

        Player player;
        GraphicsDeviceManager graphics;

        Texture2D menuButtonTexture;
        SpriteFont font;
        bool      mouseOverStart;
        bool      mouseOverSettings;
        Rectangle settingsButtonPosition;
        Rectangle startButtonPosition;
        const string START_TEXT = "START";
        const string SETTINGS_TEXT = "SETTINGS";
        Vector2 startTextPosition;
        Vector2 settingsTextPosition;

        const  float TEXT_SCALE  = 2.5f;
        static Color HOVER_COLOR = Color.White;
        static Color TEXT_COLOR  = Color.Black;


        //ctor
        public MenuState(Player player, SpriteFont font, GraphicsDeviceManager graphics) {
            this.player = player;
            this.font = font;
            this.graphics = graphics;

            //stuff for button texture
            menuButtonTexture = new Texture2D(graphics.GraphicsDevice, 20, 10);
            Color[] startTextureData = new Color[20*10];
            for (int i = 0; i < startTextureData.Length; i++) {
                startTextureData[i] = Color.Chocolate;
            }
            menuButtonTexture.SetData(startTextureData);

            //setting where the buttons will be
            settingsButtonPosition = new Rectangle(0, Game1.SCREEN_HEIGHT-(Game1.SCREEN_HEIGHT/10)-Game1.SCREEN_HEIGHT/5, Game1.SCREEN_WIDTH, Game1.SCREEN_HEIGHT/5);
            startButtonPosition = new Rectangle(0, settingsButtonPosition.Y-settingsButtonPosition.Height-(Game1.SCREEN_HEIGHT/10), Game1.SCREEN_WIDTH, Game1.SCREEN_HEIGHT/5);

            Vector2 startTextSize = this.font.MeasureString(START_TEXT);
            startTextPosition.Y = (startButtonPosition.Height - startTextSize.Y) / 2 + startButtonPosition.Y;
            startTextPosition.X = (startButtonPosition.Width  - startTextSize.X) / 2 + startButtonPosition.X;

            Vector2 settingsTextSize = this.font.MeasureString(SETTINGS_TEXT);
            settingsTextPosition.Y = (settingsButtonPosition.Height - settingsTextSize.Y) / 2 + settingsButtonPosition.Y;
            settingsTextPosition.X = (settingsButtonPosition.Width  - settingsTextSize.X) / 2 + settingsButtonPosition.X;
        }

        //update for game logic
        public override void Update(GameTime gameTime) {

            //check where mouse is and do stuff if it's clicked
            var mouseState = Mouse.GetState();
            var mousePosition = new Point(mouseState.X, mouseState.Y);

            mouseOverStart    = startButtonPosition.Contains(mousePosition);
            mouseOverSettings = settingsButtonPosition.Contains(mousePosition);

            if(mouseState.LeftButton == ButtonState.Pressed) {
                if(mouseOverStart) {
                    State.setState(new GameState(player, graphics));
                } else if (mouseOverSettings) {
                    State.setState(new SettingsState(player, graphics));
                }
            }
        }

        //update graphics
        public override void Draw(SpriteBatch spriteBatch) {

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise);

            //start button
            spriteBatch.Draw(menuButtonTexture, startButtonPosition, Color.White);

            //settings button
            spriteBatch.Draw(menuButtonTexture, settingsButtonPosition, Color.White);

            spriteBatch.DrawString(font, START_TEXT, startTextPosition, mouseOverStart ? HOVER_COLOR : TEXT_COLOR);
            spriteBatch.DrawString(font, SETTINGS_TEXT, settingsTextPosition, mouseOverSettings ? HOVER_COLOR : TEXT_COLOR);

            spriteBatch.End();

        }
    }
}