﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitanBot.Models
{
    public delegate void CachedDictionaryUpdateEventHandler<TKey, TValue>(object sender, CachedDictionaryUpdateEventArgs<TKey, TValue> args);

    public static class CachedDictionary
    {
        public static CachedDictionary<TKey, TValue> FromSource<TKey, TValue>(Func<TKey, ValueTask<TValue>> source, TimeSpan validFor, uint capacity = 0)
            => CachedDictionary<TKey, TValue>.FromSource(source, validFor, capacity);
        public static CachedDictionary<TKey, TValue> FromSource<TKey, TValue>(Func<TKey, Task<TValue>> source, TimeSpan validFor, uint capacity = 0)
            => CachedDictionary<TKey, TValue>.FromSource(source, validFor, capacity);
        public static CachedDictionary<TKey, TValue> FromSource<TKey, TValue>(Func<TKey, TValue> source, TimeSpan validFor, uint capacity = 0)
            => CachedDictionary<TKey, TValue>.FromSource(source, validFor, capacity);
        public static CachedDictionary<TKey, TValue> FromSource<TKey, TValue>(Func<TKey, ValueTask<TValue>> source, int validForMS, uint capacity = 0)
            => CachedDictionary<TKey, TValue>.FromSource(source, validForMS, capacity);
        public static CachedDictionary<TKey, TValue> FromSource<TKey, TValue>(Func<TKey, Task<TValue>> source, int validForMS, uint capacity = 0)
            => CachedDictionary<TKey, TValue>.FromSource(source, validForMS, capacity);
        public static CachedDictionary<TKey, TValue> FromSource<TKey, TValue>(Func<TKey, TValue> source, int validForMS, uint capacity = 0)
            => CachedDictionary<TKey, TValue>.FromSource(source, validForMS, capacity);
    }

    public class CachedDictionary<TKey, TValue>
    {
        private ConcurrentDictionary<TKey, (TValue Value, DateTime LastUpdated)> Cache { get; }
        private Func<TKey, ValueTask<TValue>> Source { get; }
        private TKey Oldest => Cache.OrderBy(k => k.Value.LastUpdated).FirstOrDefault().Key;

        public TimeSpan ValidPeriod { get; }
        public uint Capacity { get; }
        public event CachedDictionaryUpdateEventHandler<TKey, TValue> OnUpdate;


        public static CachedDictionary<TKey, TValue> FromSource(Func<TKey, ValueTask<TValue>> source, TimeSpan validFor, uint capacity = 0)
            => new CachedDictionary<TKey, TValue>(source, validFor, capacity);
        public static CachedDictionary<TKey, TValue> FromSource(Func<TKey, Task<TValue>> source, TimeSpan validFor, uint capacity = 0)
            => FromSource(k => new ValueTask<TValue>(source(k)), validFor, capacity);
        public static CachedDictionary<TKey, TValue> FromSource(Func<TKey, TValue> source, TimeSpan validFor, uint capacity = 0)
            => FromSource(k => new ValueTask<TValue>(source(k)), validFor, capacity);
        public static CachedDictionary<TKey, TValue> FromSource(Func<TKey, ValueTask<TValue>> source, int validForMS, uint capacity = 0)
            => FromSource(source, new TimeSpan(0,0,0,0,validForMS), capacity);
        public static CachedDictionary<TKey, TValue> FromSource(Func<TKey, Task<TValue>> source, int validForMS, uint capacity = 0)
            => FromSource(k => new ValueTask<TValue>(source(k)), new TimeSpan(0, 0, 0, 0, validForMS), capacity);
        public static CachedDictionary<TKey, TValue> FromSource(Func<TKey, TValue> source, int validForMS, uint capacity = 0)
            => FromSource(k => new ValueTask<TValue>(source(k)), new TimeSpan(0, 0, 0, 0, validForMS), capacity);

        private CachedDictionary(Func<TKey, ValueTask<TValue>> source, TimeSpan validFor, uint capacity)
        {
            Cache = new ConcurrentDictionary<TKey, (TValue Value, DateTime LastUpdated)>();
            Source = source;
            ValidPeriod = validFor;
            Capacity = capacity;
        }

        public void Invalidate()
            => Cache.Clear();
        public void Invalidate(TKey key)
            => Cache.TryRemove(key, out _);

        private bool NeedsUpdating(TKey key)
        {
            if (!Cache.TryGetValue(key, out var tup))
                return true;
            if (ValidPeriod == TimeSpan.MaxValue)
                return false;
            return DateTime.Now - tup.LastUpdated > ValidPeriod;
        }

        private async ValueTask<TValue> Update(TKey key)
        {
            var value = (Value: await Source(key), LastUpdate: DateTime.Now);
            Cache.TryGetValue(key, out var old);
            if (Capacity != 0 && Cache.Count == Capacity)
                Cache.TryRemove(Oldest, out _);
            Cache.AddOrUpdate(key, value , (k, x) => value);
            OnUpdate?.Invoke(this, new CachedDictionaryUpdateEventArgs<TKey, TValue>(key, old.Value, value.Value, value.LastUpdate, DateTime.Now));
            return value.Value;
        }

        public TValue Get(TKey key)
        {
            if (NeedsUpdating(key))
                return Update(key).Result;
            return Cache.GetOrAdd(key, (Source(key).Result, DateTime.Now)).Value;
        }

        public TValue this[TKey key]
            => Get(key);
    }

    public class CachedDictionaryUpdateEventArgs<TKey, TValue> : CacheUpdateEventArgs<TValue>
    {
        public TKey Key { get; }

        internal CachedDictionaryUpdateEventArgs(TKey key, TValue old, TValue @new, DateTime start, DateTime finish) : base (old, @new, start, finish)
        {
            Key = key;
        }
    }
}