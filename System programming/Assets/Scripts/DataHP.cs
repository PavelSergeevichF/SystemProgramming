using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHP
{
    public int HP;
    public int MaxHP;
    public int RecieveHP = 5;
    public DataHP(int hp)
    {
        MaxHP = HP = hp;
    }
}
