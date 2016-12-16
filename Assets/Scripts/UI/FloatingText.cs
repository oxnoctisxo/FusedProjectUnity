using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FloatingText : MonoBehaviour {
    public Animator animator;
    public GameObject enemy;
    private Text damageText;
    private Outline outline;
    private PoolAfterXSeconds dieAfter;
	void Start () {
       AnimatorClipInfo[] clipInfos = animator.GetCurrentAnimatorClipInfo(0);
     
       damageText = animator.GetComponent<Text>();
       outline = damageText.GetComponent<Outline>();
        dieAfter = gameObject.GetComponent<PoolAfterXSeconds>();
       if(!dieAfter)
         dieAfter= gameObject.AddComponent<PoolAfterXSeconds>();
       dieAfter.delay = clipInfos[0].clip.length;
	}
	
 

    public void SetText(string text)
    {
        if(!damageText)
            damageText = animator.GetComponent<Text>();
        damageText.text = text;
    }

    public void SetColor(Color color)
    {
        if (!outline)
            outline = animator.GetComponent<Outline>();
        if (!damageText)
            damageText = animator.GetComponent<Text>();
        damageText.color = color;
        if(!color.Equals(Color.white))
            outline.effectColor = Color.white;
        else
            outline.effectColor = Color.black;

    }
    void Update()
    {
        if (enemy == null)
        {
            return;
        }

        Vector3 screenPos = Camera.main.WorldToScreenPoint(enemy.transform.position);
        gameObject.transform.position = screenPos + new Vector3(0, 0, 20);
    }

    void OnEnable()
    {
        SetText("");
    }
   
}
