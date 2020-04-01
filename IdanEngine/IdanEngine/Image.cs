﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdanEngine {
    public class Image {

        private Texture2D Texture;
        private Rectangle Rectangle;
        private Color Color;
        private bool Visible;
        public string FullPath;

        public Image(string imageFolderPath, string imageName, int x, int y, int width, int height, Color imageColor) {

            FullPath = imageFolderPath.Length == 0 ? imageName : (imageFolderPath + "/" + imageName);
            LoadImage(FullPath);
            Rectangle = new Rectangle(x, y, width, height);
            Color = imageColor;
            Visible = true;
        }

        private void LoadImage(string fullPath) {

            try {
                Texture = Game1.PublicContent.Load<Texture2D>("images/" + fullPath);
            }catch(Exception e) {
                Console.WriteLine(e.Message);
                Texture = Game1.PublicContent.Load<Texture2D>("images/undefined");
            }
        }

        public void SetNewImage(string fullPath) {

            LoadImage(fullPath);
        }

        public void SetNewRectangle(int x, int y, int width, int height) {

            Rectangle.X = x;
            Rectangle.Y = y;
            Rectangle.Width = width;
            Rectangle.Height = height;
        }

        public void SetVisible(bool value) {
            Visible = value;
        }

        public Rectangle GetRectangle() {
            return Rectangle;
        }

        public void Draw() {

            //Game1.SpriteBatch.Begin();

            if (Visible)
                Game1.SpriteBatch.Draw(Texture, Rectangle, Color);

            //Game1.SpriteBatch.End();
        }
    }
}
