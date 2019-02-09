using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonterData : MonsterBase
{

    public MonterData(int Lv, string MonsterName, int HP, int Attack) {
        this._Lv = Lv;
        this._MonsterName = MonsterName;
        this._HP = HP;
        this._Attack = Attack;

    }

    public int Lv {
        get {
            return this._Lv;
        }
        set {
        }
    }

    public string MonsterName {
        get {
            return this._MonsterName;
        }
        set
        {
        }
    }
    public int HP {
        get {
            return this._HP;
        }
        set
        {
        }
    }

    public int Attack {

        get {
            return this._Attack;
        }
        set
        {
        }
    }


}
