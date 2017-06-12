﻿using System;
using System.Reflection;
using TitanBotBase.Util;

namespace TitanBotBase.Commands
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class AliasAttribute : Attribute
    {
        private string[] Value { get; }

        public AliasAttribute(string[] names = null)
        {
            Value = names;
        }

        public static string[] GetFor(Type type)
            => type.GetCustomAttribute<AliasAttribute>()?.Value ?? new string[0];
        public static bool ExistsOn(Type type)
            => type.GetCustomAttribute<AliasAttribute>() != null;

        public static string[] GetFor(MethodInfo method)
            => method.GetCustomAttribute<AliasAttribute>()?.Value ?? new string[0];
        public static bool ExistsOn(MethodInfo method)
            => method.GetCustomAttribute<AliasAttribute>() != null;
    }
}