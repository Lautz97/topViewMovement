using UnityEngine;
public class RoomGen : MonoBehaviour 
{
    [SerializeField]
    GameObject wall, obs;
    Vector3 blockPosition, creatore;
	public int roomLenght, roomHeight;
	public float wallLenght = 0.5f, wallHeight = 0.5f;
    [SerializeField]
    Camera mainCam;
    [SerializeField]
    float horScreenLimit, verScreenLimit;
    GameObject volatileNW, volatileNE;

	
	void Awake () {

        verScreenLimit = mainCam.orthographicSize + mainCam.transform.position.y;
        horScreenLimit = (mainCam.orthographicSize * Screen.width / Screen.height) + mainCam.transform.position.x;

        roomLenght = (int)horScreenLimit * 2;
		roomHeight = (int)verScreenLimit * 2;

        blockPosition = new Vector3(-(roomLenght / 2), -(roomHeight / 2), 0.0f);

        for (int rh = -1; rh < roomLenght + 1; rh++) {

            if (rh == -1 || rh == roomLenght)
            {
                Instantiate(wall, transform.position + new Vector3(blockPosition.x - 0.5f, -blockPosition.y, 0.0f), Quaternion.identity, transform);

                Instantiate(wall, transform.position + new Vector3(blockPosition.x - 0.5f, blockPosition.y, 0.0f), Quaternion.identity, transform);

            } else {                                                                                                                                        //if (blockPosition.x != 0) {

                volatileNW = Instantiate(wall, transform.position + new Vector3(blockPosition.x - 0.5f, -blockPosition.y, 0.0f), Quaternion.identity, transform);
                gameObject.GetComponent<EnemyBrain>().Add2Walls(volatileNW);

                volatileNW = Instantiate(wall, transform.position + new Vector3(blockPosition.x - 0.5f, blockPosition.y, 0.0f), Quaternion.identity, transform);         //}     //if (blockPosition.x == 0) {   //    Instantiate(obs, transform.position + new Vector3(blockPosition.x - 0.5f, -blockPosition.y, 1.0f), Quaternion.identity, transform);   //   Instantiate(obs, transform.position + new Vector3(blockPosition.x - 0.5f, blockPosition.y, 1.0f), Quaternion.identity, transform);
                gameObject.GetComponent<EnemyBrain>().Add2Walls(volatileNW);

            }
			blockPosition.x++;
		}

        blockPosition = new Vector3(-(roomLenght / 2), -(roomHeight / 2) + 1, 0.0f);

		for (int rh = 0; rh < roomHeight-1; rh++) {
			if (blockPosition.y != 0) {

                volatileNW = Instantiate(wall, transform.position + new Vector3(-blockPosition.x + 0.5f, blockPosition.y, 0.0f), Quaternion.identity, transform);
                gameObject.GetComponent<EnemyBrain>().Add2Walls(volatileNW);

                volatileNW = Instantiate(wall, transform.position + new Vector3(blockPosition.x - 0.5f, blockPosition.y, 0.0f), Quaternion.identity, transform);
                gameObject.GetComponent<EnemyBrain>().Add2Walls(volatileNW);

            }
			if (blockPosition.y == 0) {

                //volatileNE = Instantiate(obs, transform.position + new Vector3(-blockPosition.x + 0.5f, blockPosition.y, 1.0f), Quaternion.identity, transform);
                volatileNE = InstantEnemyAtPos(transform.position + new Vector3(-blockPosition.x + 0.5f, blockPosition.y, 1.0f));
                gameObject.GetComponent<EnemyBrain>().Add2Enemies(volatileNE);

                //volatileNE = Instantiate(obs, transform.position + new Vector3(blockPosition.x - 0.5f, blockPosition.y, 1.0f), Quaternion.identity, transform);
                volatileNE = InstantEnemyAtPos(transform.position + new Vector3(blockPosition.x - 0.5f, blockPosition.y, 1.0f));
                gameObject.GetComponent<EnemyBrain>().Add2Enemies(volatileNE);

            }
            blockPosition.y++;
		}

    }

    public GameObject InstantEnemyAtPos(Vector3 pos)
    {
        volatileNE = Instantiate(obs, pos, Quaternion.identity, transform);
        return volatileNE;
    }

    public Vector2 ScreenLimits()
    {
        return new Vector2(horScreenLimit, verScreenLimit);
    }
		
}

/*
*Copyright(c) 
*Davide "Lautz" Lauterio
*/