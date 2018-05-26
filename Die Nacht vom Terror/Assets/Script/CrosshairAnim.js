var Crosshair_Up : GameObject;
var Crosshair_Down : GameObject;
var Crosshair_Left : GameObject;
var Crosshair_Right : GameObject;
function Update()
{
	if(Input.GetButtonDown("Fire1")){
		Crosshair_Up.GetComponent("Animator").enabled=true;
		Crosshair_Down.GetComponent("Animator").enabled=true;
		Crosshair_Left.GetComponent("Animator").enabled=true;
		Crosshair_Right.GetComponent("Animator").enabled=true;

		
	}
}
function WaitingAnim(){
	yield WaitForSeconds(0.1);
	Crosshair_Up.GetComponent("Animator").enabled=false;
	Crosshair_Down.GetComponent("Animator").enabled=false;
	Crosshair_Left.GetComponent("Animator").enabled=false;
	Crosshair_Right.GetComponent("Animator").enabled=false;
}