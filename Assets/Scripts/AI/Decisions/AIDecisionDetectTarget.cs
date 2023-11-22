using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace AI.Decisions
{
    public class AIDecisionDetectTarget : Decision
    {
        [SerializeField] private float targetCheckFrequency;
        [SerializeField] private float lastTargetCheckTimestamp;
        
        private bool _lastValue;
        [SerializeField] private float radius;
        [SerializeField] private LayerMask targetLayerMask;
        private Collider[] _hits;

        public override bool DoDecide()
        {
            if (Time.time - lastTargetCheckTimestamp < targetCheckFrequency)
            {
                return _lastValue;
            }

            lastTargetCheckTimestamp = Time.time;
            
            int targetsFound = Physics.OverlapSphereNonAlloc(transform.position, radius, _hits, targetLayerMask);

            if (targetsFound == 0)
            {
                _lastValue = false;
                return false;
            }
            
            for (int i = 0; i < targetsFound; i++)
            {
                if (_hits[i] == null)
                {
                    continue;
                }
                
                if ((_hits[i].gameObject == Brain.owner) || (_hits[i].transform.IsChildOf(transform)))
                {
                    continue;
                }    
                Brain.target = _hits[i].transform;
                return _lastValue=true;
            }
            
            _lastValue = false;
            return false;
        }
    }
}