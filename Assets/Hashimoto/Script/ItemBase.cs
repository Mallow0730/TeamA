using UnityEngine;

public class ItemBase
{
    public virtual void Use() => Debug.Log(ToString() + "を使った");
}
