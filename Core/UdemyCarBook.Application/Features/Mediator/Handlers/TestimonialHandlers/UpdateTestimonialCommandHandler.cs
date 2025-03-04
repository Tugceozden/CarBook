﻿
using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _repository;

        public UpdateTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {

            var values = await _repository.GetByIdAsync(request.TestimonialId);
            values.Name = request.Name;
            values.Comment = request.Comment;
            values.Title = request.Title;   
            values.ImageUrl = request.ImageUrl; 
            await _repository.UpdateAsync(values);
        }
    }
}
