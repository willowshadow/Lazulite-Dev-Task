using System;
using System.Collections.Generic;
using AI.Actions;
using AI.Decisions;

namespace AI.States
{
    [Serializable]
    public class State
    {
        public string stateName;
        
        private AIBrain _brain;
        
        public List<AIAction> actions;
        public List<Transition> transitions;
        
        public AIBrain Brain
        {
            get => _brain;
            set => _brain = value;
        }

        public void EnterState()
        {
            foreach (var aiAction in actions)
            {
                aiAction.Initialize(_brain);
            }

            foreach (var transition in transitions)
            {
                if (transition.aiDecision is not null)
                {
                    transition.aiDecision.Initialize(_brain);
                }
            }
        }

        public void ExitState()
        {
            foreach (var aiAction in actions)
            {
                aiAction.Reset();
            }

            foreach (var transition in transitions)
            {
                if (transition.aiDecision is not null)
                {
                    transition.aiDecision.Reset();
                }
            }
        }

        public void PerformActions()
        {
            foreach (var aiAction in actions)
            {
                aiAction.DoActions();
            }
        }

        public void CheckDecisions()
        {
            foreach (var transition in transitions)
            {
                if (transition.aiDecision is not null)
                {
                    if (transition.aiDecision.DoDecide())
                    {
                        _brain.TransitionToState(transition.trueStateName);
                    }
                    else
                    {
                        _brain.TransitionToState(transition.falseStateName);
                    }
                }
            }
        }
        
    }
    [Serializable]
    public class Transition
    {
        public Decision aiDecision;
        public string trueStateName, falseStateName;
    }
}