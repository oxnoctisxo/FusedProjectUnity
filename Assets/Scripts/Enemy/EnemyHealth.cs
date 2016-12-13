using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : HealthManager
{

    public Slider healthBarSlider;
    GameObject enemyHealthbarManager;
    Slider sliderInstance;
                                                    
	override protected void Awake ()
	{
        base.Awake();
        enemyHealthbarManager = GameObject.Find("EnemyHealthbarsCanvas");
	}

    void Start()
    {
        sliderInstance = Instantiate(healthBarSlider, gameObject.transform.position, Quaternion.identity) as Slider;
        sliderInstance.gameObject.transform.SetParent(enemyHealthbarManager.transform, false);
        sliderInstance.GetComponent<Healthbar>().enemy = gameObject;
        sliderInstance.gameObject.SetActive(false);
    }





    public override  void TakeDamage(int damage ,Vector3 hitPoint)
	{
        if (IsDead())
            return;
        currentHealth -= damage;
        if (hitParticles)
        {
            hitParticles.transform.position = hitPoint;
            hitParticles.Play();
        }

        if (currentHealth <= initHealth)
        {
            sliderInstance.gameObject.SetActive(true);
        }
        int sliderValue = (int)Mathf.Round(((float)currentHealth / (float)initHealth) * 100);
        sliderInstance.value = sliderValue;

        if (IsDead())
        {
            Die();
        }
	}

    override protected void Die()
    {
        Destroy(sliderInstance.gameObject);
        base.Die();
    }
    override protected void OnEnable()
    {
        base.OnEnable();
        sliderInstance = Instantiate(healthBarSlider, gameObject.transform.position, Quaternion.identity) as Slider;
        sliderInstance.gameObject.transform.SetParent(enemyHealthbarManager.transform, false);
        sliderInstance.GetComponent<Healthbar>().enemy = gameObject;
        sliderInstance.gameObject.SetActive(false);
       // int sliderValue = (int)Mathf.Round(((float)currentHealth / (float)initHealth) * 100);
        //sliderInstance.value = sliderValue;
    }

    //void Death ()
    //{

    //    StartCoroutine(StartSinking());
    //    Destroy(sliderInstance.gameObject);

    //}


    //IEnumerator StartSinking ()
    //{
    //    yield return new WaitForSeconds(2);
    //    deathParticles.Play();
    //    Destroy (gameObject, 2f);
    //}
}