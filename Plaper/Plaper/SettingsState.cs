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
    class SettingsState : State {

        Button[] buttonArr = new Button[2];

        const string BACK_TEXT = "BACK";

        //ctor
        public SettingsState(GraphicsDeviceManager graphics, Game1 game) : base(graphics, game) {

            buttonArr[0] = new Button(BACK_TEXT, buttonTexture, 
                new Rectangle(0, (Game1.buttonHeight/2) + (nButtons * Game1.buttonHeight),
                Plaper.playWidth, Game1.buttonHeight));
            nButtons++;

            /*buttonArr[1] = new Button("FULLSCREEN", buttonTexture, 
                new Rectangle(0, (Game1.buttonHeight/2) + (nButtons * Game1.buttonHeight) + 50,
                Plaper.playWidth, Game1.buttonHeight));
            nButtons++;*/
        }

        //update for game logic
        public override void Update(GameTime gameTime) {

            for (int i = 0; i < nButtons; ++i) {
                buttonArr[i].Update(gameTime);
            }

            //check where mouse is and do stuff if it's clicked
            if(Keyboard.GetState().IsKeyDown(Keys.Escape)) {
                State.setState(new MenuState(graphics, game));
            }


            //check if mouse button has just been depressed
            if(buttonArr[0].Clicked()) {
                State.setState(new MenuState(graphics, game));
            }

            /*if (buttonArr[1].Clicked()) {
                var displayMode = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode;
                if (graphics.IsFullScreen) {
                    graphics.PreferredBackBufferHeight = 600;
                    graphics.PreferredBackBufferWidth = 400;
                } else {
                    graphics.PreferredBackBufferHeight = displayMode.Height;
                    graphics.PreferredBackBufferWidth = displayMode.Width;
                }
                graphics.IsFullScreen = !graphics.IsFullScreen;
                graphics.ApplyChanges();
            }*/

        }

        //update graphics
        public override void Draw(SpriteBatch spriteBatch) {
            for (int i = 0; i < nButtons; ++i) {
                buttonArr[i].Draw(spriteBatch);
            }
        }
    }
}