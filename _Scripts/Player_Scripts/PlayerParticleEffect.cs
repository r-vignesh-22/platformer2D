using UnityEngine;

public class PlayerParticleEffect : MonoBehaviour
{
    public static PlayerParticleEffect Instance;
    [SerializeField] private ParticleSystem dust;
    [SerializeField] private ParticleSystem dead;
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        StopDust();
        StopDead();
    }

    public void PlayDust()
    {
        dust.Play();
    }
    public void PlayDead()
    {
        dead.Play();
    }
    public void StopDust()
    {
        dust.Stop();
    }
    public void StopDead()
    {
        dead.Stop();
    }
}
