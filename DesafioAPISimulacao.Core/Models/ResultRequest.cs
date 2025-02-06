using System.Collections.Generic;

namespace DesafioAPISimulacao.Core.Models
{
  public class ResultRequest
  {
    public ResultRequest(bool Success, object Result)
    {
      this.Success = Success;
      this.Messages = null;
      this.Result = Result;
    }

    public ResultRequest(bool Success, string Message, object Result)
    {
      this.Success = Success;
      this.Messages = new List<ResultMessage>() { new ResultMessage(Success ? ResultMessageType.SUCCESS : ResultMessageType.ERROR, Message) };
      this.Result = Result;
    }

    public ResultRequest(bool Success, IList<ResultMessage> Messages, object Result)
    {
      this.Success = Success;
      this.Messages = Messages;
      this.Result = Result;
    }

    public ResultRequest(bool Success, string Message, object Result, string RedirectRoute)
    {
      this.Success = Success;
      this.Messages = new List<ResultMessage>() { new ResultMessage(Success ? ResultMessageType.SUCCESS : ResultMessageType.ERROR, Message) };
      this.Result = Result;
      this.RedirectRoute = RedirectRoute;
    }

    public bool Success { get; }
    public IList<ResultMessage> Messages { get; }
    public object Result { get; set; }
    public string RedirectRoute { get; set; }
  }
}
