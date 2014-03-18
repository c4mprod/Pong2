﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// This class stocks the data of the PlayerModel, it can be update by the ControllerScript, it's the Model of the MVC pattern        
/// </summary>
public class ModelData : MonoBehaviour
{
    public List<PlayerModel> m_PlayerModelGlobalList;
    public List<GameObject> m_PlayerObjectList;
    public GameObject m_ChosenPlayer;

   
    private int m_RightIndex = 0;
    private int m_LeftIndex = 0;

    void OnEnable()
    {
        int lIndex = 0;
        foreach(GameObject lelement in m_PlayerObjectList)
        {
            lelement.AddComponent<SpriteRenderer>();
            lelement.GetComponent<SpriteRenderer>().sprite = m_PlayerModelGlobalList[lIndex].m_SpriteModel;
            lelement.GetComponentInChildren<TextMesh>().text += lIndex;
            ++lIndex;
        }
        m_RightIndex = lIndex;
        m_ChosenPlayer.GetComponent<SpriteRenderer>().sprite = m_PlayerModelGlobalList[0].m_SpriteModel;
       
        ControllerScript.m_MoveIndexLeft += this.SubstractPosition;
        ControllerScript.m_MoveIndexRight += this.AddPosition;
        ControllerScript.m_GetRightPlayer += this.GetNextPlayerRight;
        ControllerScript.m_GetLeftPlayer += this.GetNextPlayerLeft;
        ControllerScript.m_getSpriteModelRight += this.GetModelSpriteRight;
        ControllerScript.m_getSpriteModelLeft += this.GetModelSpriteLeft;
        ControllerScript.m_Reset += this.ResetAllMovement;
        ControllerScript.m_Select += this.UpdateChosenPlayer;
        ControllerScript.m_GetIndex += this.GetIndex;
        MainScript.m_GetPlayerInModel += this.GetCHosenPlayerSprite;
    }

    void OnDisable()
    {
        ControllerScript.m_MoveIndexLeft -= this.SubstractPosition;
        ControllerScript.m_MoveIndexRight -= this.AddPosition;
        ControllerScript.m_GetRightPlayer -= this.GetNextPlayerRight;
        ControllerScript.m_getSpriteModelRight -= this.GetModelSpriteRight;
        ControllerScript.m_getSpriteModelLeft -= this.GetModelSpriteLeft;
        ControllerScript.m_GetLeftPlayer -= this.GetNextPlayerLeft;
        ControllerScript.m_Reset -= this.ResetAllMovement;
        ControllerScript.m_Select -= this.UpdateChosenPlayer;
        ControllerScript.m_GetIndex += this.GetIndex;
        MainScript.m_GetPlayerInModel -= this.GetCHosenPlayerSprite;
    }

    /// <summary>
    //add 1 to the index or reset it to zero (circular infinit loop)
    /// </summary>
    public void AddPosition()
    {
        this.m_RightIndex++;
        if (this.m_RightIndex > this.m_PlayerModelGlobalList.Count - 1)
            this.m_RightIndex = 0;
        this.m_LeftIndex++;
        if (this.m_LeftIndex > this.m_PlayerModelGlobalList.Count - 1)
            this.m_LeftIndex = 0;
    }
    /// <summary>
    //substract 1 to the index or change it to the last PlayerModel of the List (circular infinit loop)
    /// </summary>
    public void SubstractPosition()
    {
        this.m_LeftIndex--;
        if (this.m_LeftIndex < 0)
            this.m_LeftIndex = this.m_PlayerModelGlobalList.Count - 1;
        this.m_RightIndex--;
        if (this.m_RightIndex < 0)
            this.m_RightIndex = this.m_PlayerModelGlobalList.Count - 1;
    }

    /// <summary>
    //Return the next player to display when he camera is dragged to the right
    /// </summary>
    public GameObject GetNextPlayerRight(GameObject _object)
    {
        int i = -1;

        while (m_PlayerObjectList[++i] != _object) ;
        --i;
        if (i == -1)
            return this.m_PlayerObjectList[this.m_PlayerObjectList.Count - 1];
        else
            return this.m_PlayerObjectList[i];
    }

    /// <summary>
    //Return the next player to display when he camera is dragged to the left
    /// </summary>
    public GameObject GetNextPlayerLeft(GameObject _object)
    {
        int i = -1;

        while (m_PlayerObjectList[++i] != _object) ;
        ++i;
        if (i > this.m_PlayerObjectList.Count - 1)
            return this.m_PlayerObjectList[0];
        else
            return this.m_PlayerObjectList[i];
    }

    /// <summary>
    //Return the next player sprite to display when he camera is dragged to the right
    /// </summary>
    public Sprite GetModelSpriteRight()
    {
        return (this.m_PlayerModelGlobalList[m_RightIndex].m_SpriteModel);
    }

    /// <summary>
    //Return the next player sprite to display when he camera is dragged to the left
    /// </summary>
    public Sprite GetModelSpriteLeft()
    {
        return (this.m_PlayerModelGlobalList[m_LeftIndex].m_SpriteModel);
    }

    /// <summary>
    // Return the index to display under the playerModel
    /// </summary>
    public int GetIndex(ControllerScript.Index _Index)
    {
        if (_Index == ControllerScript.Index.Left)
            return this.m_LeftIndex;
        else
            return this.m_RightIndex;
    }

    /// <summary>
    // Reset all the movements of the Players
    /// </summary>
    public void ResetAllMovement()
    {
        foreach (GameObject element in m_PlayerObjectList)
        {
            element.GetComponent<PlayerDisplay>()._moved = false;
        }
    }

    /// <summary>
    // update the Sprite of the chosen PlayerModel when the Player clicks on one
    /// </summary>
    public void UpdateChosenPlayer(GameObject _object)
    {
        Sprite lCurrentObjectSprite = _object.GetComponent<SpriteRenderer>().sprite;
        foreach (PlayerModel element in m_PlayerModelGlobalList)
        {
            if (element.m_SpriteModel == lCurrentObjectSprite)
            {
                m_ChosenPlayer.GetComponent<SpriteRenderer>().sprite = lCurrentObjectSprite;
            }
        }
    }

    public Sprite GetCHosenPlayerSprite()
    {
        return this.m_ChosenPlayer.GetComponent<SpriteRenderer>().sprite;
    }
}