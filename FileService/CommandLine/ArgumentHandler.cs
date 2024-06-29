﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileService.CommandLine
{
    public class ArgumentHandler
    {
        public string[] Args;

        public ArgumentHandler(string[] args)
        {
            Args = args;
        }

        protected bool IsValidIndex(int index)
        {
            return index >= 0 && index < Args.Length;
        }
    }
}
