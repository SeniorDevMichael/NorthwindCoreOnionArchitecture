# NorthwindCoreOnionArchitecture
*************************************************************
# 1.NorthwindCore.Domain(Project)
  # 1.1.Entites(Models)
  # 1.2.Database_Script(SQL)

*************************************************************
# 2.NorthwindCore.Application(Project)

  # 2.1.DTO
  # 2.2.Helpers
  # 2.3.Interfaces => Repositories => Base
  # 2.4.Features => Commands/Queries (CQRS+Mediator Pattern)
  # 2.5.Mapping

*************************************************************
# 3.NorthwindCore.Infrastructure(Project)

  # 3.1.Context
  # 3.2.Entity Configurations
  # 3.3.Repositories(Implementions)
  # 3.4.UOW(UNit Of Work)
  # 3.5. Service Registration

*************************************************************
# 4.NorthwindCore.WebApi(Project)
  # 4.1.Controllers
  # 4.2.Middlewares
  # 4.3.Swagger support

*************************************************************
# Patterns => Repository, CQRS+Mediator Pattern, UnitOfWork
# Authorization => Basic
# Swagger => Supports
