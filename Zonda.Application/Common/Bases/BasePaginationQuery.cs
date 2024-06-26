﻿using MediatR;

namespace Zonda.Application.Common.Bases
{
    public class BasePaginationQuery<T> : IRequest<PaginatedList<T>>
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string SortColumn { get; set; } = string.Empty;
        public string SortDirection { get; set; } = string.Empty;
    }
}
