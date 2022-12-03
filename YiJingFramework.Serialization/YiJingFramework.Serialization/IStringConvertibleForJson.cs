using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace YiJingFramework.Serialization
{
    public interface IStringConvertibleForJson<TSelf> where TSelf : IStringConvertibleForJson<TSelf>
    {
        abstract static bool FromStringForJson(string s, [MaybeNullWhen(false)] out TSelf result);

        string ToStringForJson();
    }
}