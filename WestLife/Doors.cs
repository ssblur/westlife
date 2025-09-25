using System;
using System.Collections.Generic;
using TinyLife.World;
using TinyLife.Objects;
using TinyLife.Utilities;
using MLEM.Textures;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ExtremelySimpleLogger;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MLEM.Data;
using MLEM.Data.Content;
using TinyLife.Mods;

namespace WestLife.Doors {
    class OpeningTypes(
        string name,
        Point point, 
        TextureRegion icon = null
    ): OpeningType (
        WestLife.Info.Id + "." + name,
        Atlas.ToDictionary(),
        point,
        WallMode.Door,
        1250,
        ColorScheme.Load(WestLife.LUT[0, 0]),
        1.0f,
        null,
        icon
    ) {
        public static UniformTextureAtlas Atlas;
        static OpeningType SaloonDoorType;
        static OpeningType HalfDoorType;
        
        public static void Initialize(Logger logger, RawContentManager content, RuntimeTexturePacker texturePacker, ModInfo info) {
            texturePacker.Add(
                content.Load<Texture2D>("WestLifeDoors"), 
                r => Atlas = new UniformTextureAtlas(r, 8, 16)
            );
        }

        public static void Setup() {
            SaloonDoorType = Register(new OpeningTypes(
                "SaloonDoor",
                new Point(0, 0)
            ));
            HalfDoorType = Register(new OpeningTypes(
                "HalfDoor",
                new Point(2, 0)
            ));
        }
    }
}