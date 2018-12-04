using Assets.Scripts.MainScene;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Assets.Scripts.MainScene.SubManagers.InventoryManager;


public class InventoryManager : IGameManager
{
    private Dictionary<int, Item> _items = new Dictionary<int, Item>();
    private Dictionary<int, int> _itemStack = new Dictionary<int, int>();
    private Item _chosenItem = null;


    public bool SetChosenItem (int Id)
    {
        Item tempItem = GetItem(Id);
        if (tempItem == null)
        {
            return false;
        }
        _chosenItem = tempItem;
        return true;
    }

    public InventoryManager(MainSceneTreeNodeManager center) : base(center)
    {
    }


    /// <summary>
    /// Initialize the database. put SERIALIZATION here
    /// Currently, we manually put some test items in it
    /// </summary>
    public override void Initialize()
    {
        //test only
        Add(1, 1);
        Add(2, 1);

    }

    public override void Release()
    {
    }

    public override void Update()
    {
    }

    public override void FixedUpdate()
    {
    }

    /// <summary>
    /// Destroy during unload. put DESERIALIZATION here
    /// </summary>
    public void Destroy()
    {
    }

    //API for all items
    #region items dictionary related API

    public bool Add(int Id, int? Count)
    {
        if (Id <= 0)
        {
            return false;
        }
        Item item = ItemDatabase.Instance.GetItem(Id);
        if (item == null)
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

    public bool Remove(int Id)
    {
        bool localSuccess = false;
        if (Id <= 0)
        {
            return false;
        }
        Item item = ItemDatabase.Instance.GetItem(Id);
        if (item == null)
        {
            return false;
        }

        if (_items.ContainsKey(Id))
        {
            _items.Remove(Id);
            if (item.CanStack)
            {
                localSuccess = RemoveItemFromStack(Id);
            }
            else
            {
                localSuccess = true;
            }
            if (! localSuccess )
            {
                return false;
            }
            GameObject.Destroy(item.ItemObject);
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

    public ICollection<int> GetItemIds()
    {
        return _items.Keys;
    }


    #endregion items dictionary related API

    //API for stackable items. Called by parents and item dictionary API
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

    private bool UseItem(int id)
    {
        Debug.Log("use item with id: " + id);
        return true;
    }

    private bool RemoveItem(int id)
    {
        Remove(id);
        return true;
    }

    public int getUnstackableItemCount()
    {
        int itemNum = ItemCount();
        int StackableItemNum = StackableItemCount();
        if (itemNum < 0 || StackableItemNum < 0)
        {
            return -1;
        }

        int unstackableItemNum = itemNum - StackableItemNum;
        if (unstackableItemNum >= 0)
        {
            return unstackableItemNum;
        }
        return -1;
    }


    public bool UseChosenItem()
    {
        if (_chosenItem == null)
        {
            return false;
        }
        return UseItem(_chosenItem.Id);
    }

    public bool RemoveChosenItem()
    {
        bool localSuccess = false;
        if (_chosenItem == null)
        {
            return false;
        }
        localSuccess = RemoveItem(_chosenItem.Id);
        _chosenItem = null;
        return localSuccess;
    }

}