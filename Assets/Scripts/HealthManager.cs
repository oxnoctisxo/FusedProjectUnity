using UnityEngine;
using System.Collections;

public  class HealthManager : MonoBehaviour
{
 
	public int initHealth;
    private int defaultInitHealth = 100;
	public int currentHealth;
    public ParticleSystem hitParticles; 
   //  float sinkSpeed = 2.5f;
	public EventsManager eventsManager;

         


	virtual protected void Awake() {
		if (!eventsManager) {
			eventsManager = GetComponentInParent<EventsManager> ();
		}
        if (initHealth == 0)
            initHealth = defaultInitHealth;
        if (hitParticles == null)
            hitParticles = GetComponentInChildren<ParticleSystem>();
		currentHealth = initHealth;

	}

    virtual public void TakeDamage(int damage, Vector3 hitPoint)
    {
        if (IsDead())
            return;
        currentHealth -= damage;
        if (hitParticles)
        {
            hitParticles.transform.position = hitPoint;
            hitParticles.Play();
        }
        if (IsDead())
        {
			Die();
		}
	}
	public void Heal(int healAmount) {
        currentHealth = Mathf.Min(currentHealth + healAmount, initHealth);
	}

    public void RaiseInitHealth(int newInitHealth)
    {
        int oldInitHealth = initHealth;
        initHealth = newInitHealth;
        if (currentHealth >= oldInitHealth)
            currentHealth = initHealth;
    }
    public bool IsDead()
    {
        return currentHealth <= 0;
    }

    virtual protected void Die()
    {
		eventsManager.Die ();
	}

    virtual protected void OnEnable()
    {
        currentHealth = initHealth;
	}

}
