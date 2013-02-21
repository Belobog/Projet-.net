SELECT aspnet_Document.DocumentName, aspnet_Users.UserName 
                            FROM aspnet_Document,aspnet_DocumentInUsers,aspnet_Users
                            Where aspnet_Document.DocumentId = aspnet_DocumentInUsers.DocumentId
                            AND aspnet_DocumentInUsers.UsersId = aspnet_Users.UserId