using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.Dto;
using TodoList.Domain.Entities;
using TodoList.Infrastructure.Repository;

namespace TodoList.Application.Commands
{
    public class CreateEntryHandler : IRequestHandler<CreateEntryCommand, TodoEntry>
    {
        /// <summary>
        /// The todo repository
        /// </summary>
        private readonly ITodoRepository _repository;

        /// <summary>
        /// The automapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="todoRepository"></param>
        /// <param name="mapper"></param>
        public CreateEntryHandler( ITodoRepository todoRepository, IMapper mapper)
        {
            _repository = todoRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles create entry request
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<TodoEntry> Handle( CreateEntryCommand command, CancellationToken cancellationToken )
        {
            var entries = await _repository.CreateAsync( new TodoEntry( command.Description ) ).ConfigureAwait( false );

            // Need some tweeking to get working
            //var viewModel = _mapper.Map<TodoEntryDto>( entries );
            return entries;
        }
    }
}
