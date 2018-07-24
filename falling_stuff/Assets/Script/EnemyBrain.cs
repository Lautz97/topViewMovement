using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrain : MonoBehaviour {

    public List<GameObject> walls;
    int nlw = 0;    ////ultimo muro
    int nle = 0;    ///ultimo enemy
    public List<GameObject> enemies;
    float force = 100;

    float delay = 1;

    void Update() {
        if (nlw > 0)
        {
            if (delay > 0)
            {
                delay -= 1 * Time.deltaTime;
                if (delay <= 0)
                {
                    WALLMORPH();
                    delay = Random.Range(12, 20);
                }
            }
        }
    }
	
	public void Add2Walls (GameObject nWall) {
        walls.Add(nWall);
        nlw++;
    }

    public void Add2Enemies(GameObject nEnemy) {
        enemies.Add(nEnemy);
        nle++;
    }

    public void MoreForce(float thisMore)
    {
        force += thisMore;
    }

    public float TheForce()
    {
        return force;
    }

    public void WALLMORPH()
    {
        int choosen = Random.Range(0, nlw);
        GameObject oldWall = walls[choosen];
        walls.Remove(walls[choosen]);
        nlw--;
        Add2Enemies(oldWall);
        nle++;
        GetComponent<RoomGen>().InstantEnemyAtPos(oldWall.transform.position);
        Destroy(oldWall);
    }

}


/*
*Copyright(c) 
*Davide "Lautz" Lauterio
*/
