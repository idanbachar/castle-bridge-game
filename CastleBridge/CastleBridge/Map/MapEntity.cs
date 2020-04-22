﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleBridge {
    public class MapEntity {

        private MapEntityName Name;
        private Animation Animation;
        private Text Tooltip;
        public bool IsTouchable;
        private Direction Direction;

        public MapEntity(MapEntityName entityName, MapName mapName, int x, int y, int width, int height, bool isTouchable, Direction direction, float rotation) {
            
            Name = entityName;
            Direction = direction;
            IsTouchable = isTouchable;
            Animation = new Animation("map/" + mapName + "/" + entityName.ToString().Replace("_", " ") + "/" + entityName + "_", new Rectangle(x, y, width, height), 0, 0, 1, 5, true, true);
            Animation.SetDirection(direction);
            Animation.SetRotation(rotation);

            Tooltip = new Text(FontType.Default, string.Empty, new Vector2(x + 50, y - 65), Color.Black, true, Color.Gold);
            Tooltip.SetVisible(false);

            switch (entityName) {
                case MapEntityName.Red_Flower:
                    Tooltip.ChangeText("Press 'E' to eat" +
                        "\n" +
                        "(+15hp)");
                    break;
                case MapEntityName.Stone:
                    Tooltip.ChangeText("Press 'E' to take" +
                        "\n" +
                        "(+1 Stone)");
                    break;
                case MapEntityName.Tree:
                    Tooltip.ChangeText("Press 'E' to cut" +
                        "\n" +
                        "(+5 Woods)");
                    break;
                case MapEntityName.Arrow:
                    Tooltip.ChangeText("Press 'E' to take" +
                        "\n" +
                        "(+1 Arrow)");
                    break;
            }

        }

        public void Update() {
            Animation.Play();
        }

        public MapEntityName GetName() {
            return Name;
        }

        public Animation GetAnimation() {
            return Animation;
        }

        public Direction GetDirection() {
            return Direction;
        }

        public Text GetTooltip() {
            return Tooltip;
        }

        public void Draw() {

            Animation.Draw();
            Tooltip.Draw();
        }
    }
}