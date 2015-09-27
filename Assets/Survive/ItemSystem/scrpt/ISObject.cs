using UnityEngine;
using System.Collections;
using System;

namespace Survive.ItemSystem
{
    public class ISObject : IISObject
    {
        [SerializeField]
        string _name;
        [SerializeField]
        Sprite _icon;
        [SerializeField]
        int _value;
        [SerializeField]
        int _weight;
        [SerializeField]
        ISQuality _quality;

        public string ISName
        {
            get { return _name; }
            set { _name = value; }
        }

        public Sprite ISIcon
        {
            get { return _icon; }
            set { _icon = value; }
        }

        public int ISValue
        {
            get { return _value; }
            set { _value = value; }
        }

        public int ISWeight
        {
            get { return _weight; }
            set { _weight = value; }
        }
        public ISQuality ISQuality
        {
            get { return _quality; }
            set { _quality = value; }
        }
    }
}