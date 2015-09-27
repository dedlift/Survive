using UnityEngine;
using System.Collections;

namespace Survive.ItemSystem
{
    public interface IISQuality
    {
        //grey white green blue orange teal purple
        string Name { get; set; }
        Sprite Icon { get; set; }
    }
}