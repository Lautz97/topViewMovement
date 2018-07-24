using UnityEngine;
using System.Collections;

public class MyVirtualJoypad : MonoBehaviour{

    private Vector2 inputvec = Vector2.zero,
                    theCenterPos = Vector2.zero,
                    fingerPos = Vector2.zero;
    public GameObject joy;
    private GameObject joy1;

    private float radiusMultiplier = 0;

    private void Start()
    {
        radiusMultiplier = GameObject.Find("InfoSystem").GetComponent<InfoSystemScript>().GetJPRadius();
        if (radiusMultiplier == 0) { radiusMultiplier = 2; }
    }

    private void FixedUpdate()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) 
        {
            theCenterPos = GetfingerPos();
            joy1 = Instantiate(joy, theCenterPos, Quaternion.identity);
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            inputvec = GetfingerPos() - theCenterPos;
            inputvec = (inputvec.magnitude > 2.0f) ? inputvec.normalized * 2 : inputvec;
            joy1.transform.FindChild("outer").transform.localPosition = inputvec* radiusMultiplier;
        }
        
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            inputvec = Vector2.zero;
            Destroy(joy1);
        }
        if (Input.touchCount == 0)
        {
            inputvec = Vector2.zero;
            Destroy(joy1);
        }
    }

    public Vector2 GetInputVec()
    {
        return inputvec;
    }

    private Vector2 GetfingerPos()
    {
        if (Input.touchCount > 0)
        {
            fingerPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        }
        else
        {
            fingerPos = Vector2.zero;
        }
        return fingerPos;
    }

}


/*
*Copyright(c) 
*Davide "Lautz" Lauterio
*/
