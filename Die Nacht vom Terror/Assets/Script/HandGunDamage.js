	var DamageAmount : int = 5;
	var TargetDistance: float;
	var AllowedRange : float=30;
	var Shot: RaycastHit;


	function Damage()
	{

		if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), Shot))
		{
		TargetDistance=Shot.distance;
			if (TargetDistance<AllowedRange){
			Shot.transform.SendMessage("DeductPoints",DamageAmount);
			}
		}
	
	}