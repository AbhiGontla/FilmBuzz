using FilmBuzz.Common.Interface;
using FilmBuzz.Common.Model;
using FilmBuzz.Handler.Query;
using FilmBuzz.Handler.QueryResult;
using FilmBuzz.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmBuzz.Handler.QueryHandler
{
    public class GetActorsByIdHandler : IQueryHandler<GetActorsById, GetActorsResult>
    {
        public GetActorsResult Execute(GetActorsById query)
        {
            var user = RepositoryFactory.GetInstance<TBL_ACTORS>().GetAllWith(filter => filter.ActorId == query.ActorId).FirstOrDefault();
            return new GetActorsResult()
            {
                Name=user.Name,
                Sex=user.Sex,
                Bio=user.Bio,
                DOB=user.DOB,
                ActorId=user.ActorId
            };
        }
    }
}
