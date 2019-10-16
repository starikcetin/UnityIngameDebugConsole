using UnityEditor;
using UnityEngine;

namespace IngameDebugConsole
{
    internal class Instantiator : ScriptableObject
    {
        private static Instantiator _instance;
        private static Instantiator Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = CreateInstance<Instantiator>();
                }

                return _instance;
            }
        }

        [SerializeField] private GameObject _prefab;

        [MenuItem("GameObject/Ingame Debug Console", false, 12)]
        private static void InstantiatePrefab()
        {
            Selection.activeObject = PrefabUtility.InstantiatePrefab(Instance._prefab);
        }

        [MenuItem("GameObject/Ingame Debug Console", true, 12)]
        private static bool ValidateInstantiatePrefab()
        {
            var go = Instance._prefab;
            return go != null && PrefabUtility.IsPartOfPrefabAsset(go);
        }
    }
}
