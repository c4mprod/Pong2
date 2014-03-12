using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// The Class is the "Controller" of the MVC pattern, it can update the ModelData, get infos from The MOdelData and transfert the to the View       
/// </summary>
/// 
public class ControllerScript : MonoBehaviour
{

    /// <List name="m_PlayerListToDisplay"> List of the PlayerModels which will be display in the View </param>
    private List<PlayerModel> m_PlayerListToDisplay =  new List<PlayerModel>(3);


    /// <summary>
    /// This delegate is used to update the index in the ModelData       
    /// </summary
    public delegate void MoveIndex();
    public static event MoveIndex m_MoveIndexRight;
    public static event MoveIndex m_MoveIndexLeft;


    /// <summary>
    /// This delegate is used get the 3 PlayerModel To display       
    /// </summary
    public delegate PlayerModel SortPlayerModel(ViewScript.PlayerIndex _index);
    public static event SortPlayerModel m_SortPlayerModel;

    void OnEnable()
    {
        ViewScript.m_GetPlayerModel += this.GetPlayerByIndex;
        ViewScript.m_ClickLeftButton += UpdateIndexLeft;
        ViewScript.m_ClickRightButton += UpdateIndexRight;
    }

    void OnDisable()
    {
        ViewScript.m_GetPlayerModel -= this.GetPlayerByIndex;
        ViewScript.m_ClickLeftButton -= UpdateIndexLeft;
        ViewScript.m_ClickRightButton -= UpdateIndexRight;
    }

    private void SortPlayerToDisplay()
    {
        if (this.m_PlayerListToDisplay.Count == 0)
        {
           if (m_SortPlayerModel != null)
                this.m_PlayerListToDisplay.Add(m_SortPlayerModel(ViewScript.PlayerIndex.Left));
            if (m_SortPlayerModel != null)
                this.m_PlayerListToDisplay.Add(m_SortPlayerModel(ViewScript.PlayerIndex.Middle));
            if (m_SortPlayerModel != null)
                this.m_PlayerListToDisplay.Add(m_SortPlayerModel(ViewScript.PlayerIndex.Right));
        }
        else
        {
            if (m_SortPlayerModel != null)
                this.m_PlayerListToDisplay[0] = m_SortPlayerModel(ViewScript.PlayerIndex.Left);
            if (m_SortPlayerModel != null)
                this.m_PlayerListToDisplay[1] = m_SortPlayerModel(ViewScript.PlayerIndex.Middle);
            if (m_SortPlayerModel != null)
                this.m_PlayerListToDisplay[2] = m_SortPlayerModel(ViewScript.PlayerIndex.Right);
        }
    }

    public PlayerModel GetPlayerByIndex(ViewScript.PlayerIndex _index)
    {
        this.SortPlayerToDisplay();
        return this.m_PlayerListToDisplay[(int)_index];
    }

    public void UpdateIndexRight()
    {
        if (m_MoveIndexRight != null)
            m_MoveIndexRight();
    }

    public void UpdateIndexLeft()
    {
        if (m_MoveIndexLeft != null)
            m_MoveIndexLeft();
    }
}
