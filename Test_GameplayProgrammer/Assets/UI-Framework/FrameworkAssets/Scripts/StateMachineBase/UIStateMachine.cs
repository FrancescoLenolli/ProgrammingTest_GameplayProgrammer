﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UIFramework.StateMachine
{
    public class UIStateMachine : MonoBehaviour
    {
        [SerializeField]
        private UIRoot root = null;
        [SerializeField]
        private UIState startingState = null;

        private UIState currentState;
        private List<UIState> states = new List<UIState>();
        private Type lastType = null;
        private bool statesPrepared = false;

        public UIRoot Root { get => root; set => root = value; }
        public UIState CurrentState { get => currentState; }
        public Type CurrentType { get => currentState.GetType(); }
        public Type StartingType { get => startingState.GetType(); }

        private void Start()
        {
            FirstStart();
        }

        private void Update()
        {
            if (currentState != null)
            {
                currentState.UpdateState();
            }
        }

        public bool IsCurrentState(Type type)
        {
            return type == CurrentType;
        }

        /// <summary>
        /// Initialise the Machine's States starting values.
        /// </summary>
        public void FirstStart()
        {
            if (!statesPrepared)
            {
                states = GetComponents<UIState>().ToList();
                states.ForEach(state => state.PrepareState(this));
                statesPrepared = true;
            }

            if (startingState)
                ChangeState(startingState.GetType());
        }

        public void BackToLastState()
        {
            ChangeState(lastType);
        }

        public void ChangeState(Type stateType)
        {
            if (!statesPrepared)
            {
                Debug.LogWarning($"UI States of {gameObject.name} not initialised.");
                return;
            }

            UIState newState = null;
            foreach (UIState state in states)
            {
                if (stateType == state.GetType())
                {
                    newState = state;
                    break;
                }
            }

            if (currentState)
                lastType = currentState.GetType();

            currentState?.HideState();
            currentState = newState;
            currentState?.ShowState();
        }
    }
}