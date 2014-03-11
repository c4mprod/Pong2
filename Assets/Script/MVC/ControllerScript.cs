using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControllerScript : ScriptableObject
{
    private List<PlayerModel> m_PlayerListToDisplay =  new List<PlayerModel>(3);

    public delegate void MoveIndex();
    public static event MoveIndex m_MoveIndexRight;
    public static event MoveIndex m_MoveIndexLeft;

    public delegate PlayerModel SortPlayerModel();
    public static event SortPlayerModel m_LeftPlayerModel;
    public static event SortPlayerModel m_MiddlePlayerModel;
    public static event SortPlayerModel m_RightPlayerModel;



}
