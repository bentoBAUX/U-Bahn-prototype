#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyCombatBehaviourSystem))]
public class EnemyCombatBehaviourSystemEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var controller = (EnemyCombatBehaviourSystem)target;

        EditorGUI.BeginChangeCheck();

        controller.useRidingController = EditorGUILayout.Toggle("Ride Controller", controller.useRidingController);
        controller.useAttackingMeleeController = EditorGUILayout.Toggle("Attack Melee Controller", controller.useAttackingMeleeController);
        controller.useAttackingRangedController = EditorGUILayout.Toggle("Attack Ranged Controller", controller.useAttackingRangedController);
        controller.useEscapingController = EditorGUILayout.Toggle("Escape Controller", controller.useEscapingController);
        controller.useHauntingController = EditorGUILayout.Toggle("Haunt Controller", controller.useHauntingController);
        controller.useStealingController = EditorGUILayout.Toggle("Steal Controller", controller.useStealingController);

        if (EditorGUI.EndChangeCheck())
        {
            ManageComponent<RidingBehaviourController>(controller, controller.useRidingController, out controller.ridingBehaviourController);
            ManageComponent<AttackingMeleeBehaviourController>(controller, controller.useAttackingMeleeController, out controller.attackingMeleeBehaviourController);
            ManageComponent<AttackingRangedBehaviourController>(controller, controller.useAttackingRangedController, out controller.attackingRangedBehaviourController);
            ManageComponent<EscapingBehaviourController>(controller, controller.useEscapingController, out controller.escapingBehaviourController);
            ManageComponent<HauntingBehaviourController>(controller, controller.useHauntingController, out controller.hauntingBehaviourController);
            ManageComponent<StealingBehaviourController>(controller, controller.useStealingController, out controller.stealingBehaviourController);

            EditorUtility.SetDirty(controller);
        }

        DrawDefaultInspector(); // optional
    }

    private void ManageComponent<T>(EnemyCombatBehaviourSystem target, bool enabled, out T controller) where T : CombatBehaviourController
    {
        controller = target.GetComponent<T>();
        if (enabled)
        {
            if (controller == null)
            {
                controller = target.gameObject.AddComponent<T>();
                Debug.Log(target);
                controller.Controller = target;
                controller.enabled = true;
            }
        }
        else
        {
            if (controller != null)
            {
                DestroyImmediate(controller);
                controller = null;
            }
        }
    }
}
#endif