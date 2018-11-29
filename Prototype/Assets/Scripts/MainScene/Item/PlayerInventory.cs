using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.MainScene.Item
{
    internal class PlayerInventory : MonoBehaviour
    {
        private Dictionary<int, Item> _items = new Dictionary<int, Item>();
        private Dictionary<int, int> _itemStack = new Dictionary<int, int>();

        public PlayerInventory(Dictionary<int, Item> items, Dictionary<int, int> itemStack)
        {
            this._items = items;
            this._itemStack = itemStack;
        }

        /// <summary>
        /// Initialize the database. put SERIALIZATION here
        /// Currently, we manually put some test items in it
        /// </summary>
        public void initialize()
        {
        }

        /// <summary>
        /// Destroy during unload. put DESERIALIZATION here
        /// </summary>
        public void Destroy()
        {
        }

        #region items dictionary related API

        public bool Add(Item item, int? Count)
        {
            int Id = item.Id;
            if (Id == -1)
            {
                return false;
            }

            _items.Add(Id, item);
            if (item.CanStack)
            {
                if (Count == null)
                {
                    return false;
                }
                return AddItemToStack(Id, Count.GetValueOrDefault());
            }

            return true;
        }

        public bool Remove(Item item)
        {
            int Id = item.Id;
            if (_items.ContainsKey(Id))
            {
                _items.Remove(Id);
                if (item.CanStack)
                {
                    return RemoveItemFromStack(Id);
                }
                return true;
            }
            return false;
        }

        public bool HasItem(int Id)
        {
            if (_items.ContainsKey(Id))
            {
                return true;
            }
            return false;
        }

        public Item GetItem(int Id)
        {
            if (HasItem(Id))
            {
                return _items[Id];
            }
            return null;
        }

        public int ItemCount()
        {
            if (_items == null)
            {
                return -1;
            }
            return _items.Count;
        }

        #endregion items dictionary related API

        #region item stack related API

        /// <summary>
        /// return the count after stack action
        /// </summary>
        /// <param name="Id">item to stack</param>
        /// <param name="numChanged">the number change stack, can be negative</param>
        /// <returns>current stack or -1 if it is not applicable</returns>
        public int StackItem(int Id, int numChanged)
        {
            return 0;
        }

        public bool AddItemToStack(int Id, int Count)
        {
            if (!HasItem(Id) || Count <= 0)
            {
                return false;
            }

            _itemStack.Add(Id, Count);
            return true;
        }

        public bool RemoveItemFromStack(int Id)
        {
            if (_itemStack.ContainsKey(Id))
            {
                _itemStack.Remove(Id);
                return true;
            }
            return false;
        }

        public bool HasItemInStack(int Id)
        {
            if (_itemStack.ContainsKey(Id))
            {
                return true;
            }
            return false;
        }

        public Item GetItemCountInStack(int Id)
        {
            if (HasItemInStack(Id))
            {
                return GetItem(Id);
            }
            return null;
        }

        public int StackableItemCount()
        {
            if (_itemStack == null)
            {
                return -1;
            }
            return _itemStack.Count;
        }

        #endregion item stack related API

    }
}