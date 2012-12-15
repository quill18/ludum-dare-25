using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {
	
	float speed = 12f;
	float turnRate = 60f;
	Transform playerTransform;
	float detonateDistance = 1f;
	float lifeSpan = 5f;
	public GameObject explosionPrefab;
	float explosionRadius = 4f;
	float explosionStrength = 1000f;
	float damageToPlayer = 20f;
	
	// Use this for initialization
	void Start () {
		playerTransform = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		lifeSpan -= Time.deltaTime;
		if(lifeSpan <= 0) {
			Explode();
		}
		
		Quaternion targetRotation = Quaternion.LookRotation( playerTransform.position + new Vector3(0, .75f, 0) - transform.position );
		transform.rotation = Quaternion.RotateTowards( transform.rotation, targetRotation, turnRate * Time.deltaTime);
		
		transform.Translate( Vector3.forward * speed * Time.deltaTime );
		
		CheckDistanceToPlayer();
		

	}
	
	void OnCollisionEnter( Collision collision ) {
		Explode();
	}
	
	void CheckDistanceToPlayer() {
		float distance = (playerTransform.position + new Vector3(0, .75f, 0) - transform.position).magnitude;
		
		if(distance < detonateDistance) {
			Explode();
		}
	}
	
	void Explode() {
		// Ka-Blooey!
		if(explosionPrefab != null) {
			Instantiate(explosionPrefab, collider.bounds.center, Quaternion.identity);
		}
		
		// Check for destroyable objects inside our explosion radius
		Collider[] colliders = Physics.OverlapSphere( collider.bounds.center, explosionRadius );
		foreach( Collider col in colliders ) {
			Destroyable dest = col.GetComponent<Destroyable>();
			if(dest != null) {
				dest.DestroyMe();
			}
			
			Health health = col.GetComponent<Health>();
			if(health != null) {
				float falloff = 1f - (col.bounds.center - collider.bounds.center).sqrMagnitude / (explosionRadius*explosionRadius);
				health.TakeDamage(damageToPlayer * falloff);
			}
			
		}
		
		// Apply explosive physics to debris
		colliders = Physics.OverlapSphere( collider.bounds.center, explosionRadius * 2, 1 << LayerMask.NameToLayer("Debris") );
		foreach( Collider col in colliders ) {
			if(col.rigidbody != null) {
				col.rigidbody.AddExplosionForce(explosionStrength, collider.bounds.center, explosionRadius * 2);
			}
		}
		
		Destroy (gameObject);
	}
}
