using DocFlow.Domain.Users.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DocFlow.Domain.Users
{
  internal class Class2
  {
    public void t()
    {
      User u;

      if (Thread.CurrentPrincipal.IsInRole("Aditor"))
      {
      }

      if (u.HasRole<Auditor>())
      {
        u.GetRole<Auditor>().Audit();
      }

      if (u.HasRole<Corrector>())
      {
        u.GetRole<Corrector>().CorrectInvoice();
      }
    }
  }
}