﻿using UnityEngine;

namespace LightweightManagementSystem
{
    /// <summary>
    /// An abstract base class representing a manager in the form of a MonoBehaviour to be added to a gameobject within the scene.
    /// </summary>
    public abstract class MonoManager : MonoBehaviour, IManager
    {
        public virtual void OnManagerRegistered(CoreBehaviour coreBehaviour) { }
        public virtual void OnManagerUnregistered() { }

        protected void Awake()
        {
            if (CheckStatus()) // Check if the system is enabled
            {
                if (!CoreBehaviour.AddManager(this)) // Catch failure to add manager
                {
                    Debug.LogError("Unable to add manager " + GetType());
                }
            }

            // Continue calls to derived object
            PostAwake();
        }
        protected void OnDestroy()
        {
            if (CheckStatus()) // Check if the system is enabled
            {
                if (!CoreBehaviour.RemoveManager(this)) // Catch failrue to remove manager
                {
                    Debug.LogError("Unable to remove manager " + GetType());
                }
            }

            // Continue calls to derived object
            PostDestroy();
        }

        /// <summary>
        /// Check the status to see whether the lightweight management system is enabled or not.
        /// </summary>
        /// <returns></returns>
        private bool CheckStatus()
        {
            if (CoreBehaviour.IsCompileTimeEnabled()) // Ensure the system is enabled
            {
                return true;
            }
            else // System is disabled
            {
                Debug.LogError("Lightweight management system is disabled!");
                return false;
            }
        }

        protected virtual void PostAwake() { }
        protected virtual void PostDestroy() { }
    }
}