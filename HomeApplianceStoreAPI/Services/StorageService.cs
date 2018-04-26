using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApplianceStoreAPI.Services
{
    public class StorageService<T>
    {
        private readonly IMemoryCache memoryCache;
        private readonly EventGridService eventGridService;

        public StorageService(IMemoryCache memoryCache, EventGridService eventGridService)
        {
            this.memoryCache = memoryCache;
            this.eventGridService = eventGridService;
        }

        public List<T> GetAll()
        {
            return this.memoryCache.GetOrCreate(typeof(T).GUID, x => new List<T>());
        }
        private void SaveList(List<T> list)
        {
            this.memoryCache.Set(typeof(T).GUID, list, DateTimeOffset.MaxValue);
        }

        public async Task SaveItem(T item)
        {
            var list = GetAll();
            list.Add(item);
            SaveList(list);

            // Notify our event grid
            await this.eventGridService.PublishEvent("ItemSaved", typeof(T).Name, item);
        }

    }
}
