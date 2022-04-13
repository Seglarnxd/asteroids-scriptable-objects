using System;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace.ScriptableEvents
{
    [CreateAssetMenu(fileName = "new ScriptableEventFloat", menuName = "ScriptableObjects/ScriptableEvent-Float", order = 0)]
    public class ScriptableEventFloat : ScriptableEvent<float>
    {
           
    }
    [Serializable]
    public class UnityEventFloat : UnityEvent<float>
    {
        
    }
}
