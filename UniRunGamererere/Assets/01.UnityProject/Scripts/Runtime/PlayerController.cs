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

        //���콺 ���� ��ư�� �������� && �ִ� ���� Ƚ��(2)�� �������� �ʾҴٸ�
        if (Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            //���� Ƚ�� ����
            jumpCount++;
            //���� ������ �ӵ��� ���������� ����(0,0)�� ����
            playerRigid.velocity = Vector2.zero;
            //������ٵ� �������� �� �ֱ�
            playerRigid.AddForce(new Vector2(0, jumpForce));
            //����� �ҽ� ���
            playerAudio.Play();
        }
        else if (Input.GetMouseButtonUp(0) && 0 < playerRigid.velocity.y) 
        {
            //���콺 ���� ��ư���� ���� ���� ���� && �ӵ��� y ���� ������ (���� ��� ��)
            //���� �ӵ��� �������� ����
            playerRigid.velocity = playerRigid.velocity * 0.5f;
        }
        //�ִϸ������� Grounded �Ķ���͸� isGrounded ������ ����
        playerAni.SetBool("Grounded", isGrounded);
    }   //Update

    //! Player die
    private void Die() 
    {
        //�ִϸ����� Die Ʈ���� �Ķ���͸� ��
        playerAni.SetTrigger("Die");
        //����� �ҽ��� �Ҵ�� ����� Ŭ���� deathclip;���� ����
        playerAudio.clip = deathSound;
        //��� ȿ���� ���
        playerAudio.Play();

        //�ӵ��� ����(0,0)�� ����
        playerRigid.velocity = Vector2.zero;
        //��� ���¸� true�� ����
        isDead = true;
    }   //Die()

    //! Ʈ���� �浹 ���� ó���� ���� �Լ�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Deadzone" && !isDead) 
        {
            //�浹�� ������ �±װ� Dead�̸� ���� ������� �ʾҴٸ� Die()����
            Die();
        }
    }

    //!�ٴڿ� ������� üũ�ϴ� �Լ�
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //� �ݶ��̴��� �������, �浹 ǥ���� ������ ���� ������
        if (PLAYER_STEP_ON_Y_POS_MIN < collision.contacts[0].normal.y ) 
        {
            //isGrounded�� true�� �����ϰ�, ���� ���� Ƚ���� 0���� ����
            isGrounded = true;
            jumpCount = 0;
        }

        //GFunc.Log($"{collision.contacts[0].normal.y}");
    }

    //!�ٴڿ��� ������� üũ�ϴ� �Լ�
    private void OnCollisionExit2D(Collision2D collision)
    {
        //� �ݶ��̴����� ������ ��� isGrounded�� false�� ����
        isGrounded = false;
    }
}
