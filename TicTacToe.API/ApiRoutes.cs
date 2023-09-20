namespace TicTacToe.API
{
    public class ApiRoutes
    {
        protected ApiRoutes()
        {
        }
        public static class Games
        {
            public const string Get = $"{Base}/{{id}}";

            public const string Put = $"{Base}/save";
            public const string Post = $"{Base}";
            public const string CreateNewGame = $"{Base}/new";

            public const string Base = "/api/games";
        }
    }
}
