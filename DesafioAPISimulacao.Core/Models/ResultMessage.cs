namespace DesafioAPISimulacao.Core.Models
{
  public enum ResultMessageType
  {
    ERROR,
    WARNING,
    INFO,
    SUCCESS
  }

  public class ResultMessage
  {
    public ResultMessageType Type { get; set; }
    public string Message { get; set; }

    public ResultMessage(ResultMessageType Type, string Message)
    {
      this.Type = Type;
      this.Message = Message;
    }
  }
}
