using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObjController : MonoBehaviour
{


    public string prefabName = default;
    public int scrollingObjCount = default;

    public float scrollingSpeed = default;

    protected GameObject objPrefab = default;
    protected Vector2 objPrefabSize = default;
    protected List<GameObject> scrollingPool = default;
    protected float prefabYPos = default;


    //private float lastScrObjInitXPos = default;
    public virtual void Start()
    {
        objPrefab = gameObject.FindChildObj(prefabName);
        scrollingPool = new List<GameObject>();
        GFunc.Assert(objPrefab != null || objPrefab != default);

        objPrefabSize = objPrefab.GetRectSizeDelta();
        prefabYPos = objPrefab.transform.localPosition.y;
        //{��ũ�Ѹ� Ǯ�� �����ؼ� �־��� ����ŭ �ʱ�ȭ 

        GameObject tempObj = default;
        if (scrollingPool.Count <= 0)
        {
            for (int i = 0; i < scrollingObjCount; i++)
            {
                tempObj = Instantiate(objPrefab,
                    objPrefab.transform.position,
                    objPrefab.transform.rotation, transform);

                scrollingPool.Add(tempObj);
                tempObj = default;

            }   //loop ��ũ�Ѹ� ������Ʈ�� �־��� ����ŭ �ʱ�ȭ �ϴ� ����
        }   //if: scrollingPool�� �ʱ�ȭ �Ѵ�.

        objPrefab.SetActive(false);
        //}��ũ�Ѹ� Ǯ�� �����ؼ� �־��� ����ŭ �ʱ�ȭ 
        InitObjsPosition();
        //{������ ������Ʈ�� ��ġ�� �����Ѵ�.
        
            
            //���� ������ ������Ʈ�� �ʱ�ȭ ��ġ�� ĳ���Ѵ�

        //}������ ������Ʈ�� ��ġ�� �����Ѵ�.
    }// Start()

    //�迭�� vector3 x��ǥ�� - ��� ������ x��ǥ���� reposition���� �ڷ� �Ѱ���.

    // Update is called once per frame
    public virtual void Update()
    {
        if (scrollingPool == default || scrollingPool.Count <= 0)
        {
            return;
        }   //if: ��ũ�Ѹ� �� ������Ʈ�� �������� �ʴ� ���

        if (GameManager.instance.isGameOver == false)
        {
            // ��ũ�Ѹ� �� ������Ʈ�� �����ϴ� ���
            for (int i = 0; i < scrollingObjCount; i++)
            {
                scrollingPool[i].AddLocalPos(scrollingSpeed * Time.deltaTime * (-1), 0f, 0f);

            }   //loop ��� �������� �����̰� �ϴ� ����

            //{��濡 �������� �ִ� ����
            //��ũ�Ѹ� Ǯ�� ù��° ������Ʈ�� ���������� �������Ŵ� �ϴ� ����
           RepositionFirstObj();

            //}��濡 �������� �ִ� ����

        } //if������ �������� ���
    }   //Update

    //! ������ ������Ʈ�� ��ġ�� �����ϴ� �Լ�.
    protected virtual void InitObjsPosition()
    {
        
        /*Do something*/

    }       //InitObjsPosition()

    //! ��ũ�Ѹ� Ǯ�� ù��° ������Ʈ�� ���������� �������Ŵ� �ϴ� �Լ�
    protected virtual void RepositionFirstObj() 
    {
        /*Do something*/

    }   //RepositionFirstObj()

}
