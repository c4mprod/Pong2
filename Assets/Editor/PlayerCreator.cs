using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// The Class is the call the CustomAssetUtility to create a Custom Asset.       
/// </summary>
public class PlayerCreator
{

    [MenuItem("Assets/Create/Player Model")]
    public static void CreateAsset()
    {
        CustomAssetUtility.CreateAsset<PlayerModel>();
    }
}
