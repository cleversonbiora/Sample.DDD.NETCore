using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateDDD.Infra.Repositories
{
    public partial class TesteRepository
    {
        private const string QuerySelectById = @"SELECT *
                                                    FROM [dbo].[Teste]
                                                    WHERE Id = @Id";
        private const string QueryInsert = @"INSERT INTO [dbo].[Teste]
                                                   ([Desc]
                                                   )
                                                 OUTPUT inserted.Id
                                                 VALUES
                                                       (@Desc
                                                       )";
        private const string QueryUpdate = @"UPDATE [dbo].[Teste]
                                                   SET [Desc] = @Desc
                                                   WHERE [Id] = @Id";
        private const string QueryDelete = @"DELETE FROM [dbo].[Teste]
                                                   WHERE [Id] = @Id";
    }
}

//CREATE TABLE[dbo].[Teste]
//(
//   [Id] INT NOT NULL PRIMARY KEY IDENTITY,
//   [Description] VARCHAR(500) NOT NULL
//)

