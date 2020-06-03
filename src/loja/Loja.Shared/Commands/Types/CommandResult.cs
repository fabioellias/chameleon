namespace Loja.Shared.Commands.Types
{
    public class CommandResult : ICommandResult
    {

        public CommandResult() { }
        public CommandResult(bool success, string message, object content)
        {
            Success = success;
            Message = message;
            Content = content;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Content {get; set;}
        
    }
}