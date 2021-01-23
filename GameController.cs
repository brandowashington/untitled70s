using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GamePhase
{
   MENU,
   COMBAT,
   MAP,
   FIELD 
}
public class GameController : MonoBehaviour
{
   public static GameController instance;
   public int AvailableActions = 2;
   public int MaxAvailableActions = 5;
   public PlayerStateMachine PSM;
   public GamePhase PlayPhase;
   public bool inBattle = false;
   public bool inMenu = false;
   public bool onField = false;
   public battleSystem battle;


   public List<string> KeyTerms = new List<string>();

   public List<GameObject> CurrentPartyMembers = new List<GameObject>();
   public List<GameObject> CurrentEnemies;
   public int DayCount;

   public battleHUD playerHUD;
   //void Awake()
   // {
   //     playerHUD.gameObject.SetActive(false);
   // }
   public static GameController Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new GameController();
            }
            return instance;
        }
    }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        SetupParty();
        PlayPhase = GamePhase.FIELD;
    }
    public void SetupParty()
    {
        var players = GameObject.FindGameObjectsWithTag("Player");
        CurrentPartyMembers = new List<GameObject>();

        foreach (var player in players)
        {
            CurrentPartyMembers.Add(player);
        }
    }
    public void Update()
   {
      switch(PlayPhase)
        {
            case GamePhase.COMBAT:
                playerHUD.gameObject.SetActive(true);
                if (PSM.currentState == PlayerStateMachine.TurnState.ACTION)
                {
                    Time.timeScale = 1f;
                }

                break;

            case GamePhase.FIELD:
                Time.timeScale = 1f;
                break;

            case GamePhase.MAP:
                Time.timeScale = 0;
                break;

            case GamePhase.MENU:
                Time.timeScale = 0;
                break;

        }
   }
    public void StartBattle()
    {
        Debug.Log("Battle Started");
        
        
    }

}
