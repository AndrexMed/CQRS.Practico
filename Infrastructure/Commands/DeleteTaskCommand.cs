﻿using MediatR;

namespace CQRS.Practico.Infrastructure.Commands
{
    public record DeleteTaskCommand(int Id) : IRequest<bool>;
}