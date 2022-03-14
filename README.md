# LocalDBBenchmark
Benchmark LiteDB and SQLite

[Qiita](https://qiita.com/KyoheiOkawa/items/903768bec2f801ef3c7c)

# Results

## InsertBulk(class:DBInsertBenchmark)
|       Method | insertCount |        Mean |     Error |     StdDev |      Median |         Min |         Max |
|------------- |------------ |------------:|----------:|-----------:|------------:|------------:|------------:|
| LiteDBInsert |         100 |    12.98 ms |  0.457 ms |   1.333 ms |    12.50 ms |    10.63 ms |    16.48 ms |
| SQLiteInsert |         100 |    18.56 ms |  0.440 ms |   1.270 ms |    18.35 ms |    16.54 ms |    22.15 ms |
| LiteDBInsert |       10000 |   325.93 ms |  6.463 ms |  10.975 ms |   326.41 ms |   296.67 ms |   342.32 ms |
| SQLiteInsert |       10000 |    84.65 ms |  6.556 ms |  18.706 ms |    79.68 ms |    60.74 ms |   140.95 ms |
| LiteDBInsert |      100000 | 4,613.43 ms | 91.210 ms | 235.442 ms | 4,543.66 ms | 4,176.39 ms | 5,163.66 ms |
| SQLiteInsert |      100000 |   615.54 ms | 12.134 ms |   9.473 ms |   615.57 ms |   599.93 ms |   629.06 ms |

## GetAllRecords(class:DBGetCollectionBenchmark)
### 100Records
|              Method |     Mean |    Error |   StdDev |      Min |      Max |
|-------------------- |---------:|---------:|---------:|---------:|---------:|
| LiteDBGetCollection | 901.8 us | 17.47 us | 18.69 us | 874.2 us | 946.9 us |
| SQLiteGetCollection | 659.4 us | 13.05 us | 28.08 us | 618.0 us | 741.3 us |

### 10,000Records
|              Method |     Mean |    Error |   StdDev |      Min |      Max |
|-------------------- |---------:|---------:|---------:|---------:|---------:|
| LiteDBGetCollection | 33.45 ms | 0.418 ms | 0.391 ms | 32.57 ms | 33.98 ms |
| SQLiteGetCollection | 13.90 ms | 0.277 ms | 0.647 ms | 12.99 ms | 15.66 ms |

### 100,000Recores
|              Method |     Mean |   Error |  StdDev |      Min |      Max |
|-------------------- |---------:|--------:|--------:|---------:|---------:|
| LiteDBGetCollection | 375.1 ms | 6.99 ms | 6.54 ms | 367.0 ms | 386.0 ms |
| SQLiteGetCollection | 143.7 ms | 2.18 ms | 1.93 ms | 140.7 ms | 147.8 ms |

## Find&Update(class:DBUpdateBenchmark)
|                 Method | insertCount |     Mean |    Error |   StdDev |   Median |       Min |      Max |
|----------------------- |------------ |---------:|---------:|---------:|---------:|----------:|---------:|
| LiteDBUpdateCollection |         100 | 11.70 ms | 0.360 ms | 0.956 ms | 11.66 ms |  9.308 ms | 14.33 ms |
| SQLiteUpdateCollection |         100 | 13.99 ms | 0.461 ms | 1.238 ms | 13.75 ms | 11.749 ms | 18.25 ms |
| LiteDBUpdateCollection |       10000 | 11.37 ms | 0.243 ms | 0.648 ms | 11.47 ms |  9.852 ms | 13.18 ms |
| SQLiteUpdateCollection |       10000 | 15.46 ms | 0.893 ms | 2.549 ms | 14.58 ms | 12.668 ms | 22.13 ms |
| LiteDBUpdateCollection |      100000 | 12.70 ms | 0.492 ms | 1.370 ms | 12.38 ms | 10.353 ms | 16.77 ms |
| SQLiteUpdateCollection |      100000 | 14.09 ms | 0.479 ms | 1.302 ms | 13.82 ms | 11.359 ms | 18.18 ms |
