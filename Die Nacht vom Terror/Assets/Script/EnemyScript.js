var EnemyHealth: int = 10;
var Spawn: GameObject;
var Gun: GameObject;

function Awake()
	{
	Spawn = GameObject.Find("EnemySpawnControl");
	}
function DeductPoints(DamageAmount : int ){
	EnemyHealth -= DamageAmount;

}
function Update(){
if (EnemyHealth <= 0)
	{
	Destroy(gameObject);
	Spawn.GetComponent(EnemySpawn).EnemiesLeft.RemoveAt(0);
	Gun.GetComponent(GunFire).score += 5;
	if (Spawn.GetComponent(EnemySpawn).EnemiesLeft.Count <= 0){Spawn.GetComponent(EnemySpawn).Spawn();}
	}
	}
 	 
