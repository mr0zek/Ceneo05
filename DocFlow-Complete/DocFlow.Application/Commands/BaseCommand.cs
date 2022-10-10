using System;

namespace DocFlow.Application.Commands
{
  [Serializable]
  public abstract class BaseCommand
  {
    public Guid TennantId { get; private set; }
    public bool Asynch { get; private set; }
    public bool Unique { get; private set; }

    public BaseCommand(Guid tennantId, bool asynch, bool unique)
    {
      TennantId = tennantId;
      Asynch = asynch;
      Unique = unique;
    }

    public BaseCommand(Guid tennantId) : this(tennantId, false, false)
    {
    }
  }
}