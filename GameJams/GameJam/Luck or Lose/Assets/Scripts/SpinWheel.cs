using UnityEngine;

public class SpinWheel : MonoBehaviour
{
    public void SpinRed()
    {
        bool landedRed = Random.value < 0.5f;
        GameManager.Instance.HandleResult(landedRed);
    }

    public void SpinBlack()
    {
        bool landedRed = Random.value < 0.5f;
        GameManager.Instance.HandleResult(!landedRed);
    }
}
