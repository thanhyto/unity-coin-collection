
using UnityEngine;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxCoins;
    public int currentCoins;
    public int maxEnemies;
    public int currentEnemies;

    TextMesh scoreText;
    string HUDtext;

    void Start()
    {
        scoreText = GetComponent<TextMesh>();
        scoreText.text = HUDtext;

        HUDtext = "";

        InvokeRepeating("ScoreUpdate", 0.1f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        CancelInvoke();
    }
    void ScoreUpdate()
    {
        HUDtext = string.Format("Coins: {0:0}/{1:0}\nEnemies: {2:0}/{3:0}", currentCoins, maxCoins, currentEnemies, maxEnemies);
        if(currentCoins >= maxCoins){
            HUDtext += "\nWINNER";
        }
        scoreText.text = HUDtext;
    }
}
