namespace FileUpload.Application.UnitTests;

[CollectionDefinition(CollectionName)]
public class WebAppFactoryCollection : ICollectionFixture<WebAppFactory>
{
    public const string CollectionName = "WebAppFactoryCollection";
}
