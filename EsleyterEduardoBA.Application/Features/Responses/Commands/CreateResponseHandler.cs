using EsleyterEduardoBA.Domain.Entities;
using EsleyterEduardoBA.Domain.Ports.Repository;
using MediatR;

namespace EsleyterEduardoBA.Application.Features.Responses.Commands;

public class CreateResponseHandler : IRequestHandler<CreateResponseCommand, CreateResponseResult>
{
    private readonly IResponseRepository _responseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateResponseHandler(IResponseRepository responseRepository, IUnitOfWork unitOfWork)
    {
        _responseRepository = responseRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateResponseResult> Handle(CreateResponseCommand request, CancellationToken cancellationToken)
    {
        var response = new Response
        {
            Content = request.Content,
            TicketId = request.TicketId,
            UserId = request.UserId,
            CreatedAt = DateTime.UtcNow
        };

        await _responseRepository.AddAsync(response);
        await _unitOfWork.SaveChangesAsync();

        return new CreateResponseResult(true, "Respuesta creada exitosamente.", response.ResponseId);
    }
}