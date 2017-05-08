﻿using System;
using System.Threading.Tasks;
using TitanBot2.Services.CommandService;

namespace TitanBot2.TypeReaders
{
    public abstract class TypeReader
    {
        public abstract Task<TypeReaderResult> Read(TitanbotCmdContext context, string value);
    }
}
