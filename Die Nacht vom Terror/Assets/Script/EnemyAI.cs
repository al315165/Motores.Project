using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
public GameObject ThePlayer;
    public float TargetDistance;
    public float AllowedRange = 10;
    public GameObject TheEnemy;
    public float EnemySpeed;
    public int AttackTrigger=0;
    public RaycastHit Shot;

    void Update() {
		transform.LookAt (new Vector3(ThePlayer.transform.position.x, 1.5f,ThePlayer.transform.position.z));

        if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), out Shot)) {
            TargetDistance = Shot.distance;
            if (TargetDistance < AllowedRange) {
				
                EnemySpeed = 0.02f;
                if (AttackTrigger == 0) {
                    //TheEnemy.GetComponent<Animation> ().Play ("Walking");
                    transform.position = Vector3.MoveTowards (transform.position, ThePlayer.transform.position, EnemySpeed);
					//transform.position = new Vector3 (transform.position.x, 2, transform.position.z);
                }
            } 
        }

		//Touch the player to hurt him.

		if (Vector3.Distance(this.transform.position,ThePlayer.transform.position) < 2.5) 
		{
			ThePlayer.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().PlayerHealth -= 1;
		}

        
    }
	//prueba commit

}