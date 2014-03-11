using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;


public class ModelData : ScriptableObject
{
    public List<PlayerModel> m_PlayerGlobalList;
    public int m_index = 0;

    void OnEnable()
    {
        ControllerScript.m_MoveIndexLeft += this.SubstractPosition;
        ControllerScript.m_MoveIndexRight += this.AddPosition;
        ControllerScript.m_LeftPlayerModel += this.GetPlayer;
        ControllerScript.m_RightPlayerModel += this.GetPlayer;
        ControllerScript.m_MiddlePlayerModel += this.GetPlayer;
    }

    void OnDisable()
    {
        ControllerScript.m_MoveIndexLeft -= this.SubstractPosition;
        ControllerScript.m_MoveIndexRight -= this.AddPosition;
        ControllerScript.m_LeftPlayerModel -= this.GetPlayer;
        ControllerScript.m_RightPlayerModel -= this.GetPlayer;
        ControllerScript.m_MiddlePlayerModel -= this.GetPlayer;
    }

    public void AddPosition()
    {
        this.m_index++;
        if (this.m_index > this.m_PlayerGlobalList.Count)
            this.m_index = 0;
    }

    public void SubstractPosition()
    {
        this.m_index--;
        if (this.m_index < 0)
            this.m_index = this.m_PlayerGlobalList.Count;
    }

    public PlayerModel GetPlayer()
    {
        if (this.m_index == 0)
            return (this.m_PlayerGlobalList[this.m_PlayerGlobalList.Count]);
        else if (this.m_index == this.m_PlayerGlobalList.Count)
            return (this.m_PlayerGlobalList[0]);
        else
            return this.m_PlayerGlobalList[0];
    }
}