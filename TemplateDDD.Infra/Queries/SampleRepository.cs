using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateDDD.Infra.Repositories
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
        private const string QueryUpdate = @"UPDATE [dbo].[Sample]
                                                   SET [Description] = @Description
                                                   WHERE [Id] = @Id";
        private const string QueryDelete = @"DELETE FROM [dbo].[Sample]
                                                   WHERE [Id] = @Id";
    }
}

//CREATE TABLE[dbo].[Sample]
//(
//   [Id] INT NOT NULL PRIMARY KEY IDENTITY,
//   [Description] VARCHAR(500) NOT NULL
//)

