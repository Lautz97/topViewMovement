using UnityEngine; 

[RequireComponent (typeof(Controller2D))]
public class Player : MonoBehaviour 
{
    float stepSpeed;                

	Vector3 velocity;                   //vettore che viene passato al controller2D

	Controller2D controller;
    MyVirtualJoypad mvjp;

    [SerializeField]
    InfoSystemScript ISC;

    public GameObject rg,nrg;           

	void Start() { 
        controller = GetComponent<Controller2D>();
        mvjp = GetComponent<MyVirtualJoypad>();
        nrg = Instantiate(rg, transform.position, Quaternion.identity);
        stepSpeed = ISC.GetPlayerStepSpeed();
    }
	
	void Update (){

        velocity.x = mvjp.GetInputVec().x * (stepSpeed / 2);          //controller.Input2DTop().x * stepSpeed;
        velocity.y = mvjp.GetInputVec().y * (stepSpeed / 2);          //controller.Input2DTop().y * stepSpeed;

        controller.Move (velocity * Time.deltaTime);

	}

}

/*
*Copyright(c) 
*Davide "Lautz" Lauterio
*/