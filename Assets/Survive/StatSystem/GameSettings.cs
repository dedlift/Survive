using UnityEngine;
using System.Collections;

public class GameSettings : MonoBehaviour
{

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //PlayerPrefs.SetString("Player Name", );
    }

    void SaveCharacterData()
    {

    }

    void LoadCharacterData()
    {

    }
}
