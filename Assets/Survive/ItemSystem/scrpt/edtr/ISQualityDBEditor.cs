using UnityEngine;
using System.Collections;
using UnityEditor;

namespace Survive.ItemSystem.Editor
{

    public class ISQualityDBEditor : EditorWindow
    {
        ISQualityDB db;
        const string DBFILENAME = @"SurviveQualityDB.asset";
        const string DBFOLDERNAME = @"Database";
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
            db = AssetDatabase.LoadAssetAtPath(FULLDBPATH, typeof(ISQualityDB)) as ISQualityDB;

            if (db == null)
            {
                if (!AssetDatabase.IsValidFolder("Assets/" + FULLDBPATH))
                {
                    AssetDatabase.CreateFolder("Assets", FULLDBPATH);
                    db = ScriptableObject.CreateInstance<ISQualityDB>();
                    AssetDatabase.CreateAsset(db, FULLDBPATH);
                    AssetDatabase.SaveAssets();
                    AssetDatabase.Refresh();
                }
            }
        }
    }
}