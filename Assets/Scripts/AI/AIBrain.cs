using System;
using System.Collections.Generic;
using AI.Actions;
using AI.Decisions;
using AI.States;
using Player.Abilities;
using Sirenix.OdinInspector;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AI
{
    public class AIBrain : SerializedMonoBehaviour
    {
        public List<State> states;
        public GameObject aiRoot;
        
        [ShowInInspector]private AIAction[] _actions;
        [ShowInInspector]private Decision[] _decisions;

        private State _currentState;
        public Transform target;
        
        public GameObject owner;
        public float timeInState;

        private void Awake()
        {
            _actions = aiRoot.GetComponents<AIAction>();
            _decisions = aiRoot.GetComponents<Decision>();
            owner = gameObject;
            
            foreach (var state in states)
            {
                state.Brain = this;
            }
        }

        private void Start()
        {
            foreach (var action in _actions)
            {
                action.Initialize(this);
            }

            foreach (var decision in _decisions)
            {
                decision.Initialize();
            }
        }

        public void Update()
        {
            if (_currentState == null) return;
            timeInState += Time.deltaTime;
            _currentState.PerformActions();
            _currentState.CheckDecisions();
        }

        public void TransitionToState(string stateName)
        {
            if (_currentState == null)
            {
                var exist = states.Find(x => x.stateName == stateName);
                if(exist is null) return;
                exist.EnterState();
                timeInState = 0;
            }
            else
            {
                if(_currentState.stateName==stateName) return;
                _currentState.ExitState();
                var exist = states.Find(x => x.stateName == stateName);
                if (exist is null) return;
                _currentState = exist;
                _currentState.EnterState();
                timeInState = 0;
            }
        }

        private void OnDisable()
        {
            foreach (var action in _actions)
            {
                action.Reset();
            }

            foreach (var decision in _decisions)
            {
                decision.Reset();
            }
        }

        public T GetAbility<T>() where T : Component
        {
            return GetComponent<T>();
        }
    }
}