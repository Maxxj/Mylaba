using InnovativeProduct.DomainObjects;
using InnovativeProduct.ApplicationServices.Ports.Cache;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace InnovativeProduct.InfrastructureServices.Cache
{
    public class DomainObjectsMemoryCache<T> : IDomainObjectsCache<T> where T : DomainObject
    {
        private readonly Dictionary<long, (T, DateTime)> _objectsCache = new Dictionary<long, (T, DateTime)>();
        private DateTime? _allObjectsExpirationTime;

        public T GetObject(long id)
        {
            if (_objectsCache.TryGetValue(id, out var tuple))
            {
                var (domainObject, expirationTime) = tuple;
                if (expirationTime >= DateTime.Now)
                {
                    return domainObject;
                }
            }
            return null;
        }

        public IEnumerable<T> GetObjects()
            => _allObjectsExpirationTime != null && _allObjectsExpirationTime.Value >= DateTime.Now ?
               _objectsCache.Values.Select(item => item.Item1) :
               null;


        public void UpdateObjects(IEnumerable<T> domainObjects, DateTime expirationTime, bool allObjects)
        {
            foreach (var domainObject in domainObjects)
            {
                UpdateObject(domainObject, expirationTime);
            }
            if (allObjects)
            {
                _allObjectsExpirationTime = expirationTime;
            }
        }

        public void UpdateObject(T domainObject, DateTime expirationTime)
        {
            if (domainObject != null)
            {
                _objectsCache[domainObject.Id] = (domainObject, expirationTime);
            }
        }

        public void ClearCache()
        {
            _objectsCache.Clear();
        }
    }
}
