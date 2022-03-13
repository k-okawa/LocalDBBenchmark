using System.Collections.Generic;
using System.IO;
using BenchmarkDotNet.Attributes;
using LiteDB;
using SQLite;

namespace DBBenchmark
{
    [MinColumn, MaxColumn]
    public class DBInsertBenchmark
    {
        public class Data
        {
            [PrimaryKey, AutoIncrement]
            public int id { get; set; }
            [Indexed]
            public string name { get; set; }
            public int status { get; set; }
        }

        [Params(100,10000,100000)]
        public int insertCount;
        
        private string _liteDbPath;
        private string _sqlitePath;

        [GlobalSetup]
        public void SetUp()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            _liteDbPath = Path.Combine(currentDirectory, "litedb.db");
            _sqlitePath = Path.Combine(currentDirectory, "sqlite.db");
            if (File.Exists(_liteDbPath))
            {
                File.Delete(_liteDbPath);
            }
            if (File.Exists(_sqlitePath))
            {
                File.Delete(_sqlitePath);
            }
        }


        [IterationSetup(Target = nameof(LiteDBInsert))]
        public void LiteDBInsertSetUp()
        {
            using (var db = new LiteDatabase(_liteDbPath))
            {
                db.DropCollection("dataList");
            }
        }
        
        [Benchmark]
        public void LiteDBInsert()
        {
            using (var db = new LiteDatabase(_liteDbPath))
            {
                var col = db.GetCollection<Data>("dataList");
                List<Data> insertList = new List<Data>();
                for (int i = 0; i < insertCount; i++)
                {
                    insertList.Add(new Data()
                    {
                        id = i + 1,
                        name = $"Asset{i}",
                        status = 0
                    });
                }
                col.InsertBulk(insertList);
                col.EnsureIndex(x => x.name);
            }
        }

        [IterationSetup(Target = nameof(SQLiteInsert))]
        public void SQLiteInsertSetUp()
        {
            using (var db = new SQLiteConnection(_sqlitePath))
            {
                db.DropTable<Data>();
            }
        }
        
        [Benchmark]
        public void SQLiteInsert()
        {
            using (var db = new SQLiteConnection(_sqlitePath))
            {
                db.CreateTable<Data>();
                List<Data> insertList = new List<Data>();
                for (int i = 0; i < insertCount; i++)
                {
                    insertList.Add(new Data()
                    {
                        name = $"Asset{i}",
                        status = 0
                    });
                }
        
                db.InsertAll(insertList);
            }
        }
    }
}