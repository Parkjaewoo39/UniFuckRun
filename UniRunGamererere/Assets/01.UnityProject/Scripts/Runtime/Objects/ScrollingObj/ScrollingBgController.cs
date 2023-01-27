using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBgController : ScrollingObjController
{
    public override void Start() 
    {
        base.Start();
    }

    public override void Update() 
    {
        base.Update();
    }

    protected override void InitObjsPosition() 
    {
        base.InitObjsPosition();

        float horizonPos =
            objPrefabSize.x * (scrollingObjCount - 1) * (-1) * 0.5f;

        for (int i = 0; i < scrollingObjCount; i++)
        {
            scrollingPool[i].SetLocalPos(horizonPos, 0f, 0f);

            horizonPos = horizonPos + objPrefabSize.x;

        }   //loop ������ ������Ʈ�� ���η� ���ʺ��� ���ʴ�� �����ϴ� ����       
            //���� ������ ������Ʈ�� �ʱ�ȭ ��ġ�� ĳ���Ѵ�
            //}������ ������Ʈ�� ��ġ�� �����Ѵ�.
    }

    protected override void RepositionFirstObj() 
    {
        base.RepositionFirstObj();

        float lastScObjCurrentXPos = scrollingPool[scrollingObjCount - 1].transform.localPosition.x - 1;
        if (lastScObjCurrentXPos <= objPrefabSize.x * 0.5f)
        {
            float lastScrObjInitXPos =
                Mathf.Floor(scrollingObjCount * 0.5f) * objPrefabSize.x + (objPrefabSize.x * 0.5f);

            scrollingPool[0].SetLocalPos(lastScrObjInitXPos, 0f, 0f);
            scrollingPool.Add(scrollingPool[0]);
            scrollingPool.RemoveAt(0);

            //DEBUG:
            //GFunc.Log($"List Pos: {scrollingPool[0].transform.localPosition}, " +
            //    $"{scrollingPool[2].transform.localPosition}");
        }   //if: ��ũ�Ѹ� ������Ʈ�� ������ ������Ʈ�� ȭ�� ���� �������� Draw �Ǵ� ��
    }


}
