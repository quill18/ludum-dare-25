using UnityEngine;
using System.Collections;

public class BumpSounds : MonoBehaviour {
	//public AudioClip bumpSound;

	void OnCollisionEnter(Collision collision) {
		if(audio && !audio.isPlaying) {
			audio.volume = Mathf.Min(collision.impactForceSum.magnitude, 1f);
			if(audio.volume > 0.1) {
				audio.Play();
			}
			//AudioSource.PlayClipAtPoint(bumpSound, transform.position, Mathf.Min(collision.impactForceSum.magnitude, 1f) );
		}

	}
}
