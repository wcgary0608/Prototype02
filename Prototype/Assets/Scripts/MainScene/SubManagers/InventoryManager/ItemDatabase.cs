using System.Collections.Generic;

namespace Assets.Scripts.MainScene.SubManagers.InventoryManager
{
    public class ItemDatabase
    {
        #region Singleton
        private static ItemDatabase _instance;

        public static ItemDatabase Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ItemDatabase();
                return _instance;
            }
        }

        #endregion

        private Dictionary<int, Item> _database = new Dictionary<int, Item>();


        public ItemDatabase()
        {

        }

        /// <summary>
        /// Initialize the database. put SERIALIZATION here
        /// Currently, we manually put some test items in it
        /// </summary>
        public void initialize()
        {
            //testing purpose only
            Dictionary<string, int> itemStats = new Dictionary<string, int>();
            itemStats.Add("power", 1);
            Item tempItem1 = new Item(1, "test item 1", "lalalalalalalalalala", null, false, itemStats);
            Add(tempItem1);
            Item tempItem2 = new Item(2, "test item 2", "booo booo booo boo boo", null, true, itemStats);
            Add(tempItem2);

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
            if (Id == -1 || Id == 0)
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