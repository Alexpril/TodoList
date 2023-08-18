using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.Dto;
using TodoList.Domain.Entities;
using TodoList.Infrastructure.Repository;

namespace TodoList.Application.Queries
{
    public class GetAllEntriesHandler : IRequestHandler<GetAllEntriesQuery, IEnumerable<TodoEntry>>
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
        /// The Default constructor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public GetAllEntriesHandler(ITodoRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        /// <summary>
        /// Handles the get all request
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<IEnumerable<TodoEntry>> Handle(GetAllEntriesQuery request, CancellationToken cancellationToken)
        {
            var entries = await _repository.ReadAllAsync();

            // Need some tweeking to get working
            //var viewModel = _mapper.Map<IEnumerable<TodoEntry>>(entries);
            return entries;
        }
    }
}
