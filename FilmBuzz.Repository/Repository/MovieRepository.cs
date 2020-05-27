using FilmBuzz.Common.Interface;
using FilmBuzz.Common.Model;
using FilmBuzz.Repository.DbContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FilmBuzz.Repository.Repository
{
    class MovieRepository : IRepository<TBL_MOVIES>
    {
        public bool Create(TBL_MOVIES entity)
        {
            bool status = false;
            try
            {
                for (int i = 0; i < entity.ActorsId.Length; i++)
                {
                    using (var _dbContext = new FilmBuzzDbContext())
                    {

                        _dbContext.TBL_MOVIES.Add(new TBL_MOVIES()
                        {
                            Name = entity.Name,
                            ActorId = entity.ActorsId[i],
                            Plot = entity.Plot,
                            ProducerId = entity.ProducerId,
                            YearofRelease = entity.YearofRelease
                        });
                        status= _dbContext.SaveChanges() == 1 ? true : false;
                        

                    }
                }
                return status;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(TBL_MOVIES entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TBL_MOVIES> GetAll()
        {
            using (var _dbContext = new FilmBuzzDbContext())
            {
                return _dbContext.TBL_MOVIES.ToListAsync().Result;
            }
        }

        public IEnumerable<TBL_MOVIES> GetAllWith(object param)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TBL_MOVIES> GetAllWith(Expression<Func<TBL_MOVIES, bool>> Expression)
        {
            using (var _dbContext = new FilmBuzzDbContext())
            {
                return _dbContext.TBL_MOVIES.Where(Expression).ToListAsync().Result;
            }
        }

        public bool Update(TBL_MOVIES entity)
        {
            throw new NotImplementedException();
        }
    }
}
