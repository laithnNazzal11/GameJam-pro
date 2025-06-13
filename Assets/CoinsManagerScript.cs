using UnityEngine;
using UnityEngine.UI;

public class ScoreManagerScript : MonoBehaviour
{
    public int coinCount;
    public Text coinText;

    private void Update()
    {
        if (coinText != null)
            coinText.text = coinCount.ToString();
    }

    //public void AddCoin()
    //{
    //    coinCount++;
    //}
}
