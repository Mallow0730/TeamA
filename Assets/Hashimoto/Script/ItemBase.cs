using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase
{
    public int Portion => _portion;

    [SerializeField]
    int _portion;
}
