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

namespace WestLife.Clothing {
    public class Clothing {
        static Dictionary<Point, TextureRegion> BandanaAtlas;
        static Dictionary<Point, TextureRegion> StansonAtlas;

        public static void Initialize(Logger logger, RawContentManager content, RuntimeTexturePacker texturePacker, ModInfo info) {
            texturePacker.Add(
                new UniformTextureAtlas(
                    content.Load<Texture2D>("Bandana"), 
                    12, 
                    17
                ), 
                r => BandanaAtlas = r, 
                1, 
                true
            );
            texturePacker.Add(
                new UniformTextureAtlas(
                    content.Load<Texture2D>("Stanson"), 
                    12, 
                    17
                ), 
                r => StansonAtlas = r, 
                1, 
                true
            );
        }

        public static void Setup() {
            Clothes.Register(
                new Clothes(
                    WestLife.Info.Id + ".Bandana",
                    ClothesLayer.Accessories,
                    BandanaAtlas,
                    new Point(0, 0),
                    40,
                    ClothesIntention.Everyday & 
                    ClothesIntention.Summer & 
                    ClothesIntention.Work & 
                    ClothesIntention.Workout & 
                    ClothesIntention.Party,
                    StylePreference.Masculine,
                    ColorScheme.Flannel
                ) {
                    Icon = WestLife.Info.Mod.Icon
                }
            );
            Clothes.Register(
                new Clothes(
                    WestLife.Info.Id + ".Stanson",
                    ClothesLayer.HeadAccessories,
                    StansonAtlas,
                    new Point(0, 0),
                    200,
                    ClothesIntention.Everyday & 
                    ClothesIntention.Summer & 
                    ClothesIntention.Work & 
                    ClothesIntention.Workout & 
                    ClothesIntention.Party,
                    StylePreference.Masculine,
                    ColorScheme.Load(WestLife.LUT[0, 3])
                ) {
                    Icon = WestLife.Info.Mod.Icon,
                    LayersToHide = ClothesLayer.Hair
                }
            );
        }
    }
}