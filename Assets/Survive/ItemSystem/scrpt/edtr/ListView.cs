using UnityEditor;
using UnityEngine;
using System.Collections;

namespace Survive.ItemSystem.Editor
{

    public partial class ISQualityDBEditor {
        // list all of the stored qualities in the database
        void ListView()
        {
            // GUILayout.Label("Displayed");
            _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos, GUILayout.ExpandHeight(true));

            DisplayQualities();

            EditorGUILayout.EndScrollView();

        }
        void DisplayQualities()
        {
            for(int cnt = 0; cnt < qualityDB.Count; cnt++)
            {
                GUILayout.BeginHorizontal("Box");
                //sprite
                if (qualityDB.Get(cnt).Icon)
                    selectedTexture = qualityDB.Get(cnt).Icon.texture;
                else selectedTexture = null;

                if(GUILayout.Button(selectedTexture, GUILayout.Width(SPRITE_BUTTON_SIZE), GUILayout.Height(SPRITE_BUTTON_SIZE))) {
                    int controllerID = EditorGUIUtility.GetControlID(FocusType.Passive);
                    EditorGUIUtility.ShowObjectPicker<Sprite>(null, true, null, controllerID);
                    selectedIndex = cnt;
                }

                string commandName = Event.current.commandName;
                if (commandName == "ObjectSelectorUpdated")
                {
                    if (selectedIndex != -1)
                    {
                        qualityDB.Get(selectedIndex).Icon = (Sprite)EditorGUIUtility.GetObjectPickerObject();
                        //selectedIndex = -1;
                    }
                    Repaint();
                }

                GUILayout.BeginVertical();

                //name
                qualityDB.Get(cnt).Name = GUILayout.TextField(qualityDB.Get(cnt).Name);
                //delete button
                if (GUILayout.Button("x", GUILayout.Width(32), GUILayout.Height(32)))
                {
                    if(EditorUtility.DisplayDialog("Delete Quality",
                                                   "Are you sure that you want to delete " + qualityDB.Get(cnt).Name + "from the database?",
                                                   "Delete",
                                                   "Cancel"))
                        qualityDB.Remove(cnt);
                }
                GUILayout.EndVertical();
                GUILayout.EndHorizontal();
            }
        }
    }
}
