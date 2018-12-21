using fNbt;
using System;
using System.Collections.Generic;

namespace Core
{
    public class World
    {
        public List<User> Players = new List<User>();
        public static string WorldName;
        public static string WorldPath { get => @"C:\Users\HurricanKai\AppData\Roaming\.minecraft\saves\" + WorldName + @"\"; }

        public void CreateStructureBlock(StructureBlock structureBlock)
        {
            var f = structureBlock.GetNBT();
            f.SaveToFile(WorldPath + @"datapacks\csmods\data\csmods\structures\cmd" + StructureBlock.StructureBlockIndex + ".nbt", NbtCompression.GZip);
        }

        public void SendCommands(string name, params string[] commands)
        {
            CreateStructureBlock(new StructureBlock() { Name = name, Commands = commands });
        }
    }
}