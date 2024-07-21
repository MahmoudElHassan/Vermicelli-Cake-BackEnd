﻿using System.Linq.Expressions;

namespace E_Commerce_DAL;

public interface ISpecification<T>
{
    Expression<Func<T, bool>> Criteria { get; }
    List<Expression<Func<T, object>>> Includes { get; }
    Expression<Func<T, object>> OrderBy { get; }
    Expression<Func<T, object>> OrderByDescending { get; }

    //int Take { get; }
    //int Skip { get; }
    //bool IsPagingEnabled { get; }
}
