using System.Collections.Generic;
using System.IO;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LiteDB;
using SQLite;

namespace DBBenchmark
{
    [MinColumn, MaxColumn]
    public class DBGetCollectionBenchmark
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
            
            LiteDBInsert();
            SQLiteInsert();
        }
        
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
                        id = i + 1,
                        name = $"Asset{i}",
                        status = 0
                    });
                }

                db.InsertAll(insertList);
            }
        }

        [Benchmark]
        public void LiteDBGetCollection()
        {
            using (var db = new LiteDatabase(_liteDbPath))
            {
                var col = db.GetCollection<Data>("dataList");
                var result = col.FindAll().ToList();
            }
        }

        [Benchmark]
        public void SQLiteGetCollection()
        {
            using (var db = new SQLiteConnection(_sqlitePath))
            {
                var result = db.Table<Data>().ToList();
            }
        }
    }
}