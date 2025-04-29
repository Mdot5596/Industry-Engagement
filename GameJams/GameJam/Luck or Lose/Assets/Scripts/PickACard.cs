using UnityEngine;

public class PickACard : MonoBehaviour
{
    public void PickRed()
    {
        bool isRed = Random.value < 0.5f;
        GameManager.Instance.HandleResult(isRed);
    }

    public void PickBlack()
    {
        bool isRed = Random.value < 0.5f;
        GameManager.Instance.HandleResult(!isRed);
    }
}
