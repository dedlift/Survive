using UnityEngine;
using System.Collections;
using System;   //for Enum

public class CharacterGenerator : MonoBehaviour {
    private PlayerCharacter _toon;
    private const int STARTING_POINTS = 4;
    private const int MIN_STARTING_ATTRIBUTE_VALUE = 2;
    private const int STARTING_VALUE = 3;
    private int pointsLeft;

	// Use this for initialization
	void Start () {
        _toon = new PlayerCharacter();
        _toon.Awake();

        pointsLeft = STARTING_POINTS;

        for(int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++) {
            _toon.GetPrimaryAttribute(cnt).BaseValue = MIN_STARTING_ATTRIBUTE_VALUE;
            pointsLeft -= (STARTING_VALUE - MIN_STARTING_ATTRIBUTE_VALUE * 3);
        }
        _toon.StatUpdate();
    }

    // Update is called once per frame
    void Update () {
	}

    void OnGUI()
    {
        DisplayName();
        DisplayPointsLeft();
        DisplayAttributes();
        DisplayVitals();
        DisplaySkills();
    }
    private void DisplayName()
    {
        GUI.Label(new Rect(10, 10, 50, 25), "Name:");
        _toon.Name = GUI.TextField(new Rect(65, 10, 100, 25), _toon.Name);
    }

    private void DisplayAttributes()
    {
        for (int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++) {
            GUI.Label(new Rect(10, 40 + (cnt * 25), 100, 25), ((AttributeName)cnt).ToString());
            GUI.Label(new Rect(115, 40 + (cnt * 25), 30, 25), _toon.GetPrimaryAttribute(cnt).AdjustedBaseValue().ToString());
            if(GUI.Button(new Rect(150, 40 + (cnt * 25), 25, 25), "-")){
                if(_toon.GetPrimaryAttribute(cnt).BaseValue > MIN_STARTING_ATTRIBUTE_VALUE) {
                    _toon.GetPrimaryAttribute(cnt).BaseValue--;
                    pointsLeft++;
                    _toon.StatUpdate();
                }
            }
            if (GUI.Button(new Rect(180, 40 + (cnt * 25), 25, 25), "+")){
                if(pointsLeft > 0) {
                    _toon.GetPrimaryAttribute(cnt).BaseValue++;
                    pointsLeft--;
                    _toon.StatUpdate();
                }
            }
        }
    }

    private void DisplayVitals()
    {
        for (int cnt = 0; cnt < Enum.GetValues(typeof(VitalName)).Length; cnt++)
        {
            GUI.Label(new Rect(10, 40 + ((cnt + 9) * 25), 100, 25), ((VitalName)cnt).ToString());
            GUI.Label(new Rect(115, 40 + ((cnt + 9) * 25), 30, 25), _toon.GetVital(cnt).AdjustedBaseValue.ToString());
        }
    }
    private void DisplaySkills()
    {
        for (int cnt = 0; cnt < Enum.GetValues(typeof(SkillName)).Length; cnt++)
        {
            GUI.Label(new Rect(250, 40 + (cnt * 25), 30, 25), ((SkillName)cnt).ToString());
            GUI.Label(new Rect(355, 40 + (cnt * 25), 30, 25), _toon.GetSkill(cnt).AdjustedBaseValue.ToString());
        }
    }
    private void DisplayPointsLeft() {
        GUI.Label(new Rect(250, 10, 100, 25), "Points Left: " + pointsLeft);
    }
}
