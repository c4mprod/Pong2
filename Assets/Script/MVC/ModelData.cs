using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;


public class ModelData : MonoBehaviour
{
    public List<PlayerModel> m_PlayerGlobalList;
    public int m_index = 0;

    void OnEnable()
    {
        ControllerScript.m_MoveIndexLeft += this.SubstractPosition;
        ControllerScript.m_MoveIndexRight += this.AddPosition;
        ControllerScript.m_SortPlayerModel += this.GetPlayer;
    }

    void OnDisable()
    {
        ControllerScript.m_MoveIndexLeft -= this.SubstractPosition;
        ControllerScript.m_MoveIndexRight -= this.AddPosition;
        ControllerScript.m_SortPlayerModel -= this.GetPlayer;
    }

    public void AddPosition()
    {
        this.m_index++;
        if (this.m_index > this.m_PlayerGlobalList.Count - 1)
            this.m_index = 0;
    }

    public void SubstractPosition()
    {
        this.m_index--;
        if (this.m_index < 0)
            this.m_index = this.m_PlayerGlobalList.Count - 1;
    }

    public PlayerModel GetPlayer(ViewScript.PlayerIndex _index)
    {
        int lCorrelationIndex = this.m_index + ((int)_index - 1);
        if (lCorrelationIndex < 0)
            return this.m_PlayerGlobalList[this.m_PlayerGlobalList.Count - 1];
        else if (lCorrelationIndex > this.m_PlayerGlobalList.Count - 1)
            return this.m_PlayerGlobalList[0];
        else
            return this.m_PlayerGlobalList[lCorrelationIndex];
    }
}