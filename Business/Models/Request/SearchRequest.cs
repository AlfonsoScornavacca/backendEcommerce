﻿

namespace Business.Models.Request
{
    public class SearchRequest
    {
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
    }
}
