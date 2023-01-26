using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObjController : MonoBehaviour
{
    public string prefabName = default;
    public int scrollingObjCount = default;

    private GameObject objPrefab = default;
    private Vector2 objPrefabSize = default;
    private List<GameObject> scrollingPool = default;
    void Start()
    {
        objPrefab = gameObject.FindChildObj(prefabName);
        scrollingPool = new List<GameObject>();
        GFunc.Assert(objPrefab != null || objPrefab != default);

        objPrefabSize = objPrefab.GetRectSizeDelta();
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

        //������ ������Ʈ�� ������ �����Ѵ�.
        //int scrollCntIndex = scrollingObjCount - 1;
        float horizonPos = 
            objPrefabSize.x * scrollingObjCount * (-1) * 0.5f;

        for (int i = 0; i < scrollingObjCount; i++)
        {
            scrollingPool[i].SetLocalPos(horizonPos, 0f, 0f);

            horizonPos = horizonPos + objPrefabSize.x;

        }   //loop ������ ������Ʈ�� ���η� ���ʺ��� ���ʴ�� �����ϴ� ����
        new Vector3(objPrefabSize.x * (scrollingObjCount - 1) * (-1) * 0.5f, 0f, 0f);

    }

    //�迭�� vector3 x��ǥ�� - ��� ������ x��ǥ���� reposition���� �ڷ� �Ѱ���.

    // Update is called once per frame
    void Update()
    {
        
    }
}
