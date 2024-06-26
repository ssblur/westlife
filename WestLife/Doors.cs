using System;
using TinyLife.World;
using TinyLife.Objects;
using TinyLife.Utilities;
using MLEM.Textures;
using System.ComponentModel;

namespace WestLife.Doors {
    class OpeningTypes(
        string name,
        TextureRegion textureRegion, 
        TextureRegion icon = null
    ): OpeningType (
        WestLifeMod.Info.Id + "." + name,
        textureRegion,
        WallMode.Door,
        1250,
        ColorScheme.Load(WestLifeMod.LUT[0, 0]),
        Door.Construct,
        icon
    ) {
        static OpeningType SaloonDoorType;
        static OpeningType HalfDoorType;

        public static void Setup() {
            SaloonDoorType = Register(new OpeningTypes(
                "SaloonDoor",
                Furniture.FurnitureTypes.FurnitureAtlas[0, 0, 1, 3]
            ));
            HalfDoorType = Register(new OpeningTypes(
                "HalfDoor",
                Furniture.FurnitureTypes.FurnitureAtlas[2, 0, 1, 3]
            ));
        }
    }
}