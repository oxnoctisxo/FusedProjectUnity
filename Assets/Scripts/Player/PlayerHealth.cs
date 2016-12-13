using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PlayerHealth : HealthManager
{


    public Slider healthSlider;

    public Text healthText;


    void Update()
    {
        if (currentHealth <= initHealth / 3)
        {
            var fill = (healthSlider as UnityEngine.UI.Slider).GetComponentsInChildren<UnityEngine.UI.Image>().FirstOrDefault(t => t.name == "Fill");
            fill.color = Color.Lerp(Color.red, fill.color, 0.5f);

        }
    }



}
