using UnityEngine;

public class PlayAudioOnParticleDeath : MonoBehaviour
{
	public ParticleSystem _particleSystem;

	public ParticleSystem.Particle[] _particles;

	private int currentParticles;

	public AudioSource particleAudio;

	private void LateUpdate()
	{
	}
}
