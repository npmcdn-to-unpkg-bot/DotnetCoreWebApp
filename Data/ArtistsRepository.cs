using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using Common.Data.EntityFramework;
using LinqKit;
using TestProject.Models;

namespace WebApplication.Data
{
    public class ArtistsRepository : EfDataRepositoryBase<Artist, ChinookSqlServer2008DbContext>, IArtistsRepository
    {

        private ChinookSqlServer2008DbContext _context;
        public ArtistsRepository()
        { }

        public ArtistsRepository(ChinookSqlServer2008DbContext context)
        {
            _context = context;
        }

        override protected IEnumerable<Artist> FindAllEntitiesByCriteria(
            ChinookSqlServer2008DbContext entityContext,
            int? pageNumber,
            int? pageSize,
            out int totalRecords,
            string sortColumn,
            string sortDirection,
            params string[] keywords)
        {

            int pageIndex = pageNumber ?? 1;
            int sizeOfPage = pageSize ?? 10;
            if (pageIndex < 1) pageIndex = 1;
            if (sizeOfPage < 1) sizeOfPage = 5;
            int skipValue = (sizeOfPage * (pageIndex - 1));

            int offset = (int)((pageIndex - 1) * sizeOfPage + 1);
            int offsetUpperBound = offset + (sizeOfPage - 1);

            Expression<System.Func<Artist, bool>> filterExpression = a => true;
            var predicate = PredicateBuilder.New(filterExpression);
            bool isFilteredQuery = keywords.Any();

            if (isFilteredQuery)
            {
                predicate = filterExpression = a => false;
                foreach (var keyword in keywords)
                {
                    var temp = keyword;
                    if (temp == null) continue;
                    predicate = predicate.Or(p => p.Name.ToLower().Contains(temp.ToLower()));
                }
            }

            totalRecords =
               _context.Artist.AsExpandable().Where(predicate).OrderBy(am => am.Name).Count();
            offsetUpperBound = (totalRecords > offsetUpperBound ? offsetUpperBound : totalRecords);

            int totalNumberOfPages = (int)Math.Ceiling((double)totalRecords / sizeOfPage);

            var artists =
                _context.Artist.AsExpandable()
                    .Where(predicate)
                    .OrderBy($"{sortColumn} {sortDirection}")
                    .Skip(skipValue)
                    .Take(sizeOfPage)
                    .ToList();
            return artists;

        }
    }
}