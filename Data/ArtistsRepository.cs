using System;
using System.Collections.Generic;
using System.Linq;
using Common.Data.EntityFramework;
using LinqKit;
using TestProject.Models;

namespace WebApplication.Data
{
    public class ArtistsRepository : EfDataRepositoryBase<Artist, ChinookSqlServer2008DbContext>, IArtistsRepository
    {
        public ArtistsRepository()
        { }

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

            using (var ctx = new ChinookSqlServer2008DbContext())
            {
                var predicate = PredicateBuilder.True<Artist>();
                bool isFilteredQuery = keywords.Any();

                if (isFilteredQuery)
                {
                    predicate = PredicateBuilder.False<Artist>();
                    foreach (var keyword in keywords)
                    {
                        var temp = keyword;
                        if (temp == null) continue;
                        predicate = predicate.Or(p => p.Name.ToLower().Contains(temp.ToLower()));
                    }
                }

                totalRecords =
                   ctx.Artist.AsExpandable().Where(predicate).OrderBy(am => am.Name).Count();
                offsetUpperBound = (totalRecords > offsetUpperBound ? offsetUpperBound : totalRecords);

                int totalNumberOfPages = (int)Math.Ceiling((double)totalRecords / sizeOfPage);
                var artists =
                    ctx.Artist.AsExpandable()
                        .Where(predicate)
                        .OrderBy(am => am.Name)
                        .Skip(skipValue)
                        .Take(sizeOfPage)
                        .ToList();
                return artists;

            }
        }


    }
}