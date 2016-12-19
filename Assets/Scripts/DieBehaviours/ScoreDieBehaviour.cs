using UnityEngine;
using System.Collections;

public class ScoreDieBehaviour : AbstractAsyncDieBehaviour {


	public int score = 10 ;
    [SerializeField]
    private ScoreManager scoreManager;
    [SerializeField]
    private WaveManager waveManager;

    void Awake()
    {
        scoreManager = FindObjectOfType(typeof(ScoreManager)) as ScoreManager;
        waveManager = GameObject.Find("WaveManager").GetComponent<WaveManager>();
    }
	public override void Die (GameObject deadObject)
	{
        scoreManager.AddScore(score);
        if(score > 0)
            waveManager.DecrementEnemiesAlive();
        isFinished = true;
       
    }
}
