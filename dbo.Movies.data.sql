SET IDENTITY_INSERT [dbo].[Movies] ON
INSERT INTO [dbo].[Movies] ([Id], [Name], [GenreId], [ReleaseDate], [DateAdded], [NumberInStock]) VALUES (1, N'Hangover', 5, N'2005-01-01 00:00:00', N'2005-02-01 00:00:00', 5)
INSERT INTO [dbo].[Movies] ([Id], [Name], [GenreId], [ReleaseDate], [DateAdded], [NumberInStock]) VALUES (3, N'Die Hard', 1, N'2006-02-02 00:00:00', N'2006-02-03 00:00:00', 10)
INSERT INTO [dbo].[Movies] ([Id], [Name], [GenreId], [ReleaseDate], [DateAdded], [NumberInStock]) VALUES (4, N'The Terminator', 1, N'2007-03-03 00:00:00', N'2007-03-04 00:00:00', 16)
INSERT INTO [dbo].[Movies] ([Id], [Name], [GenreId], [ReleaseDate], [DateAdded], [NumberInStock]) VALUES (5, N'Toy Story', 3, N'2008-04-04 00:00:00', N'2008-04-05 00:00:00', 20)
INSERT INTO [dbo].[Movies] ([Id], [Name], [GenreId], [ReleaseDate], [DateAdded], [NumberInStock]) VALUES (6, N'Titanic', 4, N'2009-05-05 00:00:00', N'2009-05-06 00:00:00', 15)
SET IDENTITY_INSERT [dbo].[Movies] OFF
