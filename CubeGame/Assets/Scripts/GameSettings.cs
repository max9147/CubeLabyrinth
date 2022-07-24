using UnityEngine;

[CreateAssetMenu]
public class GameSettings : ScriptableObject
{
    public float CubeSpeed;
    public float ShieldTime;
    [Range(5, 30)]
    public int TrapsAmount;
}