using UnityEngine;

public class EscapingVehicleController : VehicleBehaviourController
{
    private Vector2 escapeDirection;
    //[SerializeField]private EnemyEscapeData data;
    public override void OnStartBehaviour()
    {
        ChooseEscapeDirection();
    }

    private void ChooseEscapeDirection() // Mock for now
    {
        escapeDirection = Vector2.right;
    }

    public override void OnFixedUpdateBehave()
    {
        transform.Translate(escapeDirection * Controller.Speed * Runner.DeltaTime);
    }

    public override void OnEndBehaviour()
    {
        Debug.LogError("Escape state is final. It cannot be ended");
    }
}
