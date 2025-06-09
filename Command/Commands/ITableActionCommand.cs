using Microsoft.AspNetCore.Mvc;

namespace Command.Commands
{
    public interface ITableActionCommand
    {
        IActionResult Execute();
    }
}