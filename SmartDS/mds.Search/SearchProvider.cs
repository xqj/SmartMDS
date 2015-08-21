using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mds.Search
{
   public abstract class  SearchProvider
    {
       protected Dictionary<string,int> _indexData=new Dictionary<string,int>();
       protected List<string> _keys = new List<string>();
      
       public List<int> SearchKey(string key) {
           var searchResult=_keys.FindAll(delegate(string keyWord) { return keyWord.Contains(key); });
           var resultLIst = new List<int>();
           if (searchResult != null) {
               searchResult.ForEach(a => {
                   if (_indexData.ContainsKey(a))
                   {
                       resultLIst.Add(_indexData[a]);
                   }
               });
           }
           return resultLIst;
       }
       public void ClearIndex()
       {
           _indexData.Clear();
           _keys.Clear();
       }
    }
}
