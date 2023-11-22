using System;
using System.Collections.Generic;
using Player.Controllers;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace AI.Decisions
{
    public class AIDecisionDetectTarget : Decision
    {
        [SerializeField] private float targetCheckFrequency;
        [SerializeField] private float lastTargetCheckTimestamp;
        [SerializeField] private float radius;
        [SerializeField] private LayerMask targetLayerMask;
        private Collider[] _hits;
        private bool _lastValue;

        public override bool DoDecide()
        {
            if (Time.time - lastTargetCheckTimestamp < targetCheckFrequency)
            {
                return _lastValue;
            }

            lastTargetCheckTimestamp = Time.time;
            
            _hits = Physics.OverlapSphere(transform.position, radius,targetLayerMask);
            if (_hits.Length == 0)
            {
                Brain.target = null;
                _lastValue = false;
                return false;
            }
            
            for (int i = 0; i < _hits.Length; i++)
            {
                if (_hits[i] == null)
                {
                    continue;
                }
                
                if ((_hits[i].gameObject == Brain.owner) || (_hits[i].transform.IsChildOf(Brain.transform)))
                {
                    continue;
                }

                if (_hits[i].TryGetComponent(out PlayerController playerController))
                {
                    Brain.target = _hits[i].transform;
                    return _lastValue=true;
                }
                
                return _lastValue=false;
            }
            
            _lastValue = false;
            return false;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            #if UNITY_EDITOR
            Handles.DrawWireDisc(transform.position, transform.up, radius);
            #endif
        }
    }
}