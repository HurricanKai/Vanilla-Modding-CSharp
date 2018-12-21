using fNbt;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Core
{
    public class StructureBlock
    {
        public static int StructureBlockIndex { get; private set; } = 0;
        public static NbtFile Template { get; } = new NbtFile("./Resources/template.nbt");

        public string[] Commands { get; set; }
        public string Name { get; set; }

        static StructureBlock()
        {
            DetectStructureIndex();
        }

        public static void DetectStructureIndex()
        {
            while (File.Exists(World.WorldPath + @"datapacks\csmods\data\csmods\structures\cmd" + StructureBlockIndex + ".nbt"))
                StructureBlockIndex++;
            StructureBlockIndex--;
            Console.WriteLine("Detected Structure Block Index " + StructureBlockIndex);
        }

        public NbtFile GetNBT()
        {
            try
            {
                var b = Template;

                b.RootTag["blocks"].ToList().First(tag =>
                {
                    var pos = tag["pos"].ToList();
                    return pos[0].IntValue == 0 && pos[1].IntValue == 0 && pos[2].IntValue == 0;
                })["nbt"]["name"] = new NbtString("name", "csmods:cmd" + (++StructureBlockIndex + 1));

                for (int i = 0, z = 1; z <= 10; z++)
                {
                    if (i >= Commands.Length)
                        break;
                    for (int y = 0; y <= 10; y++)
                    {
                        if (i >= Commands.Length)
                            break;
                        for (int x = 0; x <= 10; x++)
                        {
                            if (i >= Commands.Length)
                                break;

                            b.RootTag["blocks"].ToList().First(tag =>
                            {
                                var pos = tag["pos"].ToList();
                                return pos[0].IntValue == x && pos[1].IntValue == y && pos[2].IntValue == z;
                            })["nbt"]["Command"] = new NbtString("Command", Commands[i++]);
                        }
                    }
                }
                return b;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occured while Creating Structure Block");
                throw;
            }
        }
    }
}