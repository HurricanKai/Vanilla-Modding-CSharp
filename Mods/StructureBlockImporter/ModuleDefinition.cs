using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace StructureBlockImporter
{
    public class ModuleDefinition : ICustomCommandModule
    {
        public String Name { get; } = "Structure Block Importer";

        public CustomCommand[] CustomCommands { get; } = new CustomCommand[]
            {
                new ImportStructure(),
            };
    }
}
