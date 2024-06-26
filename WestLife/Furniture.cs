using TinyLife.Objects;
using TinyLife.Utilities;
using Microsoft.Xna.Framework;
using MLEM.Misc;
using MLEM.Data;
using MLEM.Data.Content;
using TinyLife.Tools;
using ExtremelySimpleLogger;
using TinyLife.Mods;using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System;
using Microsoft.Xna.Framework.Graphics;
using MLEM.Textures;
using TinyLife;
using TinyLife.Actions;
using TinyLife.Emotions;
using Newtonsoft.Json.Linq;
using Microsoft.Xna.Framework.Content;
using System.ComponentModel;

namespace WestLife.Furniture {
    class FurnitureTypes {
        public static UniformTextureAtlas FurnitureAtlas;

        public static void Initialize(Logger logger, RawContentManager content, RuntimeTexturePacker texturePacker, ModInfo info) {
            texturePacker.Add(
                content.Load<Texture2D>("WestLifeFurniture"), 
                r => FurnitureAtlas = new UniformTextureAtlas(r, 8, 64)
            );
        }

        public static void Setup() {
            FurnitureType.Register(new FurnitureType.TypeSettings(
                WestLifeMod.Info.Id + ".CowSkull",
                new Point(1, 1),
                ObjectCategory.WallHanging,
                400,
                ColorScheme.Load(WestLifeMod.LUT[0, 0]),
                ColorScheme.White
            ) {
                Icon = WestLifeMod.Info.Mod.Icon,
                DefaultRotation = Direction2.Down,
                Tab = FurnitureTool.Tab.Decoration & FurnitureTool.Tab.LivingRoom,
            });
            FurnitureType.Register(new FurnitureType.TypeSettings(
                WestLifeMod.Info.Id + ".Spitoon",
                new Point(1, 1),
                ObjectCategory.TrashCan & ObjectCategory.SmallObject,
                100,
                ColorScheme.Load(WestLifeMod.LUT[0, 2])
            ) {
                Icon = WestLifeMod.Info.Mod.Icon,
                ConstructedType = typeof(TrashCan),
                Tab = FurnitureTool.Tab.Decoration & FurnitureTool.Tab.Outside,
            });
        }
    }
}