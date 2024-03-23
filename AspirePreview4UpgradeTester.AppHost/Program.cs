var builder = DistributedApplication.CreateBuilder(args);

// aspire.hosting
var cache = builder.AddRedis("cache"); //Aspire.Hosting.Redis
var oracle = builder.AddOracleDatabase("db1")
    .AddDatabase("baz"); //Aspire.Hosting.Oracle
var mysql = builder.AddMySql("db2"); //Aspire.Hosting.MySql
var pgdb = builder.AddPostgres("db3")
    .AddDatabase("foo"); //Aspire.Hosting.PostreSQL
var kaf = builder.AddKafka("k1"); //Aspire.Hosting.Kafka
var mongo = builder.AddMongoDB("db4"); //Aspire.Hosting.MongoDB
var mq = builder.AddRabbitMQ("mq1"); //Aspire.Hosting.RabbitMQ
var sql = builder.AddSqlServer("db5")
    .AddDatabase("bar"); //Aspire.Hosting.SqlServer
var node = builder.AddNodeApp("node1", ""); //Aspire.Hosting.NodeJs

// aspire.hosting.azure
var appcfg = builder.AddAzureAppConfiguration("appconfig"); //Aspire.Hosting.Azure.AppConfiguration
var insights = builder.AddAzureApplicationInsights("insights"); //Aspire.Hosting.Azure.ApplicationInsights
var cosmos = builder.AddAzureCosmosDB("cosmosdb"); //Aspire.Hosting.Azure.CosmosDB
var kv = builder.AddAzureKeyVault("kv"); //Aspire.Hosting.Azure
var aoai = builder.AddAzureOpenAI("aoai"); //Aspire.Hosting.Azure.CognitiveServices
var search = builder.AddAzureSearch("azsearch"); //Aspire.Hosting.Azure.Search
var bus = builder.AddAzureServiceBus("svcbus"); //Aspire.Hosting.Azure.ServiceBus
var sr = builder.AddAzureSignalR("sr"); //Aspire.Hosting.Azure.SignalR
var storage = builder.AddAzureStorage("storage"); //Aspire.Hosting.Azure.Storage
var bicep = builder.AddBicepTemplate("bicep1", "foo.bicep"); //Aspire.Hosting.Azure


var apiService = builder.AddProject<Projects.AspirePreview4UpgradeTester_ApiService>("apiservice");

builder.AddProject<Projects.AspirePreview4UpgradeTester_Web>("webfrontend")
    .WithReference(cache)
    .WithReference(apiService);

builder.Build().Run();
