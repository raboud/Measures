using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeasuresMVC.Models.Repositories
{
    public class ItemRepository<T> : IRepository<T> where T : class
    {

        private List<T> items 
        {
            get 
            { 
                if (this._items == null)
                {
                    this._items.ToList();
                }
                return this._items;
            }
        }
        private List<T> _items;
        private IQueryable<T> query;
        private string _sessionKey;

        public ItemRepository(IQueryable<T> items, string sessionKey)
        {
            this.query = items;
            this._sessionKey = sessionKey;
        }

        public ItemRepository(IEnumerable<T> items, string sessionKey)
        {
            this._items = items.ToList();
            this._sessionKey = sessionKey;
        }

        public IEnumerable<T> Get()
        {
            return items.AsQueryable();
        }

        public T Get(Predicate<T> condition)
        {
            return this.items.Find(condition);
        }

        public bool Update(T item, Predicate<T> condition)
        {
            if (condition == null || item == null)
            {
                throw new ArgumentNullException();
            }

            int index = items.FindIndex(condition);

            if (index == -1)
            {
                return false;
            }

            items.RemoveAt(index);
            items.Add(item);

            return true;
        }

        public T Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            items.Add(item);
            return item;
        }

        public int Delete(Predicate<T> condition)
        {
            if (condition == null)
            {
                throw new ArgumentNullException("condition");
            }

            return items.RemoveAll(condition);
        }

        public void Save()
        {
            HttpContext.Current.Session[this._sessionKey] = items;
        }

    }
}