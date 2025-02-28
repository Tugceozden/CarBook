

using MediatR;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Commands.PricingCommands
{
	public class CreatePricingCommand:IRequest
	{
		public string Name { get; set; }
	}
}
