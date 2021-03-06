﻿import UnityEngine.UI;

var shooting = false;
var shootdelay = 0.5f;
var SpawnController: GameObject;
public var Player: GameObject;
var Bullets_Text: Text;
var Round_Text: Text;
var Points_Text:Text;
var Health_Text:Text;

var gun: GameObject;
var MuzzleShoot : GameObject;
var Reload : GameObject;

var Max_ammo: int = 13;
var  ammo: int = 13;

var score: int = 0;

function Awake()
{
ammo = Max_ammo;
Bullets_Text.text = " Munición: "+ ammo;


Round_Text.text = " Ronda: " + SpawnController.GetComponent(EnemySpawn).ronda;
Points_Text.text = "Puntuación: " + score;
Health_Text.text = "Salud: "  +  Player.GetComponent(UnityStandardAssets.Characters.FirstPerson.FirstPersonController).PlayerHealth + "/" +
Player.GetComponent(UnityStandardAssets.Characters.FirstPerson.FirstPersonController).MaxPlayerHealth;
}

function Dispara()
{
var gunsound : AudioSource = GetComponent.<AudioSource>();
shooting = true;
	gunsound.Play();
	GetComponent.<Animation>().Play("gunshot");
	MuzzleShoot.SetActive(true);
	MuzzleShoot.GetComponent(Animation).Play("MuzzleAnimation");

	GameObject.Find("M9").GetComponent(HandGunDamage).Damage();
	ammo -=1;
	if (ammo <= 0){ammo = Max_ammo;GetComponent.<Animation>().Play("gunreload");Reload.SetActive(true);yield WaitForSeconds (1f);Reload.SetActive(false);}


	yield WaitForSeconds (shootdelay);
	shooting = false;
	MuzzleShoot.SetActive(false);






}



function Update()
{

Bullets_Text.text = " Munición: "+ ammo;

Round_Text.text = " Ronda: " + SpawnController.GetComponent(EnemySpawn).ronda;
Points_Text.text = "Puntuación: " + score;
Health_Text.text = "Salud: "  +  Player.GetComponent(UnityStandardAssets.Characters.FirstPerson.FirstPersonController).PlayerHealth + "/" +
Player.GetComponent(UnityStandardAssets.Characters.FirstPerson.FirstPersonController).MaxPlayerHealth;

if (Input.GetButtonDown("Fire1") && shooting == false)
{

Dispara();
SpawnController.GetComponent(EnemySpawn).BulletMark(gun.GetComponent(HandGunDamage).Shot.point.x,gun.GetComponent(HandGunDamage).Shot.point.y,gun.GetComponent(HandGunDamage).Shot.point.z);


	}

	}

