using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour {
public GameObject ThePlayer;
    public float TargetDistance;
    public float AllowedRange = 10;
    public GameObject TheEnemy;
    public float EnemySpeed;
    public int AttackTrigger=0;
    public RaycastHit Shot;
	public GameObject SonidoDaño;
	public bool couroutineStarted=false;

	public Image damageImage;


    void Update() {
		
		transform.LookAt (new Vector3(ThePlayer.transform.position.x, 1.5f,ThePlayer.transform.position.z));

        if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), out Shot)) {
            TargetDistance = Shot.distance;
            if (TargetDistance < AllowedRange) {
				
                EnemySpeed = 0.05f;
                if (AttackTrigger == 0) {
                    TheEnemy.GetComponent<Animation> ().Play ("Walking");
                    transform.position = Vector3.MoveTowards (transform.position, ThePlayer.transform.position, EnemySpeed);
					//transform.position = new Vector3 (transform.position.x, 2, transform.position.z);
                }
            } 
        }

		//Touch the player to hurt him.

		if (Vector3.Distance (this.transform.position, ThePlayer.transform.position) < 2.5) {
			ThePlayer.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController> ().PlayerHealth -= 1;
			SonidoDaño.SetActive (true);
			damageImage.color = new Color (damageImage.color.r, damageImage.color.g, damageImage.color.b, 0.5f);
			if (!couroutineStarted) {
				StartCoroutine (UsingYield (0.365f));
			}
			}


		}
	IEnumerator UsingYield(float second){
		couroutineStarted = true;
		yield return new WaitForSeconds (second);
		SonidoDaño.SetActive (false);
		damageImage.color = new Color (damageImage.color.r, damageImage.color.g, damageImage.color.b, 0.0f);
		couroutineStarted = false;
	}
		/*Enemy = this.GetComponent<EnemyScript> ();
		if (Enemy.EnemyHealth<= 0) {
			TheEnemy.GetComponent<Animation> ().Play ("Dying");}*/
			

        
    }
	//prueba commit

