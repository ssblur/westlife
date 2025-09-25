using System;
using System.Collections.Generic;
using TinyLife.World;
using TinyLife.Objects;
using TinyLife.Utilities;
using MLEM.Textures;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;

namespace WestLife.Doors {
    class OpeningTypes(
        string name,
        Point point, 
        TextureRegion icon = null
    ): OpeningType (
        WestLife.Info.Id + "." + name,
        Furniture.FurnitureTypes.FurnitureAtlas.ToDictionary(),
        point,
        WallMode.Door,
        1250,
        ColorScheme.Load(WestLife.LUT[0, 0]),
        1.0f,
        null,
        icon
    ) {
        static OpeningType SaloonDoorType;
        static OpeningType HalfDoorType;

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