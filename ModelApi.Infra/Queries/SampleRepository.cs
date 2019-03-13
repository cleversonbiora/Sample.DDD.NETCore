using System;
using System.Collections.Generic;
using System.Text;

namespace ModelApi.Infra.Repositories
{
    public partial class SampleRepository
    {
        private const string QuerySelectById = @"SELECT *
                                                    FROM [dbo].[Sample]
                                                    WHERE Id = @Id";
        private const string QueryInsert = @"INSERT INTO [dbo].[Sample]
                                                   ([Description]
                                                   )
                                                 OUTPUT inserted.Id
                                                 VALUES
                                                       (@Description
                                                       )";
    }
}

//CREATE TABLE[dbo].[Sample]
//(
//   [Id] INT NOT NULL PRIMARY KEY IDENTITY,
//   [Description] VARCHAR(500) NOT NULL
//)

