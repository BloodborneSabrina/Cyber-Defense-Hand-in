using System;
using Unity.Behavior;
using UnityEngine;
using Unity.Properties;

#if UNITY_EDITOR
[CreateAssetMenu(menuName = "Behavior/Event Channels/Start Combat")]
#endif
[Serializable, GeneratePropertyBag]
[EventChannelDescription(name: "Start Combat", message: "[Agent] should fight [ally]", category: "Events", id: "98a0483f52c2db047c7c507fd1aca74b")]
public sealed partial class StartCombat : EventChannel<GameObject, GameObject> { }

