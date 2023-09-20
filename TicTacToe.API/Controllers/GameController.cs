using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using TicTacToe.Application.Commands;
using TicTacToe.Application.Dtos;
using TicTacToe.Application.Queries;

namespace TicTacToe.API.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class GameController : ControllerBase
    {
        private IMediator? _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();

        /// <summary>
        /// Get game details by id
        /// </summary>
        /// <param name="id">game id</param>
        /// <returns>game id</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet(ApiRoutes.Games.Get)]
        public async Task<ActionResult<GetGameDetailsResponseDto>> Get([FromRoute] Guid id)
        {
            var query = new GetGameDetailsQuery(id);
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        /// <summary>
        /// Add new game
        /// </summary>
        /// <param name="playerXName">playerX name</param>
        /// <param name="playerOName">playerO name</param>
        /// <returns>game id</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost(ApiRoutes.Games.Post)]
        public async Task<ActionResult<Guid>> Post(AddPlayersCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        /// <summary>
        /// Add new game with the same old players
        /// </summary>
        /// <param name="playerXId">playerX id</param>
        /// <param name="playerOId">playerO id</param>
        /// <returns>game id</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost(ApiRoutes.Games.CreateNewGame)]
        public async Task<ActionResult<Guid>> Create(AddNewGameCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        /// <summary>
        /// save game
        /// </summary>
        /// <param name="command">save game command</param>
        /// <returns>game id</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut(ApiRoutes.Games.Put)]
        public async Task<ActionResult<Guid>> Put(SaveGameCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}