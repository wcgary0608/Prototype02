using System.Collections.Generic;

namespace Assets.Scripts.MainScene.Item
{
    internal class ItemDatabase
    {
        private Dictionary<int, Item> _database = new Dictionary<int, Item>();

        /// <summary>
        /// item database initializer
        /// </summary>
        /// <param name="itemDatabase"></param>
        public ItemDatabase(Dictionary<int, Item> itemDatabase)
        {
            this._database = itemDatabase;
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

        public bool Add(Item item)
        {
            int Id = item.Id;
            if (Id == -1)
            {
                return false;
            }

            _database.Add(Id, item);
            return true;
        }

        public bool Remove(Item item)
        {
            int Id = item.Id;
            if (_database.ContainsKey(Id))
            {
                _database.Remove(Id);
                return true;
            }
            return false;
        }

        public bool HasItem(int Id)
        {
            if (_database.ContainsKey(Id))
            {
                return true;
            }
            return false;
        }

        public Item GetItem(int Id)
        {
            if (HasItem(Id))
            {
                return _database[Id];
            }
            return null;
        }

        public int ItemCount()
        {
            if (_database == null)
            {
                return -1;
            }
            return _database.Count;
        }
    }
}