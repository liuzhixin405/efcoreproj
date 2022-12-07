﻿using Microsoft.AspNetCore.Authentication;
using System;
using System.Linq;
using System.Transactions;

namespace Spider.Utility.QueryObjects
{
    public static class GenericPaging
    {

        public static IQueryable<T> Page<T>(this IQueryable<T> query,int pageNumZeroStart,int pageSize)
        {
            if (pageSize == 0)
                throw new ArgumentOutOfRangeException
                    (nameof(pageSize), "pageSize cannot be zero.");
            if (pageNumZeroStart != 0)
                query = query
                    .Skip(pageNumZeroStart * pageSize);
            return query.Take(pageSize);
        }
    }
}
