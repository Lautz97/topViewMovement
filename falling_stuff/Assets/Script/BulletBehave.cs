using UnityEngine;


public class BulletBehave : MonoBehaviour 
{
	GameObject daddy;
    protected float delay = 3;
	protected Vector2 direction;
	protected float force;
    bool done = false;

	public void IMYourFather(GameObject dad){
        daddy = dad;
	}

	public void BulletInit(float delay, float force){
        this.delay = delay;
		this.force = force;
	}

	void Update(){
		if (delay > 0 || !done) {
            delay -= 1 * Time.deltaTime;
            if (delay <= 0) {
                direction = daddy.GetComponent<EnemyBehave>().GiveBulletDirection();
                BulletAwake(direction, force);
                delay = 0;
                done = true;
			}
		}
	}

	void BulletAwake(Vector2 dir,float bulF){
        transform.Translate(dir.normalized);
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<Rigidbody2D>().AddForceAtPosition(dir.normalized * bulF, transform.localPosition);
        GetComponent<BoxCollider2D>().enabled = true;
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.name == "Player") {
            daddy.GetComponent<EnemyBehave>().TimeToFire();
            daddy.GetComponent<EnemyBehave>().MoreForce(15f);
			Destroy (gameObject);
		}
		if (coll.tag == "Wall" || coll.tag == "Enemy") {
            daddy.GetComponent<EnemyBehave>().TimeToFire();
			Destroy (gameObject);
		}
	}

}

/*
*Copyright(c) 
*Davide "Lautz" Lauterio
*/