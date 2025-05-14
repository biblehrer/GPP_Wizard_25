using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Test")]
public class classT : ScriptableObject
{
    [SerializeField]
    private int score;
    public int health;
}
