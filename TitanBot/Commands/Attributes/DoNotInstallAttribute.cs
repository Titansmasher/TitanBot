﻿using System;
using System.Reflection;

namespace TitanBot.Commands
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class DoNotInstallAttribute : Attribute
    {
        public static bool ExistsOn(MethodInfo info)
            => info.GetCustomAttribute<DoNotInstallAttribute>() != null || ExistsOn(info.DeclaringType);
        public static bool ExistsOn(Type info)
            => info.GetCustomAttribute<DoNotInstallAttribute>() != null;
    }
}
