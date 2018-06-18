using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemySpawn : MonoBehaviour {

	public float time = 0.0f;
	public bool busy = false;
	public int timer = 0;
	public int repetition = 0; //the amount of times the spawn function is called in each level.

	public int ronda = 0;
	public float spawnDelay = 0f;

    public GameObject EnemyModel;
	public GameObject Gun;

    public List<GameObject> EnemiesLeft = new List<GameObject>();
    public List<Vector3> positions = new List<Vector3>();

    private GameObject enemy;

    public GameObject bulletHole;





	private GameObject BulletHoleInstance;

	public List<GameObject> BulletHoleList = new List<GameObject>();






    


    
	
	// Update is called once per frame
	void Update () {



		if (time >= spawnDelay) 
		{
			time = 0.0f;
		}
			

		if (ronda == 0) {
			positions.Add (new Vector3 (70, 2, 8)); //70 is the one that determines distance from door.

			positions.Add (new Vector3 (41, 2, -30)); //-30 is the one that determines distance from door.

			 positions.Add (new Vector3 (-4, 2, -30)); //-30 is the one that determines distance from door.

			positions.Add (new Vector3 (11, 2, 30)); //30 is the one that determines distance from door.

			positions.Add (new Vector3 (18, 2, -20)); //-20 is the one that determines distance from door.

			positions.Add (new Vector3 (0, 2, 45)); //0 is the one that determines distance from door.

			positions.Add (new Vector3 (-21, 2, 70)); //80 is the one that determines distance from door.

			Spawn();

			} 

		if (timer >= repetition) {CancelInvoke ();}
		
		
	}

	public void Spawn()
	{
		timer = 0;
		ronda += 1;
		repetition = ronda * 5;
		Debug.LogWarning ("repetition" + repetition);
        InvokeRepeating ("SpawnHere", spawnDelay, spawnDelay);
		}
		

		
	


	private void SpawnHere()
	{
		enemy = Instantiate (EnemyModel, positions [Random.Range (0, positions.Count)], Quaternion.identity) as GameObject;
		EnemiesLeft.Add (enemy);
		enemy.SetActive (true);
		timer += 1;
	}


	public void BulletMark(float x, float y, float z)
	{
		BulletHoleInstance = Instantiate (bulletHole, new Vector3 (x, y, z), Gun.transform.rotation);
		BulletHoleList.Add (BulletHoleInstance);
		if (BulletHoleList.Count >= 5) {GameObject.Destroy (BulletHoleList [0]);BulletHoleList.RemoveAt (0);}

	}

	public void GameOver() // Has to be improved with visual death effects
	{
		SceneManager.LoadScene(0);
	}
}


