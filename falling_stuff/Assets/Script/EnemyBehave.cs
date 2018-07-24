using UnityEngine;


public class EnemyBehave : MonoBehaviour 
{
	Transform player;
	Vector2 playerPos,direction;
	bool fire=false;
	public GameObject bul;
	GameObject nbul;
	public float wtime=0;

	void Awake () 
	{
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
		fire = !fire;		
	}


	void Update ()
	{
		playerPos = player.position;
		direction = playerPos - new Vector2 (transform.localPosition.x, transform.localPosition.y);
		//Debug.DrawRay (transform.localPosition, direction, Color.green);
		if (fire) {
			HowToFire ();
			fire = !fire;
		}
	}

    public Vector2 GiveBulletDirection() {
        return direction = playerPos - new Vector2(transform.localPosition.x, transform.localPosition.y);
    }

	void HowToFire(){
		nbul = Instantiate (bul, transform.position, Quaternion.identity, transform);
		nbul.transform.Translate (-transform.localPosition.normalized);
		nbul.GetComponent<BulletBehave> ().IMYourFather (gameObject);
		wtime = Random.Range (0, 3);
		nbul.GetComponent<BulletBehave> ().BulletInit (wtime, howMuchForce());
	}

	public void TimeToFire(){
		fire = true;
	}

    public void MoreForce(float thisMore) {
        transform.parent.GetComponent<EnemyBrain>().MoreForce(thisMore);
    }

    public float howMuchForce()
    {
        return transform.parent.GetComponent<EnemyBrain>().TheForce();
    }
		
}

/*
*Copyright(c) 
*Davide "Lautz" Lauterio
*/