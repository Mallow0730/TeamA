using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUse : MonoBehaviour
{
    List<ItemBase> _items = new List<ItemBase>();
    public void HPItem()
    {
        _items.Add(new ItemPortion());
        UseItem(0);
    }

    private void UseItem(int index)
    {
        ItemBase useItem = _items[index];
        print(index + 1 + "つ目のアイテムを使った");
        useItem.Use();
    }
}
