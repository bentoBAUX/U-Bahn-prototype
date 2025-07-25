using UnityEngine;

[CreateAssetMenu(fileName = "CircleSpellData", menuName = "Scriptable Objects/Circle Spell Data")]
public class CircleSpellData : SpellData
{
    public float radius;

    public float executionTime;
    public float executionDelay;
    public int executionAmount;
    public float damageProExecution;
}
