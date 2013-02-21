Select * from aspnet_DocumentInUsers
Select * from aspnet_Document
Delete from aspnet_DocumentInUsers where DocumentId in (Select DocumentId From aspnet_Document where DocumentName = 'docdeboriss')