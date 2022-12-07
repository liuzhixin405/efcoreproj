﻿using Spider.DataLayer.Model.NewsLetter;
using System.Collections.Generic;

namespace Spider.DataBusiness
{
    public class LivesItemListCombinedDto
    {
        public LivesItemListCombinedDto(SortFilterPageOptions sortFilterPageData, IEnumerable<LivesItem> list)
        {
            SortFilterPageData = sortFilterPageData;
            List = list;
        }

        public SortFilterPageOptions SortFilterPageData { get; private set; }

        public IEnumerable<LivesItem> List { get; private set; }
    }
}
