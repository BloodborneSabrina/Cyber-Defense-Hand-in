using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "if ally exists", story: "[Ally] exists", category: "Conditions", id: "bfe34b51daebb2448ce4319c3b175833")]
public partial class IfAllyExistsCondition : Condition
{
    [SerializeReference] public BlackboardVariable<GameObject> Ally;

    public override bool IsTrue()
    {

        GameObject ally = GameObject.FindWithTag("Allies");

        if(ally != null)
        {
            //Debug.Log("ally exists");
            Ally.Value = ally;
            return true; // Ally exists
        }
        else
        {
            Ally.Value = null;
            return false; // Ally does not exist
        }

    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
