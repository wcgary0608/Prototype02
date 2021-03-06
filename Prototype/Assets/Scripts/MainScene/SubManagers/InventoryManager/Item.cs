﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.MainScene.SubManagers.InventoryManager
{
    public class Item
    {
        private string _name = "New Item";
        private int _id = -1;
        private Image _icon = null;
        private string _description ="No Description";
        private bool _canStack = false;
        private GameObject _itemObject = null;
        private Dictionary<string, int> _stats = new Dictionary<string, int>();

        /// <summary>
        ///  item initializer
        /// </summary>
        /// <param name="Id">id</param>
        /// <param name="Name">name</param>
        /// <param name="Description">the item description, no limit at this moment</param>
        /// <param name="Icon">sprite to use</param>
        /// <param name="Stats">stats dictionary</param>
        public Item(int Id, string Name, string Description, Image Icon, bool CanStack, Dictionary<string, int> Stats)
        {
            this._id = Id;
            this._name = Name;
            this._description = Description;
            this._icon = Icon;
            this._canStack = CanStack;
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

        public int Id {
            get { return _id; }
            set { _id = value; }
        }

        public Image Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public bool CanStack
        {
            get { return _canStack; }
            set { _canStack = value; }
        }

        public GameObject ItemObject
        {
            get { return _itemObject; }
            set { _itemObject = value; }
        }




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