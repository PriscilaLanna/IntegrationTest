using EasyCaching.Core;
using Shopee.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopee.Services
{
    public class ProviderCache : IProviderCache
    {
        private readonly IEasyCachingProvider _provider;
        private int hours = 10;

        public ProviderCache(IEasyCachingProvider provider)
        {
            _provider = provider;
        }

        public void SetCache(KeyValuePair<string, object> value)
        {
            var businessId = BusinessService.GetBusiness();

            var cacheName = $"{value.Key}_{businessId}";
            CacheValue<object> cache = _provider.Get<object>(cacheName);

            if (cache.HasValue)
                _provider.Remove(cacheName);

            _provider.Set(cacheName, value.Value, TimeSpan.FromHours(hours));
        }

        public void SetListCache(KeyValuePair<string, List<int>> value)
        {
            var businessId = BusinessService.GetBusiness();

            var cacheName = $"{value.Key}_{businessId}";
            CacheValue<List<int>> cache = _provider.Get<List<int>>(cacheName);

            if (!cache.HasValue)
                _provider.Set(cacheName, value.Value, TimeSpan.FromHours(hours));
        }

        public object GetCache(string name)
        {
            var businessId = BusinessService.GetBusiness();

            var cacheName = $"{name}_{businessId}";
            var cache = _provider.Get<object>(cacheName);

            return cache.HasValue ? cache.Value : null;
        }
        public List<int> GetListCache(string name)
        {
            var businessId = BusinessService.GetBusiness();

            var cacheName = $"{name}_{businessId}";
            var cache = _provider.Get<List<int>>(cacheName);

            return cache.HasValue ? cache.Value : null;
        }

        public void SetCacheCommonParameters(CommonParameters parameters)
        {
            parameters.GetType().GetProperties().ToList().ForEach(x =>
            {
                var value = x.GetValue(parameters);
                var type = x.PropertyType;

                if (value != null && type == typeof(string))
                    SetCache(new KeyValuePair<string, object>(x.Name, value));

                if (type == typeof(Int32) || type == typeof(Int64))
                {
                    var valueInt = type == typeof(Int32) ? (Int32)value : (Int64)value;

                    if (valueInt > 0)
                        SetCache(new KeyValuePair<string, object>(x.Name, value));
                }
            });
        }

        public CommonParameters GetCacheCommonParameters()
        {
            var parameters = new CommonParameters();

            parameters.GetType().GetProperties().ToList().ForEach(x =>
            {
                var value = GetCache(x.Name)?.ToString();
                var type = x.PropertyType;

                if (value != null)
                {
                    if (type == typeof(string))
                        x.SetValue(parameters, value);

                    if (type == typeof(Int32))
                    {
                        var valueInt = Int32.Parse(value);

                        if (valueInt > 0)
                            x.SetValue(parameters, valueInt);
                    }

                    if (type == typeof(Int64))
                    {
                        var valueInt = Int64.Parse(value);

                        if (valueInt > 0)
                            x.SetValue(parameters, valueInt);
                    }
                }
            });

            return parameters;
        }

        public void Reset()
        {
            var parameters = new CommonParameters();

            parameters.GetType().GetProperties().ToList().ForEach(x =>
            {
                _provider.RemoveByPrefixAsync(x.Name.Substring(0, 4).ToLower());

            });
        }
    }

    public interface IProviderCache
    {
        void SetCache(KeyValuePair<string, object> value);
        void SetListCache(KeyValuePair<string, List<int>> value);
        object GetCache(string value);
        List<int> GetListCache(string value);

        //void Reset();
        //void SetCacheCommonParameters(CommonParameters parameters);
        //CommonParameters GetCacheCommonParameters();
    }
}