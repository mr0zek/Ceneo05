using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocFlow.Domain.Documents;

namespace DocFlow.Application.Services
{
  //Pytanie: Czy ta klas jest czascia domeny ?
  class DocumentQueryAssembler
  {
    public bool? Expired { get; set; }
    public bool? Published { get; set; }
    public bool? WillExpireInWeek { get; set; }
    public DocumentType? Type { get; set; }
    public Guid? AuthorId { get; set; }

    public SqlCommand Build()
    {
      SqlCommand result = new SqlCommand();
      StringBuilder sb = new StringBuilder();
      sb.Append("Select Number,Title,Type,itd.. from Document where 1=1 ");
      if (Expired.HasValue)
      {
        sb.Append("and ExpiryDate < getDate() and Status <> 'Archived'");           
      }
      if (Published.HasValue)
      {
        sb.Append("and ExpiryDate > getDate() and Status = 'Published'");
      }
      if (WillExpireInWeek.HasValue)
      {
        sb.Append("and ExpiryDate < dateadd(day,7,getDate())");
      }

      if (AuthorId.HasValue)
      {
        sb.Append("and author = '"+AuthorId+"'");
      }

      result.CommandType = CommandType.Text;
      result.CommandText = sb.ToString();
      return result;
    }
  }
}
