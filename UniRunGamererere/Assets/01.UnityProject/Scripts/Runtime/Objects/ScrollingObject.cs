using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public float mapScrollingspeed = default;   //scroll¼Óµµ
    
    private void Update()
    {
        transform.Translate(Vector2.left * mapScrollingspeed * Time.deltaTime);
    }   //Update()
}
