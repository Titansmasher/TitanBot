﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TitanBotBase.Util;

namespace TitanBotBase.Commands
{
    public struct ArgumentInfo
    {
        public ParameterInfo Parameter { get; }
        public Type Type { get; }
        public object DefaultValue { get; }
        public bool IsDense { get; }
        public bool IsRawArgument { get; }
        public bool HasDefaultValue { get; }
        public string Name { get; }
        public bool UseDefault { get; }
        public FlagDefinition Flag { get; }

        private ArgumentInfo(ParameterInfo parameter, bool useDefault)
        {
            Parameter = parameter;
            UseDefault = useDefault;
            IsDense = DenseAttribute.ExistsOn(parameter);
            Type = Parameter.ParameterType;
            DefaultValue = Parameter.DefaultValue;
            IsRawArgument = RawArgumentsAttribute.ExistsOn(parameter);
            HasDefaultValue = Parameter.HasDefaultValue;
            Name = NameAttribute.GetFor(Parameter);
            Flag = CallFlagAttribute.GetFor(Parameter);
            if (IsDense && Flag != null)
                throw new InvalidOperationException("Cannot have a dense flag parameter");
        }

        internal static IEnumerable<ArgumentInfo[]> BuildPermetations(MethodInfo method)
        {
            var parameters = method.GetParameters().TakeWhile(p => !CallFlagAttribute.ExistsOn(p));
            var required = parameters.Where(p => !p.HasDefaultValue);
            var optional = parameters.Where(p => p.HasDefaultValue);

            var requiredMask = Enumerable.Range(0, required.Count())
                                         .Select(v => true)
                                         .ToArray();
            foreach (var optionalMask in IEnumerableUtil.BinomialMask(optional.Count()))
            {
                var fullMask = requiredMask.Concat(optionalMask).ToArray();
                var args = parameters.Select((p, i) => new ArgumentInfo(p, !fullMask[i])).ToArray();
                if (args.Count(a => a.IsDense) <= 1)
                    yield return args;
            }
        }

        internal static ArgumentInfo[] BuildFrom(MethodInfo call)
            => call.GetParameters().Select(p => new ArgumentInfo(p, false)).ToArray();

        public override string ToString()
        {
            if (Flag != null)
                return Flag.ToString();

            var format = "{0}";
            if (HasDefaultValue)
                format = string.Format("[{0}]", format);
            else
                format = string.Format("<{0}>", format);

            if (typeof(IEnumerable<>).IsAssignableFrom(Type) || Type.IsArray)
                format = string.Format("{0}...", format);

            return string.Format(format, Name);
        }
    }
}
