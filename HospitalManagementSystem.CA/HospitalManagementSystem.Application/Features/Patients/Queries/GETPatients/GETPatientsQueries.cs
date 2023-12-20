using AutoMapper;
using AutoMapper.QueryableExtensions;
using HospitalManagementSystem.Application.Generics.Interfaces;
using HospitalManagementSystem.Domains.Entities;
using HospitalManagementSystem.Shared.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System_Applications.Features.Employee.Queries.Return_all_Employee
{
    public record GETPatientsQueries : IRequest<Response<IEnumerable<GETPatientsDTO>>>;

    public class ReturnEmployeeQueriesHandler : IRequestHandler<GETPatientsQueries, Response<IEnumerable<GETPatientsDTO>>>
    {
        private readonly IUnit_of_Work _unit_of_Work;

        private readonly IMapper _mapper;

        public ReturnEmployeeQueriesHandler(IUnit_of_Work unitOfWork, IMapper mapper)
        {
            _unit_of_Work = unitOfWork;

            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<GETPatientsDTO>>> Handle(GETPatientsQueries request, CancellationToken cancellationToken)
        {
            var patients = await _unit_of_Work.Repository<Patient>()
                .Entities.ProjectTo<GETPatientsDTO>(_mapper.ConfigurationProvider)
                    .AsNoTracking().ToListAsync(cancellationToken);

            return await Response<IEnumerable<GETPatientsDTO>>.SuccessAsync(
                patients, _unit_of_Work.Repository<Patient>()
                    .GetEntitiesAsync().Result.Message);
        }
    }
}
