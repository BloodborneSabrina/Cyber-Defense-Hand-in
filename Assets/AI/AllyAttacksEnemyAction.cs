using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using static UnityEngine.GraphicsBuffer;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Ally attacks Enemy", story: "[Agent] attacks [Enemy]", category: "Action", id: "8a04824bb4c95619ccf549e4a2aa61a1")]
public partial class AllyAttacksEnemyAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;
    [SerializeReference] public BlackboardVariable<GameObject> Enemy;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {


        if (Agent.Value == null || Enemy.Value == null)
        {
            Debug.LogWarning("Agent or Target is null in AttackAllyAction.");
            return Status.Failure;
        }

        // Check if the agent can attack the target
        // if the distance is small enough and the target is an ally, attack the player. Then activate a cooldown preventing further attacks.
        float distance = Vector3.Distance(Agent.Value.transform.position, Enemy.Value.transform.position);
        var attackComponent = Agent.Value.GetComponent<Ally>(); // Assuming Agent has an Ally component that handles attacks.
        if (distance > 2.0f) // Assuming 2.0f is the attack range *if statement added by copilot.
        {
            //Debug.Log("Target is out of range for attack.");
            return Status.Failure;
        }
        else
        {
            // activate hit script on the target.
            attackComponent.AttackEnemy(Enemy.Value, 1); // Assuming Agent has an AttackEnemy method that takes a GameObject and damage amount.

            // set cooldown.

            return Status.Success;
        }

        
    }

    protected override void OnEnd()
    {
    }
}

