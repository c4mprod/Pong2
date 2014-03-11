using UnityEngine;
using System.Collections;
using UnityEditor;

public class PlayerCreator
{

    [MenuItem("Assets/Create/Player Model")]
    public static void CreateAsset()
    {
        CustomAssetUtility.CreateAsset<PlayerModel>();
    }
}
