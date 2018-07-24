using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Controller2D : MonoBehaviour 
{
	#region variables
	public LayerMask collisionMask;											//maschera di collisione dell'ostacolo
	const float skinWidth = 0.015f;											//Spressore della pelle, ossia da dove il raycast viene istanziato

	public int horizontalRayCount = 4;										
	public int verticalRayCount = 4;										

	float horizontalRaySpacing;
	float verticalRaySpacing;

	BoxCollider2D bc;
	RaycastOrigin rcOrigin;     //Origine dei raycast

	Vector2 input;      //input detected by "Player.cs"
	#endregion

	void Awake (){
		
		bc = GetComponent<BoxCollider2D> ();
		CalculateRaySpacing ();
	
	}

	public void Move (Vector3 velocity){
		
		UpdateRcOrigin (); 

		if (velocity.y != 0) {
			VerticalCollisions (ref velocity);
		}
		if (velocity.x != 0) {
			HorizontalCollisions (ref velocity);
		}

		transform.Translate (velocity);
	}

		
	#region check collision
	void VerticalCollisions (ref Vector3 velocity){
		
		float directionY = Mathf.Sign (velocity.y);
		float rayLenght = Mathf.Abs (velocity.y) + skinWidth;
		float newVel = 0;

		for (int i = 0; i < verticalRayCount; i++) {
			
			Vector2 rayOrigin = (directionY == -1) ? rcOrigin.bottomLeft : rcOrigin.topLeft;

			rayOrigin += Vector2.right * (verticalRaySpacing * i + velocity.x);

			RaycastHit2D hit = Physics2D.Raycast (rayOrigin, Vector2.up * directionY, rayLenght, collisionMask);

			Debug.DrawRay (rayOrigin, Vector2.up * directionY * rayLenght, Color.red);

			if (hit) 
			{
				newVel = (hit.distance - skinWidth);
				velocity.y = (newVel < 0 ? 0 : newVel) * directionY;
				rayLenght = hit.distance;
			}
		}
	}

	void HorizontalCollisions (ref Vector3 velocity){
		
		float directionX = Mathf.Sign (velocity.x);
		float rayLenght = Mathf.Abs (velocity.x) + skinWidth;
		float newvel = 0;

		for (int i = 0; i < horizontalRayCount; i++) {

			Vector2 rayOrigin = (directionX == -1) ? rcOrigin.bottomLeft : rcOrigin.bottomRight;

			rayOrigin += Vector2.up * (horizontalRaySpacing * i);

			RaycastHit2D hit = Physics2D.Raycast (rayOrigin, Vector2.right * directionX, rayLenght, collisionMask);

			Debug.DrawRay (rayOrigin, Vector2.right * directionX * rayLenght, Color.red);

			if (hit) 
			{
				newvel = hit.distance - skinWidth;
				velocity.x = (newvel < 0 ? 0 : newvel) * directionX;
				rayLenght = hit.distance;
			}

		}
	}
	#endregion


	void UpdateRcOrigin (){
		
		Bounds bounds = bc.bounds;
		bounds.Expand (skinWidth * -2);

		rcOrigin.bottomLeft = new Vector2 (bounds.min.x, bounds.min.y);
		rcOrigin.bottomRight = new Vector2 (bounds.max.x, bounds.min.y);
		rcOrigin.topLeft = new Vector2 (bounds.min.x, bounds.max.y);
		rcOrigin.topRight = new Vector2 (bounds.max.x, bounds.max.y);

	}

    #region instantiating myself and my needs
    void CalculateRaySpacing (){

		Bounds bounds = bc.bounds;
		bounds.Expand (skinWidth * -2);

		horizontalRayCount = Mathf.Clamp (horizontalRayCount, 2, int.MaxValue);
		verticalRayCount = Mathf.Clamp (verticalRayCount, 2, int.MaxValue);

		horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
		verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);
	
	}

	struct RaycastOrigin{
		public Vector2 topLeft, topRight, bottomLeft, bottomRight;	
	}
	#endregion
}

/*
*Copyright(c) 
*Davide "Lautz" Lauterio
*/