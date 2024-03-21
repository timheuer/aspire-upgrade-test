var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");
var oracle = builder.AddOracleDatabase("db1");
var mysql = builder.AddMySql("db2");
var pgdb = builder.AddPostgres("db3");
var kaf = builder.AddKafka("k1");
var mongo = builder.AddMongoDB("db4");
var mq = builder.AddRabbitMQ("mq1");
var sql = builder.AddSqlServer("db5");
var node = builder.AddNodeApp("node1", "");


var apiService = builder.AddProject<Projects.AspirePreview4UpgradeTester_ApiService>("apiservice");

builder.AddProject<Projects.AspirePreview4UpgradeTester_Web>("webfrontend")
    .WithReference(cache)
    .WithReference(apiService);

builder.Build().Run();
