using BaseProject.Models;
using MediatR;

namespace Observer.Events
{
    public class UserCreatedEvent : INotification
    {
        public AppUser AppUser { get; set; }
    }
}