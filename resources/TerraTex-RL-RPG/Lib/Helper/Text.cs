using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TerraTex_RL_RPG.Lib.Helper
{
    static class TextHelper
    {
        public static string RemoveColorStrings(string text)
        {
            Regex rgx = new Regex("~[A-Za-z]~|~#[0-9A-Za-z]{3,6}~");
            return rgx.Replace(text, "");
        }
    }
}
