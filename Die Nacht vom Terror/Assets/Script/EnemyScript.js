var EnemyHealth: int = 10;
var Spawn: GameObject;
var Gun: GameObject;
var BulletToRemove : int = 0;

function Awake()
	{
	Spawn = GameObject.Find("EnemySpawnControl");
	}

function DeductPoints(DamageAmount : int ){
	EnemyHealth -= DamageAmount;
	BulletToRemove += 1;



}

function RemoveBulletHoles()
{

	GameObject.Destroy (Spawn.GetComponent(EnemySpawn).BulletHoleList [Spawn.GetComponent(EnemySpawn).BulletHoleList.Count-1]);
	Spawn.GetComponent(EnemySpawn).BulletHoleList.RemoveAt(Spawn.GetComponent(EnemySpawn).BulletHoleList.Count-1);
	BulletToRemove -= 1;

}

function Update(){
if (EnemyHealth <= 0)
	{
	Gun.GetComponent(GunFire).score += 5;
	yield WaitForSeconds (5f);
	Destroy(gameObject);
	Spawn.GetComponent(EnemySpawn).EnemiesLeft.RemoveAt(0);


	Debug.Log("Repetition: " + Spawn.GetComponent(EnemySpawn).repetition + " Timer: " + Spawn.GetComponent(EnemySpawn).timer);

	if 
	(
		Spawn.GetComponent(EnemySpawn).EnemiesLeft.Count <= 0 && Spawn.GetComponent(EnemySpawn).timer == Spawn.GetComponent(EnemySpawn).repetition
	)

	{Spawn.GetComponent(EnemySpawn).Spawn(); }

	}

	if (BulletToRemove > 0){ RemoveBulletHoles();}

	}
