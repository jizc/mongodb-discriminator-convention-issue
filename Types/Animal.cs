using MongoDB.Bson.Serialization.Attributes;

namespace DiscriminatorConventionIssue.Types;

[BsonKnownTypes(typeof(Cat), typeof(Dog))]
public abstract class Animal : JsonTypedObject;

public sealed class Cat : Animal
{
    [BsonElement("name")]
    public string? Name { get; set; }
}

public sealed class Dog : Animal
{
    [BsonElement("name")]
    public string? Name { get; set; }
}
