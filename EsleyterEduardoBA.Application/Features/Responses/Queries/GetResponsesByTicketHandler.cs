using EsleyterEduardoBA.Domain.Entities;
using EsleyterEduardoBA.Domain.Ports.Repository;
using MediatR;

namespace EsleyterEduardoBA.Application.Features.Responses.Queries;

public class GetResponsesByTicketHandler : IRequestHandler<GetResponsesByTicketQuery, IEnumerable<Response>>
{
    private readonly IResponseRepository _responseRepository;

    public GetResponsesByTicketHandler(IResponseRepository responseRepository)
    {
        _responseRepository = responseRepository;
    }

    public async Task<IEnumerable<Response>> Handle(GetResponsesByTicketQuery request, CancellationToken cancellationToken)
    {
        return await _responseRepository.GetByTicketIdAsync(request.TicketId);
    }
}