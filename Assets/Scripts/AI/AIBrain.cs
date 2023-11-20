using System;
using System.Collections.Generic;
using AI.Actions;
using AI.Decisions;
using AI.States;
using Sirenix.OdinInspector;
using UnityEngine;

namespace AI
{
    public class AIBrain : SerializedMonoBehaviour
    {
        public List<State> states;
        public GameObject aiRoot;
        
        private AIAction[] _actions;
        private Decision[] _decisions;

        private State _currentState;
        private void Awake()
        {
            _actions = aiRoot.GetComponents<AIAction>();
            _decisions = aiRoot.GetComponents<Decision>();
            
            foreach (var state in states)
            {
                state.Brain = this;
            }
        }

        private void Start()
        {
            foreach (var action in _actions)
            {
                action.Initialize();
            }

            foreach (var decision in _decisions)
            {
                decision.Initialize();
            }
        }

        public void Update()
        {
            if (_currentState == null) return;
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
            }
            else
            {
                if(_currentState.stateName==stateName) return;
                _currentState.ExitState();
                var exist = states.Find(x => x.stateName == stateName);
                if (exist is not null)
                {
                    _currentState = exist;
                    _currentState.EnterState();
                }
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
    }
}