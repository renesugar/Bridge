// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Runtime.InteropServices
{
    [Bridge.NonScriptable]
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Interface | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Delegate | AttributeTargets.Enum | AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Property, Inherited = false)]
    public sealed class ComVisibleAttribute : Attribute
    {
        public ComVisibleAttribute(bool visibility)
        {
            Value = visibility;
        }

        public bool Value { get; }
    }
}
