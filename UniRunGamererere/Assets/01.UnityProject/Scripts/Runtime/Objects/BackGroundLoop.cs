using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLoop : GComponenet
{
    private float width = default;

    public override void Awake()
    {
        base.Awake();
        //BoxCollider2D bgCollider = GetComponent<BoxCollider2D>();
        //width = bgCollider.size.x;
        width = gameObject.GetRectSizeDelta().x;
    }
    public override void Update()
    {
        if (transform.localPosition.x <= -width) 
        {
            Reposition();
        }
    }   //Update()


    private void Reposition()
    {
        Vector3 offset = new Vector3(width * 2f, 0f, 0f);
        transform.localPosition = transform.localPosition + offset;
    }   //Reposition();
}
