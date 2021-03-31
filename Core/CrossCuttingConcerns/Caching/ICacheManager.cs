using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        // key e karşılık gelen datayı getir
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object value, int duration);

        //cache te var mı diye bir kontrol metodu
        bool IsAdd(string key);

        // cache ten sil
        void Remove(string key);

        //cache ten sil ama categoryId içeren patterneleri sil demek için
        void RemoveByPattern(string pattern);

    }
}
