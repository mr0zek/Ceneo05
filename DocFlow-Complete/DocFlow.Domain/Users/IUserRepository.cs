using System;

namespace DocFlow.Domain.Users
{
  public interface IUserRepository
  {
    User Get(Guid creatorId);
  }
}