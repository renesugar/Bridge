namespace System.ComponentModel.DataAnnotations
{
    [Bridge.Convention(Member = Bridge.ConventionMember.Field | Bridge.ConventionMember.Method, Notation = Bridge.Notation.CamelCase)]
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        AllowMultiple = false)]
    [Bridge.External]
    [Bridge.NonScriptable]
    public sealed class EmailAddressAttribute : DataTypeAttribute
    {
        public extern EmailAddressAttribute();
    }
}
