using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using ZeldaAdventures.Controls;

namespace ZeldaAdventures.Maps.House
{
    class Bed : MapObject
    {
        int mAlphaValue = 1;
        int mFadeIncrement = 3;
        double mFadeDelay = .035;
        int cycleCount = 0;
        bool sleeping = false;
        bool promptReady = true;
        public Prompt _prompt;

        public Bed() : base(new Rectangle(700, 10, 40, 60))
        {
            _prompt = new Prompt("Do you want to go to bed?", "Yes", "No", () => { 
                cycleCount = 0;
                sleeping = true;
                promptReady = false; 
            }, () => { 
                promptReady = false;
                Game1.State = GameState.Running;
            });
        }

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
        }

        public override void Update(GameTime gameTime)
        {
            _prompt.Update(gameTime);

            if (sleeping)
            {
                //Decrement the delay by the number of seconds that have elapsed since
                //the last time that the Update method was called
                mFadeDelay -= gameTime.ElapsedGameTime.TotalSeconds;

                //If the Fade delays has dropped below zero, then it is time to 
                //fade in/fade out the image a little bit more.
                if (mFadeDelay <= 0)
                {
                    //Reset the Fade delay
                    mFadeDelay = .035;

                    //Increment/Decrement the fade value for the image
                    mAlphaValue += mFadeIncrement;

                    //If the AlphaValue is equal or above the max Alpha value or
                    //has dropped below or equal to the min Alpha value, then 
                    //reverse the fade
                    if (mAlphaValue >= 255 || mAlphaValue <= 0)
                    {
                        cycleCount++;
                        mFadeIncrement *= -1;
                    }

                    if (cycleCount == 2)
                    {
                        sleeping = false;
                        Game1.State = GameState.Running;
                    }
                }
            }


            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (LinkCollided)
            {
                if(promptReady && !sleeping)
                { 
                    _prompt.Draw(gameTime, spriteBatch);
                }
            }
            else
            {
                promptReady = true;
            }

            if(sleeping)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(SharedContent.Blank, new Rectangle(0, 0, 800, 480),
                    color: new Color(0, 0, 0, MathHelper.Clamp(mAlphaValue, 0, 255)));
                spriteBatch.End();
            }
        }
    }
}
