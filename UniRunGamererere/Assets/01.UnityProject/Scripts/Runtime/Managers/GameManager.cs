using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = default;

    //변수화
    private const string UI_OBJS = "UiObjs";
    private const string SCORE_TEXT_OBJ = "ScoreTxt";
    private const string GAME_OVER_UI_OBJ = "GameOverUi";

    public bool isGameOver = false;
    private GameObject scoreTxtObj = default;
    private GameObject gameOverUi = default;

    private int score = default;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;

            //Init
            isGameOver = false;
            GameObject uiObjs_ = GFunc.GetRootObj(UI_OBJS);
            scoreTxtObj = uiObjs_.FindChildObj(SCORE_TEXT_OBJ);
            gameOverUi = uiObjs_.FindChildObj(GAME_OVER_UI_OBJ);

            score = 0;
        }       //if : 게임매니저가 존재하지 않는 경우 변수에 할당 및 초기화
        else
        {
            GFunc.LogWarning("[System] GameManager: Duplicated object warning exeption");
            Destroy(gameObject);
        }
    }   //Awake()

    void Start()
    {

    }

    void Update()
    {
        if (isGameOver == true && Input.GetMouseButtonDown(0))
        {
            GFunc.LoadScene(GFunc.GetActiveScene().name);
        }
    }

    //! 점수를 증가시키는 메서드
    public void AddScore(int newScore)
    {
        if (isGameOver == true) { return; }

        //게임이 진행중인겨우
        score += newScore;
        scoreTxtObj.SetTmpText($"Score : {score}");

    }   //AddScore()

    //! 플레이어 사망 시 게임오버를 출력하는 메서드
    public void OnPlayerDead()
    {
        isGameOver = true;
        gameOverUi.SetActive(true);
    }
}
