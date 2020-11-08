using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonSpaceshipsGame.Migrations
{
    public partial class addData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT [dbo].[PersonCards] ([Id], [Mass], [Name], [CardType]) VALUES (N'58e9c1f8-6017-49cb-a07f-0cdf82efa01d', 25, N'Brave Person', N'Person')
                                    GO
                                    INSERT[dbo].[PersonCards]([Id], [Mass], [Name], [CardType]) VALUES(N'083faa7b-1fda-4dac-ba09-14a63857f1d9', 1, N'Funny Person', N'Person')
                                    GO
                                    INSERT[dbo].[PersonCards] ([Id], [Mass], [Name], [CardType]) VALUES(N'b5378c90-caa6-41e1-ab4d-1dd624fc401e', 35, N'Popular Person', N'Person')
                                    GO
                                    INSERT[dbo].[PersonCards] ([Id], [Mass], [Name], [CardType]) VALUES(N'baaed6d4-eba1-46f1-945e-5eab629b9ee4', 2, N'Nice Person', N'Person')
                                    GO
                                    INSERT[dbo].[PersonCards] ([Id], [Mass], [Name], [CardType]) VALUES(N'32dc22ed-c7c1-4d69-9b05-667484824ab4', 70, N'Loud Person', N'Person')
                                    GO
                                    INSERT[dbo].[PersonCards] ([Id], [Mass], [Name], [CardType]) VALUES(N'e70c09e6-8f1f-40f9-8e1d-739e81d7fca8', 20, N'Shy Person', N'Person')
                                    GO
                                    INSERT[dbo].[PersonCards] ([Id], [Mass], [Name], [CardType]) VALUES(N'fca28765-d903-4ced-9453-904aa02be26a', 55, N'Pretty Person', N'Person')
                                    GO
                                    INSERT[dbo].[Players] ([Id], [Points]) VALUES(N'09d9b6ee-03d8-4d92-b974-44c8c2189a7c', 0)
                                    GO
                                    INSERT[dbo].[Players] ([Id], [Points]) VALUES(N'2dd5aae4-7fb3-4d6a-a679-7c971466f1bb', 0)
                                    GO
                                    INSERT[dbo].[Players] ([Id], [Points]) VALUES(N'2be4b52a-e8b4-4183-86cd-7e000e3361d0', 0)
                                    GO
                                    INSERT[dbo].[Players] ([Id], [Points]) VALUES(N'9996f7c3-adeb-40b1-bb22-a04fe47bb9cd', 0)
                                    GO
                                    INSERT[dbo].[SpaceshipCards] ([Id], [CrewCount], [Name], [CardType]) VALUES(N'9eba4d17-da9f-4a74-aa57-1f2f5c19fc6e', 8, N'Large Spaceship', N'Spaceship')
                                    GO
                                    INSERT[dbo].[SpaceshipCards] ([Id], [CrewCount], [Name], [CardType]) VALUES(N'01e91ca7-8645-49a2-9703-1ff9df819dfa', 4, N'Smaller Spaceship', N'Spaceship')
                                    GO
                                    INSERT[dbo].[SpaceshipCards] ([Id], [CrewCount], [Name], [CardType]) VALUES(N'27e3fdcd-2a90-471e-8ed6-5608f3ac9ec4', 15, N'The Spaceship', N'Spaceship')
                                    GO
                                    INSERT[dbo].[SpaceshipCards] ([Id], [CrewCount], [Name], [CardType]) VALUES(N'9aba8921-29a6-4cff-9110-5de4966a36b5', 30, N'Just Spaceship', N'Spaceship')
                                    GO
                                    INSERT[dbo].[SpaceshipCards] ([Id], [CrewCount], [Name], [CardType]) VALUES(N'a7cb6d5c-2f0b-4cf8-974e-c0000a9a186c', 80, N'Huge Spaceship', N'Spaceship')
                                    GO
                                    INSERT[dbo].[SpaceshipCards] ([Id], [CrewCount], [Name], [CardType]) VALUES(N'1ddb3a27-18fd-4462-84e4-c108fae1422a', 1, N'Small Spaceship', N'Spaceship')
                                    GO
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
