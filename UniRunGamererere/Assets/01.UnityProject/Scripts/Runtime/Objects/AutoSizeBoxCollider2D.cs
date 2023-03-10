using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSizeBoxCollider2D : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        Vector2 objSize_ = default;
        BoxCollider2D boxCollider_ = 
            gameObject.GetComponentMust<BoxCollider2D>();
        RectTransform parentrectTransform_ = transform.parent.
            gameObject.GetComponentMust<RectTransform>();
        RectTransform rectTransform_ =
            gameObject.GetComponentMust<RectTransform>();

        objSize_.x = parentrectTransform_.sizeDelta.x;
        objSize_.y = rectTransform_.sizeDelta.y;

        boxCollider_.size = objSize_;


        //GFunc.Log($"Rect size: ({rectTransform_.sizeDelta.x}, "+
        //    $"{rectTransform_.sizeDelta.y})");
    }   //Start()

    
}
