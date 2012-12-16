using UnityEngine;
using System.Collections;

public class Punch : MonoBehaviour {
	
	public GameObject laserPrefab;
	public GameObject laserHitPrefab;
	float laserOffsetX = 0.4f;
	float laserOffsetY = 0.1f;
	
	public AudioClip[] shootSounds;
	
	float range = 20.0f;
	
	public LayerMask laserMask;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeScale==0) {
			return;
		}
		
		if( Input.GetButtonDown("Fire1") ) {
			
			AudioSource.PlayClipAtPoint(shootSounds[0], transform.position, .25f);
			
			Vector3 dir = Camera.main.transform.forward;
			RaycastHit hitInfo;
			
			//int layerMask = (1 << 11) | Physics.kDefaultRaycastLayers;
			
			if( Physics.Raycast( Camera.main.transform.position, dir, out hitInfo, range, laserMask.value ) ) {
				Transform victim = hitInfo.collider.transform;
				
				Destroyable dest = victim.GetComponent<Destroyable>();
				while(dest == null && victim.parent != null) {
					victim = victim.parent;
					dest = victim.GetComponent<Destroyable>();
				}
				
				if(dest != null) {
					dest.DestroyMe();
					Score.AddMult();
				}
				
				Missile missile = victim.GetComponent<Missile>();
				if(missile != null) {
					missile.Explode();
					Score.AddPoints(10000);
				}
				
				SpawnLaser( hitInfo.point );
				Instantiate(laserHitPrefab, hitInfo.point, Quaternion.identity);
			}
			else {
				SpawnLaser( Camera.main.transform.position + Camera.main.transform.forward * range );
			}
		}
	}
	
	void SpawnLaser(Vector3 focalPoint) {
		Vector3 laserPosition = Camera.main.transform.position + Camera.main.transform.right * laserOffsetX + Camera.main.transform.up * laserOffsetY;
		Vector3 laserDirection = focalPoint + Camera.main.transform.right * laserOffsetX/2 - laserPosition;
		Quaternion targetRotation = Quaternion.LookRotation(laserDirection);
		
		GameObject l = (GameObject)Instantiate(laserPrefab, laserPosition, targetRotation);
		Vector3 scale = new Vector3( 1, 1, laserDirection.magnitude );
		l.transform.localScale = scale;
		l.transform.parent = Camera.main.transform;

		laserPosition = Camera.main.transform.position + Camera.main.transform.right * -laserOffsetX + Camera.main.transform.up * laserOffsetY;
		laserDirection = focalPoint + Camera.main.transform.right * -laserOffsetX/2 - laserPosition;
		targetRotation = Quaternion.LookRotation(laserDirection);
		
		l = (GameObject)Instantiate(laserPrefab, laserPosition, targetRotation);
		scale = new Vector3( 1, 1, laserDirection.magnitude );
		l.transform.localScale = scale;
		l.transform.parent = Camera.main.transform;

	}
	
	
}
