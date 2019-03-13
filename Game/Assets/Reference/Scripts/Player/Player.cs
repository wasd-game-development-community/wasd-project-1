using UnityEngine;

public class Player : MonoBehaviour
{
    public static bool IsPlaying;
    public static bool IsDead;
    public static int Score;
    public static float DistanceTravelled;

    public static Transform PlayerTransform;
    public static float Speed = 10;

    public void Start()
    {
        IsPlaying = true;
        IsDead = false;
        PlayerTransform = GetComponent<Transform>();
    }
}
