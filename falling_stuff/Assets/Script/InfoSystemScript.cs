using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoSystemScript : MonoBehaviour {
    [SerializeField]
    float stepSpeed,jPRadius;
    [SerializeField]
    int hearts;


	void Awake () { 
        hearts = 3;
        stepSpeed = 6;
        jPRadius = 2; //è la max distanza tra inner e outer joystick,,,,

    }

    #region hearts
    public int GetHearts()
    {
        return hearts;
    }
    public void ModHearts(int howMuch)
    {
        hearts += howMuch;
    }
    #endregion

    #region stepspeed
    public float GetPlayerStepSpeed()
    {
        return stepSpeed;
    }
    public void ModPlayerStepSpeed(float howMuch)
    {
        stepSpeed += howMuch;
    }
    #endregion

    #region JPRADIUS
    public float GetJPRadius()
    {
        return jPRadius;
    }
    public void ModJPRadius(int howMuch)
    {
        jPRadius += howMuch;
        if (jPRadius < 1 || jPRadius > 2) { jPRadius = 2; }
    }
    #endregion

}


/*
*Copyright(c) 
*Davide "Lautz" Lauterio
*/
