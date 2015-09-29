using UnityEngine;
using System.Collections;
using UnityEditor;

namespace Survive.ItemSystem.Editor
{

    public partial class ISQualityDBEditor : EditorWindow
    {
        ISQualityDB qualityDB;
        ISQuality selectedItem;
        Texture2D selectedTexture;
        int selectedIndex = -1;
        Vector2 _scrollPos; //scroll position for ListView

        const int SPRITE_BUTTON_SIZE = 32;
        const string DBFILENAME = @"SurviveQualityDB.asset";
        const string DBFOLDERNAME = @"DB";
        const string FULLDBPATH = @"Assets/" + DBFOLDERNAME + "/" + DBFILENAME;


        [MenuItem("Survive/Database/QualityEditor %#i")]
        public static void Init()
        {
            ISQualityDBEditor window = EditorWindow.GetWindow<ISQualityDBEditor>();
            window.minSize = new Vector2(400, 300);
            window.title = "Quality Database";
            window.Show();
        }

        void OnEnable()
        {
            //load database
            qualityDB = AssetDatabase.LoadAssetAtPath(FULLDBPATH, typeof(ISQualityDB)) as ISQualityDB;

            //check if db exists
            if (qualityDB == null)
            {
                //does database folder exist? if not create
                if (!AssetDatabase.IsValidFolder(@"Assets/" + DBFOLDERNAME))
                    AssetDatabase.CreateFolder("Assets", DBFOLDERNAME);

                //create database
                qualityDB = ScriptableObject.CreateInstance<ISQualityDB>();
                AssetDatabase.CreateAsset(qualityDB, FULLDBPATH);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
            selectedItem = new ISQuality();
        }

        void OnGUI()
        {
            ListView();
            //AddQualityToDatabase();
            //GUILayout.Label("This is a label");
        }

        void AddQualityToDatabase()
        {
            //name
            //sprite
            selectedItem.Name = EditorGUILayout.TextField("Name:", selectedItem.Name);

            if (selectedItem.Icon)
                selectedTexture = selectedItem.Icon.texture;
            else
                selectedTexture = null;

            if (GUILayout.Button(selectedTexture, GUILayout.Width(SPRITE_BUTTON_SIZE), GUILayout.Height(SPRITE_BUTTON_SIZE)))
            {
                int controllerID = EditorGUIUtility.GetControlID(FocusType.Passive);
                EditorGUIUtility.ShowObjectPicker<Sprite>(null, true, null, controllerID);
            }

            string commandName = Event.current.commandName;
            if (commandName == "ObjectSelectorUpdated")
            {
                selectedItem.Icon = (Sprite)EditorGUIUtility.GetObjectPickerObject();
                Repaint();
            }

            if (GUILayout.Button("Save"))
            {
                if (selectedItem == null)
                    return;

                if (selectedItem.Name == "") return;

                qualityDB.Add(selectedItem);
                
                selectedItem = new ISQuality();
            }
        }
    }
}