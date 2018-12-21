using fNbt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public static class NbtExtensions
    {
        public static NbtList ToList(this NbtTag tag) => (NbtList)tag;
    }
}
