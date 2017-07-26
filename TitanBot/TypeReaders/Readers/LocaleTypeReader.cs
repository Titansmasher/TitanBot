﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitanBot.Commands;
using TitanBot.Formatting;

namespace TitanBot.TypeReaders
{
    class LocaleTypeReader : TypeReader
    {
        public override Task<TypeReaderResponse> Read(ICommandContext context, string value)
        {
            if (context.TextManager.GetLanguageCoverage(value) > 0)
                return Task.FromResult(TypeReaderResponse.FromSuccess((Locale)value));
            return Task.FromResult(TypeReaderResponse.FromError("TYPEREADER_UNABLETOREAD", value, typeof(Locale)));
        }
    }
}