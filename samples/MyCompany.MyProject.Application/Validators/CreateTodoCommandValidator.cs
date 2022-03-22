﻿using Dddify.Localization;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MyCompany.MyProject.Application.Commands;
using MyCompany.MyProject.Domain.ValueObjects;
using MyCompany.MyProject.Infrastructure;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyCompany.MyProject.Application.Validators;

public class CreateTodoCommandValidator : AbstractValidator<CreateTodoCommand>
{
    private readonly ApplicationDbContext _context;
    private readonly ISharedStringLocalizer _localizer;

    public CreateTodoCommandValidator(ApplicationDbContext context, ISharedStringLocalizer localizer)
    {
        _context = context;
        _localizer = localizer;

        RuleFor(v => v.Title)
            .NotEmpty().WithMessage(_localizer["The title is required."])
            .MaximumLength(200).WithMessage(_localizer["The title must not exceed 200 characters."])
            .MustAsync(BeUniqueTitle).WithMessage(c => _localizer["The specified title already exists.", c.Title]);

        RuleFor(v => v.Colour)
           .NotEmpty().WithMessage(_localizer["The colour is required."])
           .MustAsync(BeSupportedColour).WithMessage(_localizer["The specified colour code is unsupported."]);
    }

    public async Task<bool> BeUniqueTitle(string title, CancellationToken cancellationToken)
    {
        return await _context.Todos.AllAsync(c => c.Title != title, cancellationToken);
    }

    public async Task<bool> BeSupportedColour(Colour colour, CancellationToken cancellationToken)
    {
        return await Task.FromResult(Colour.SupportedColours.Any(c => c.Code == colour.Code));
    }
}
