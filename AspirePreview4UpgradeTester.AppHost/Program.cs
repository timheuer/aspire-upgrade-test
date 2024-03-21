var builder = DistributedApplication.CreateBuilder(args);

// aspire.hosting
var cache = builder.AddRedis("cache");
var oracle = builder.AddOracleDatabase("db1");
var mysql = builder.AddMySql("db2");
var pgdb = builder.AddPostgres("db3");
var kaf = builder.AddKafka("k1");
var mongo = builder.AddMongoDB("db4");
var mq = builder.AddRabbitMQ("mq1");
var sql = builder.AddSqlServer("db5");
var node = builder.AddNodeApp("node1", "");

// aspire.hosting.azure
var appcfg = builder.AddAzureAppConfiguration("appconfig");
var insights = builder.AddAzureApplicationInsights("insights");
var cosmos = builder.AddAzureCosmosDB("cosmosdb");
var kv = builder.AddAzureKeyVault("kv");
var aoai = builder.AddAzureOpenAI("aoai");
var search = builder.AddAzureSearch("azsearch");
var bus = builder.AddAzureServiceBus("svcbus");
var sr = builder.AddAzureSignalR("sr");
var storage = builder.AddAzureStorage("storage");
var bicep = builder.AddBicepTemplate("bicep1", "foo.bicep");


var apiService = builder.AddProject<Projects.AspirePreview4UpgradeTester_ApiService>("apiservice");

builder.AddProject<Projects.AspirePreview4UpgradeTester_Web>("webfrontend")
    .WithReference(cache)
    .WithReference(apiService);

builder.Build().Run();
