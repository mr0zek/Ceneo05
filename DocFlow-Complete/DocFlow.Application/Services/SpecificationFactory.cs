using System;
using DocFlow.Domain.Documents;
using DocFlow.Domain.Documents.Specifications;
using DocFlow.Domain.Shared.Specification;
using DocFlow.Domain.Users;

namespace DocFlow.Application.Services
{
  public class SpecificationFactory
  {
    public static ISpecification<Document> Create()
    {
      return new TypeSpec(DocumentType.PROCEDURE)
        .And(new ExpiringSpec(10))
        .And(new AuthorsSpec(new User(Guid.NewGuid())));
    }
  }
}