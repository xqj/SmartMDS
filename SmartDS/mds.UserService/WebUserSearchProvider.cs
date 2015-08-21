using mds.BaseModel;
using mds.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mds.UserService
{
    internal class WebUserSearchProvider : SearchProvider
    {
        public void CreateIndex(List<Webuser> sourceData)
        {
            if (sourceData != null)
            {
                sourceData.ForEach(a => {
                    if (!string.IsNullOrEmpty(a.UserName))
                    _indexData.Add(a.UserName, a.UserId);
                    _indexData.Add(a.LoginName, a.UserId);
                    if (!string.IsNullOrEmpty(a.Nationality))
                    _indexData.Add(a.Nationality, a.UserId);
                    if (!string.IsNullOrEmpty(a.IDCard))
                    _indexData.Add(a.IDCard, a.UserId);
                    if (!string.IsNullOrEmpty(a.Mobile))
                    _indexData.Add(a.Mobile, a.UserId);
                });
            }
        }
    }
}
