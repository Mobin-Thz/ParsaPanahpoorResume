using System;

namespace Resume.Application.Utilities.Generator
{
    public class CodeGenerator
    {
        public static string GenerateUniqCode()
        {
            return Guid.NewGuid().ToString("N");
        }

    }
}
