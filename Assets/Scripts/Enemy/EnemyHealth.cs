using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : HealthManager
{

    public Slider healthBarSlider;
    public GameObject damageText;
    GameObject enemyHealthbarManager;
    GameObject enemyDamageTakenManager;
    Slider sliderInstance;
    CamShake critVFX;
                                                    
	override protected void Awake ()
	{
        base.Awake();
        enemyHealthbarManager = GameObject.Find("EnemyHealthbarsCanvas");
        enemyDamageTakenManager = GameObject.Find("DamageTakenCanvas");
        critVFX = GetComponent<CamShake>();
	}

    void Start()
    {
        GameObject sliderInstance = ObjectPoolsManager.GetInstance().GetObject(healthBarSlider.gameObject);
        sliderInstance.transform.position = gameObject.transform.position;
        sliderInstance.transform.rotation = Quaternion.identity;
      //  sliderInstance = Instantiate(healthBarSlider, gameObject.transform.position, Quaternion.identity) as Slider;
        sliderInstance.gameObject.transform.SetParent(enemyHealthbarManager.transform, false);
        sliderInstance.GetComponent<Healthbar>().enemy = gameObject;
        sliderInstance.gameObject.SetActive(false);
    }





    public override void TakeDamage(int damage, Vector3 hitPoint, DamageType.DamageStatus status)
	{
        if (IsDead())
            return;
        currentHealth -= damage;
        if (damage > 1)
        {
            GameObject damageTextInstance = ObjectPoolsManager.GetInstance().GetObject(damageText);
            damageTextInstance.transform.position = gameObject.transform.position;
            damageTextInstance.transform.rotation = Quaternion.identity;
            damageTextInstance.gameObject.transform.SetParent(enemyDamageTakenManager.transform, false);
            FloatingText floatingText = damageTextInstance.GetComponent<FloatingText>();
            floatingText.enemy = gameObject;
            floatingText.SetText("" + damage);
            floatingText.SetColor(DamageType.damageColors[(int)status]);
            damageTextInstance.gameObject.SetActive(true);
        }
 

        if (critVFX  && status == DamageType.DamageStatus.Critical)
        {
            critVFX.enabled = true;
        }
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
        ObjectPoolsManager.GetInstance().PoolObject(sliderInstance.gameObject);
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