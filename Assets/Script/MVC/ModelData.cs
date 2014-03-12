using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// This class stocks the data of the PlayerModel, it can be update by the ControllerScript, it's the Model of the MVC pattern        
/// </summary
public class ModelData : MonoBehaviour
{
    public List<PlayerModel> m_PlayerGlobalList;

    /// <int name="m_indew">the int is the index which point out what PlayerModel will be in the cente Label of the GUI </param>
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

    /// <summary>
    //add 1 to the index or reset it to zero (circular infinit loop)
    /// </summary
    public void AddPosition()
    {
        this.m_index++;
        if (this.m_index > this.m_PlayerGlobalList.Count - 1)
            this.m_index = 0;
    }
    /// <summary>
    //substract 1 to the index or change it to the last PlayerModel of the List (circular infinit loop)
    /// </summary
    public void SubstractPosition()
    {
        this.m_index--;
        if (this.m_index < 0)
            this.m_index = this.m_PlayerGlobalList.Count - 1;
    }
    /// <summary>
    // choose which player to display, depending on the parameter _index (Left, Right, Middle), it allow the controller to get the left player, the right player or the player whiwh correspond to the index
    /// </summary
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