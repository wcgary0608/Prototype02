using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.MainScene.Item
{
    internal class Item
    {
        private string _name = "New Item";
        private int _id = -1;
        private Sprite _icon = null;
        private string _description ="No Description";
        private bool _canStack = false;
        private Dictionary<string, int> _stats = new Dictionary<string, int>();

        /// <summary>
        ///  item initializer
        /// </summary>
        /// <param name="Id">id</param>
        /// <param name="Name">name</param>
        /// <param name="Description">the item description, no limit at this moment</param>
        /// <param name="Icon">sprite to use</param>
        /// <param name="Stats">stats dictionary</param>
        public Item(int Id, string Name, string Description, Sprite Icon, Dictionary<string, int> Stats)
        {
            this._id = Id;
            this._name = Name;
            this._description = Description;
            this._icon = Icon;
            this._stats = Stats;
        }

        /// <summary>
        /// create a copy of a item
        /// </summary>
        /// <param name="itemToCopy">the item to copy</param>
        public Item(Item itemToCopy)
        {
            this._id = itemToCopy._id;
            this._name = itemToCopy._name;
            this._description = itemToCopy._description;
            this._icon = itemToCopy._icon;
            this._stats = itemToCopy._stats;
        }

        public int Id { get; set; }

        public Sprite Icon { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public bool CanStack { get; set; }

        /// <summary>
        /// set the a stat of the item
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns>true if added / otherwise false</returns>
        public bool SetStats(string key, int value)
        {
            if (_stats == null)
            {
                return false;
            }
            if (_stats.ContainsKey(key))
            {
                _stats[key] = value;
            }
            else
            {
                _stats.Add(key, value);
            }
            return true;
        }

        /// <summary>
        /// get the stats value of a given key
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>the value of that key or int.MinValue</returns>
        public int GetStats(string key)
        {
            if (_stats == null)
            {
                return int.MinValue;
            }
            if (_stats.ContainsKey(key))
            {
                return _stats[key];
            }
            return int.MinValue;
        }
    }
}