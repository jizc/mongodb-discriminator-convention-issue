using DiscriminatorConventionIssue.Types;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

var objectSerializer = new ObjectSerializer(
    type => ObjectSerializer.DefaultAllowedTypes(type)
            || (type.FullName is { } fullName && fullName.StartsWith("DiscriminatorConventionIssue", StringComparison.Ordinal)));
BsonSerializer.RegisterSerializer(objectSerializer);
BsonSerializer.RegisterDiscriminatorConvention(typeof(JsonTypedObject), new ScalarDiscriminatorConvention("__type"));

var myCat = new Cat { Name = "Fluffy" };
var updateAction = new SetMemberUpdateAction
{
    MemberName = "animal",
    Value = myCat
};

var updateBuilder = Builders<BsonDocument>.Update;
var update = updateBuilder.Set(updateAction.MemberName, updateAction.Value);

var renderArgs = new RenderArgs<BsonDocument>(
    BsonSerializer.SerializerRegistry.GetSerializer<BsonDocument>(),
    BsonSerializer.SerializerRegistry);
var bsonValue = update.Render(renderArgs);

Console.WriteLine(bsonValue.ToString());
