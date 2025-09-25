using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System;
using ExtremelySimpleLogger;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MLEM.Data;
using MLEM.Data.Content;
using MLEM.Textures;
using TinyLife;
using TinyLife.Actions;
using TinyLife.Emotions;
using TinyLife.Mods;
using TinyLife.Objects;
using TinyLife.Tools;
using Newtonsoft.Json.Linq;
using Microsoft.Xna.Framework.Content;
using TinyLife.World;

namespace WestLife {
    public class WestLife : Mod {
        public static readonly CanExecuteResult WaitingRequired = new CanExecuteResult("mustwait");

        public static Logger Logger { get; private set; }
        public override string Name => "WestLife";
        public override string Description => "Welcome to the Tiny, Tiny West!";
        public override string TestedVersionRange => "[0.48.0,0.48.0]";

        public override TextureRegion Icon => WestLife.UITextures[0, 0];
        public override bool RequiresHarmony => false;

        public static UniformTextureAtlas UITextures;
        public static ModInfo Info;

        private static RawContentManager Manager;
        private static Random Generator;

        public static UniformTextureAtlas LUT;

        public override void AddGameContent(GameImpl game, ModInfo info) {
            Doors.OpeningTypes.Setup();
            Furniture.FurnitureTypes.Setup();
            Clothing.Clothing.Setup();
        }

        public override void Initialize(Logger logger, RawContentManager content, RuntimeTexturePacker texturePacker, ModInfo info) {
            Logger = logger;
            Manager = content;
            Info = info;
            Generator = new Random();

            texturePacker.Add(
                content.Load<Texture2D>("UiTextures"), 
                r => WestLife.UITextures = new UniformTextureAtlas(r, 2, 2)
            );
            
            texturePacker.Add(
                content.Load<Texture2D>("WestLifeLUT"), 
                r => LUT = new UniformTextureAtlas(r, 1, 16)
            );
            
            Furniture.FurnitureTypes.Initialize(logger, content, texturePacker, info);
            Doors.OpeningTypes.Initialize(logger, content, texturePacker, info);
            Clothing.Clothing.Initialize(logger, content, texturePacker, info);
        }
        public override IEnumerable<string> GetCustomFurnitureTextures(ModInfo info) {
            yield return "WestLifeFurniture";
        }
    }
}