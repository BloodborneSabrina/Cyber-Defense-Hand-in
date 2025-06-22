using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Attack Ally", story: "[Agent] Attacks [Target]", category: "Action", id: "8284aaac04b71bc74d623187915dc287")]
public partial class AttackAllyAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;
    [SerializeReference] public BlackboardVariable<GameObject> Target;

    private float lastAttackTime = 0f;
    private float attackCooldown = 0.8f;
    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (Agent.Value == null || Target.Value == null)
        {
            Debug.LogWarning("Agent or Target is null in AttackAllyAction.");
            return Status.Failure;
        }

        // Check if the agent can attack the target
        // if the distance is small enough and the target is an ally, attack the player. Then activate a cooldown preventing further attacks.
        float distance = Vector3.Distance(Agent.Value.transform.position, Target.Value.transform.position);
        if (distance > 3.0f) // Assuming 2.0f is the attack range *if statement added by copilot.
        {
            //Debug.Log("Target is out of range for attack.");
            return Status.Failure;
        }
        else
        {
            // activate hit script on the target.
            //Debug.Log("attack ally");
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                Animator animator = Agent.Value.GetComponent<Animator>();
                animator.SetTrigger("attack"); // Assuming the Agent has an Animator component with an "Attack" trigger.

                Target.Value.GetComponent<Ally>().TakeDamage(1); // Assuming Agent has an AttackEnemy method that takes a GameObject and damage amount.
                                                                 // trigger animation event.
                lastAttackTime = Time.time;
                return Status.Success;
                
            }
            else
            {
                //Debug.Log("Attack on cooldown.");
                return Status.Failure; // Still in cooldown, so return Running status.
            }
        }

        
    }

    protected override void OnEnd()
    {
    }
}

