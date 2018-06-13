# Exline.Framework.Data.Sql.Dapper

[![Build status](https://ci.appveyor.com/api/projects/status/8rbgoxqio76ynj4h?svg=true)](https://ci.appveyor.com/project/StackExchange/dapper)

Dapper micro orm toolunu kullanarak base repository classlarını içeren yardımcı kütüphanedir.

async olarak işlemleri gerçekleştirir.


## Api

- **[BaseSqlDBDapperRepository<T>](#BaseSqlDBDapperRepository)**
- **[ISqlDBDapperRepository<T>](#ISqlDBDapperRepository)**


## BaseSqlDBDapperRepository

kaynak: Dh.Framework.Data.Sql.Dapper.dll

namespace: Dh.Framework.Data.Sql.Dapper.Repositories

Dapper orm toollunu kullanan bir repository classı oluşturmak için kullanılan abstract classtır.

### Örnek
```csharp
    class Member
        : IDocument<int>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }

    class MemberSqlRepository
        : BaseSqlDBDapperRepository<Member>
    {

    }
```
