using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float PLAYER_STEP_ON_Y_POS_MIN = 0.7f;
    
    public AudioClip deathSound = default;
    public float jumpForce = default;

    private int jumpCount = default;
    private bool isGrounded = false;
    private bool isDead = false;


    #region Player's component
    private Rigidbody2D playerRigid = default;
    private Animator playerAni = default;
    private AudioSource playerAudio = default;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //Set player's componenets
        playerRigid = gameObject.GetComponentMust<Rigidbody2D>();
        playerAni = gameObject.GetComponentMust<Animator>();
        playerAudio = gameObject.GetComponentMust<AudioSource>();

        //GFunc.Assert(playerRigid != null || playerRigid != default);
        //GFunc.Assert(playerAni != null || playerAni != default);
        //GFunc.Assert(playerAudio != null || playerAudio != default);

       // GFunc.Log("is sss" );
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == true) 
        {
            return;
        }

        //마우스 왼쪽 버튼을 눌렀으며 && 최대 점프 횟수(2)에 도달하지 않았다면
        if (Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            //점프 횟수 증가
            jumpCount++;
            //점프 직전에 속도를 순간적으로 제로(0,0)로 변경
            playerRigid.velocity = Vector2.zero;
            //리지드바디에 위쪽으로 힘 주기
            playerRigid.AddForce(new Vector2(0, jumpForce));
            //오디오 소스 재생
            playerAudio.Play();
        }
        else if (Input.GetMouseButtonUp(0) && 0 < playerRigid.velocity.y) 
        {
            //마우스 왼쪽 버튼에서 손을 떼는 순간 && 속도의 y 값이 양수라면 (위로 상승 중)
            //현재 속도를 절반으로 변경
            playerRigid.velocity = playerRigid.velocity * 0.5f;
        }
        //애니메이터의 Grounded 파라미터를 isGrounded 값으로 갱신
        playerAni.SetBool("Grounded", isGrounded);
    }   //Update

    //! Player die
    private void Die() 
    {
        //애니메이터 Die 트리거 파라미터를 셋
        playerAni.SetTrigger("Die");
        //오디오 소스에 할당된 오디로 클립을 deathclip;으로 변경
        playerAudio.clip = deathSound;
        //사망 효과음 재생
        playerAudio.Play();

        //속도를 제로(0,0)로 변경
        playerRigid.velocity = Vector2.zero;
        //사망 상태를 true로 변경
        isDead = true;
    }   //Die()

    //! 트리거 충돌 감지 처리를 위한 함수
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Deadzone" && !isDead) 
        {
            //충돌한 상대방의 태그가 Dead이며 아직 사망하지 않았다면 Die()실행
            Die();
        }
    }

    //!바닥에 닿았을때 체크하는 함수
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //어떤 콜라이더와 닿았으며, 충돌 표면이 위쪽을 보고 있으면
        if (PLAYER_STEP_ON_Y_POS_MIN < collision.contacts[0].normal.y ) 
        {
            //isGrounded를 true로 변경하고, 누적 점프 횟수를 0으로 리셋
            isGrounded = true;
            jumpCount = 0;
        }

        //GFunc.Log($"{collision.contacts[0].normal.y}");
    }

    //!바닥에서 벗어났는지 체크하는 함수
    private void OnCollisionExit2D(Collision2D collision)
    {
        //어떤 콜라이더에서 떼어진 경우 isGrounded를 false로 변경
        isGrounded = false;
    }
}
