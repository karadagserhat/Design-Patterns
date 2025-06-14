﻿using BaseProject.Models;
using MediatR;
using Observer.Events;

namespace Observer.EventHandlers
{
    public class CreateDiscountEventHandler : INotificationHandler<UserCreatedEvent>
    {
        private readonly AppIdentityDbContext _context;
        private readonly ILogger<CreateDiscountEventHandler> _logger;

        public CreateDiscountEventHandler(AppIdentityDbContext context, ILogger<CreateDiscountEventHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
        {
            await _context.Discounts.AddAsync(new Models.Discount { Rate = 10, UserId = notification.AppUser.Id });
            await _context.SaveChangesAsync();
            _logger.LogInformation("Discount created");
        }
    }
}