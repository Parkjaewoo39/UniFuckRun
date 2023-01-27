using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = default;

    //����ȭ
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
        }       //if : ���ӸŴ����� �������� �ʴ� ��� ������ �Ҵ� �� �ʱ�ȭ
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

    //! ������ ������Ű�� �޼���
    public void AddScore(int newScore)
    {
        if (isGameOver == true) { return; }

        //������ �������ΰܿ�
        score += newScore;
        scoreTxtObj.SetTmpText($"Score : {score}");

    }   //AddScore()

    //! �÷��̾� ��� �� ���ӿ����� ����ϴ� �޼���
    public void OnPlayerDead()
    {
        isGameOver = true;
        gameOverUi.SetActive(true);
    }
}
