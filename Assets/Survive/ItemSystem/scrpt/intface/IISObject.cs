using UnityEngine;
using System.Collections;

public interface IISObject {
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

    //canEquip
    //isQuestItem
    //canTakeDamage
    //canTrade
}
