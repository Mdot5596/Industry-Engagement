using UnityEngine;

public class CoinFlip : MonoBehaviour
{
    public void FlipCoin()
    {
        bool result = Random.value < 0.5f;  // true = win, false = lose
        GameManager.Instance.HandleResult(result);
    }
}
