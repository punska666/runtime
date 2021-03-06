// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Reflection;

namespace System.Text.Json
{
    /// <summary>
    /// Represents a strongly-typed parameter to prevent boxing where have less than 4 parameters.
    /// Holds relevant state like the default value of the parameter, and the position in the method's parameter list.
    /// </summary>
    internal class JsonParameterInfo<T> : JsonParameterInfo
    {
        public T TypedDefaultValue { get; private set; } = default!;

        public override void Initialize(
            Type runtimePropertyType,
            ParameterInfo parameterInfo,
            JsonPropertyInfo matchingProperty,
            JsonSerializerOptions options)
        {
            base.Initialize(
                runtimePropertyType,
                parameterInfo,
                matchingProperty,
                options);

            if (parameterInfo.HasDefaultValue)
            {
                DefaultValue = parameterInfo.DefaultValue;
                TypedDefaultValue = (T)parameterInfo.DefaultValue!;
            }
            else
            {
                DefaultValue = TypedDefaultValue;
            }
        }
    }
}
