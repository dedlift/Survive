using UnityEngine;
using System.Collections;

namespace Survive.ItemSystem
{
    public interface IISObject
    {
        //name
        //icon
        string ISName { get; set; }
        Sprite ISIcon { get; set; }

        //value in gold
        int ISValue { get; set; }
        //quality
        //durability
        //size
        //weight
        int ISWeight { get; set; }

        //these go to other item interfaces
        //canEquip
        //isQuestItem
        //canTakeDamage
        //canTrade
        //prefab
    }
}