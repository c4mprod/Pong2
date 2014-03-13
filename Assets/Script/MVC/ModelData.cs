using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// This class stocks the data of the PlayerModel, it can be update by the ControllerScript, it's the Model of the MVC pattern        
/// </summary>
public class ModelData : MonoBehaviour
{
    public List<PlayerModel> m_PlayerModelGlobalList;
    public List<GameObject> m_PlayerObjectList;

   
    public int m_index = 0;

    void OnEnable()
    {
        int lIndex = 0;
        foreach(GameObject lelement in m_PlayerObjectList)
        {
            lelement.AddComponent<SpriteRenderer>();
            lelement.GetComponent<SpriteRenderer>().sprite = m_PlayerModelGlobalList[lIndex].m_SpriteModel;
            ++lIndex;
        }
        m_index = lIndex;
        ControllerScript.m_MoveIndexLeft += this.SubstractPosition;
        ControllerScript.m_MoveIndexRight += this.AddPosition;
        ControllerScript.m_GetLeftPlayer += this.GetNextPlayer;
        ControllerScript.m_getSpriteModel += this.GetModelSprite;
    }

    void OnDisable()
    {
        ControllerScript.m_MoveIndexLeft -= this.SubstractPosition;
        ControllerScript.m_MoveIndexRight -= this.AddPosition;
        ControllerScript.m_GetLeftPlayer -= this.GetNextPlayer;
        ControllerScript.m_getSpriteModel -= this.GetModelSprite;
    }

    /// <summary>
    //add 1 to the index or reset it to zero (circular infinit loop)
    /// </summary>
    public void AddPosition()
    {
        this.m_index++;
        if (this.m_index > this.m_PlayerModelGlobalList.Count - 1)
            this.m_index = 0;
    }
    /// <summary>
    //substract 1 to the index or change it to the last PlayerModel of the List (circular infinit loop)
    /// </summary>
    public void SubstractPosition()
    {
        this.m_index--;
        if (this.m_index < 0)
            this.m_index = this.m_PlayerModelGlobalList.Count - 1;
    }
   
    public GameObject GetNextPlayer(GameObject _object)
    {
        int i = -1;

        while (m_PlayerObjectList[++i] != _object) ;
        --i;
        if (i == -1)
            return this.m_PlayerObjectList[this.m_PlayerObjectList.Count - 1];
        else
            return this.m_PlayerObjectList[i];
    }

    public Sprite GetModelSprite()
    {
        return (this.m_PlayerModelGlobalList[m_index].m_SpriteModel);
    }
}