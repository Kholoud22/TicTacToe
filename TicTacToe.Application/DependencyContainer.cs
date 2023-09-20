using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TicTacToe.Infrastructure.Repositories.Contracts;
using TicTacToe.Infrastructure.Repositories;
using TicTacToe.Infrastructure;
using TicTacToe.Application.Services.Contracts;
using TicTacToe.Application.Services;

namespace TicTacToe.Application{    public static class DependencyContainer    {        public static void RegisterServices(this IServiceCollection services)        {            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IGameBoardService, GameBoardService>();
            services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(ApplicationLayer).Assembly));
            services.AddAutoMapper(typeof(ApplicationLayer).Assembly);
            services.AddDbContext<GameBoardsContext>(options =>
            {
                options.UseInMemoryDatabase("GameBoardsDb");
            });        }    }}