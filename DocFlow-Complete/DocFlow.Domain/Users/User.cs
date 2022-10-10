using DocFlow.Domain.Users.Roles;
using System;
using System.Collections.Generic;

namespace DocFlow.Domain.Users
{
  public class User
  {
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    private IDictionary<Type, IUserRole> _roles;

    public void AddRole(IUserRole userRole)
    {
      _roles.Add(userRole.GetType(), userRole);
    }

    public User(Guid id)
    {
      Id = id;

      //TODO wstrzyknąć w repo pobierając konf z podsystemu bezpieczeństwa
      _roles = new Dictionary<Type, IUserRole>();
    }

    public bool HasRole<T>()
    {
      return _roles.ContainsKey(typeof(T));
    }

    public T GetRole<T>() where T : class,IUserRole
    {
      if (!HasRole<T>())
        throw new UnauthorizedOperationException(Id, "does not have role: " + typeof(T).Name);
      return _roles[typeof(T)] as T;
    }
  }
}