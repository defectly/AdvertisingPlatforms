using Domain.Entities;
using System.Text.Json.Serialization;

[JsonSerializable(typeof(Platform[]))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{

}