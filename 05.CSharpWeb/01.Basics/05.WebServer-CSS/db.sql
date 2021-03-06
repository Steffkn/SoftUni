USE [GameStoreDb]
GO
SET IDENTITY_INSERT [dbo].[Games] ON 

INSERT [dbo].[Games] ([Id], [Title], [Trailer], [Image], [SizeGB], [Price], [Description], [ReleaseDate]) VALUES (1, N'Raft', N'KTutxuWCnBI', N'https://steamcdn-a.akamaihd.net/steam/apps/648800/header.jpg?t=1527104102', N'12', CAST(19.99 AS Decimal(18, 2)), N'Raft throws you and your friends into an epic oceanic adventure! Alone or together, players battle to survive a perilous voyage across a vast sea! Gather debris, scavenge reefs and build your own floating home, but be wary of the man-eating sharks!', CAST(N'2018-05-31T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Games] ([Id], [Title], [Trailer], [Image], [SizeGB], [Price], [Description], [ReleaseDate]) VALUES (2, N'Wizard of Legend', N'nYKGDXyhH2o', N'https://steamcdn-a.akamaihd.net/steam/apps/445980/header.jpg?t=1526427059', N'1.2', CAST(15.99 AS Decimal(18, 2)), N'Wizard of Legend is a no-nonsense, action-packed take on wizardry that emphasizes precise movements and smart comboing of spells in a rogue-like dungeon crawler that features over a hundred unique spells and relics!', CAST(N'2018-05-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Games] ([Id], [Title], [Trailer], [Image], [SizeGB], [Price], [Description], [ReleaseDate]) VALUES (3, N'Warhammer 40,000: Inquisitor - Martyr', N'Lyk7csqDvCE', N'https://steamcdn-a.akamaihd.net/steam/apps/527430/header.jpg?t=1528289345', N'3.5', CAST(44.99 AS Decimal(18, 2)), N'Enter the Chaos-infested Caligari Sector and purge the unclean with the most powerful agents of the Imperium of Man! W40k: Inquisitor – Martyr is a grim Action-RPG featuring multiple classes of the Inquisition who will carry out the Emperor’s will.', CAST(N'2018-06-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Games] ([Id], [Title], [Trailer], [Image], [SizeGB], [Price], [Description], [ReleaseDate]) VALUES (4, N'Totally Accurate Battlegrounds', N'behpA361zFs', N'https://steamcdn-a.akamaihd.net/steam/apps/823130/header.jpg?t=1528626848', N'2.1', CAST(5.99 AS Decimal(18, 2)), N'Totally Accurate Battlegrounds is a parody of the Battle Royale genre. A bunch of physics-based weirdos fight it out on an island, everything is silly and possibly a bit buggy.', CAST(N'2018-06-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Games] ([Id], [Title], [Trailer], [Image], [SizeGB], [Price], [Description], [ReleaseDate]) VALUES (5, N'House Flipper', N'TQGg2HrRH2I', N'https://steamcdn-a.akamaihd.net/steam/apps/613100/header.jpg?t=1527008309', N'2.3', CAST(5.99 AS Decimal(18, 2)), N'House Flipper is a unique chance to become a one-man renovation crew. Buy, repair and remodel devastated houses. Give them a second life and sell them at a profit!', CAST(N'2018-05-17T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Games] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Email], [PasswordHash], [FullName]) VALUES (1, N'steff@abv.bg', N'cf4b56f0bde44864b7199fa6e9967e6557bd8eaab8cb9953a8b4588e2db77e49', N'Stefan Petrov')
INSERT [dbo].[Users] ([Id], [Email], [PasswordHash], [FullName]) VALUES (2, N'pesho@abv.bg', N'cf4b56f0bde44864b7199fa6e9967e6557bd8eaab8cb9953a8b4588e2db77e49', N'Pesho Stamatov')
INSERT [dbo].[Users] ([Id], [Email], [PasswordHash], [FullName]) VALUES (3, N'tosho@abv.bg', N'cf4b56f0bde44864b7199fa6e9967e6557bd8eaab8cb9953a8b4588e2db77e49', N'tosho peshev')
INSERT [dbo].[Users] ([Id], [Email], [PasswordHash], [FullName]) VALUES (4, N'losho@losho.com', N'cf4b56f0bde44864b7199fa6e9967e6557bd8eaab8cb9953a8b4588e2db77e49', N'losho loshev')
INSERT [dbo].[Users] ([Id], [Email], [PasswordHash], [FullName]) VALUES (5, N'user@user.com', N'cf4b56f0bde44864b7199fa6e9967e6557bd8eaab8cb9953a8b4588e2db77e49', N'Userko')
SET IDENTITY_INSERT [dbo].[Users] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [Name]) VALUES (1, N'Guest')
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (2, N'User')
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (3, N'Admin')
SET IDENTITY_INSERT [dbo].[Roles] OFF
INSERT [dbo].[UserRole] ([UserId], [RoleId]) VALUES (2, 2)
INSERT [dbo].[UserRole] ([UserId], [RoleId]) VALUES (4, 2)
INSERT [dbo].[UserRole] ([UserId], [RoleId]) VALUES (5, 2)
INSERT [dbo].[UserRole] ([UserId], [RoleId]) VALUES (1, 3)
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20180610135405_initial', N'2.1.0-rtm-30799')
