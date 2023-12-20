using MediatR;

namespace HospitalManagementSystem.Controllers.Controllers
{
    public class DocumentController : ApplicationController
    {
        private readonly IMediator _mediator;

        public DocumentController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
