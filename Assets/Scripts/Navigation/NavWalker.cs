﻿/*
 * Copyright 2021 Snappable Meshes PCG contributors
 * (https://github.com/VideojogosLusofona/snappable-meshes-pcg)
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SnapMeshPCG.Navigation
{
    /// <summary>
    /// Represents the AI bot that will navigate the map as a demonstration.
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    public class NavWalker : MonoBehaviour
    {
        // Reference to the navmesh agent component
        private NavMeshAgent _agent;

        // Reference to the NavScanner component
        private NavScanner _navScanner;

        // Start is called before the first frame update
        private void Start()
        {
            // Disable main camera, since we want to use the walker cam for the demo
            Camera.main.gameObject.SetActive(false);

            // Get a reference to the NavScanner
            _navScanner = GameObject
                .Find("NavController")
                .GetComponent<NavScanner>();

            // Get the NavMeshAgent component, and if we don't find it, add
            // a new one
            _agent = GetComponent<NavMeshAgent>();
            if (_agent == null)
                _agent = gameObject.AddComponent<NavMeshAgent>();

            // Use the most connect nav point for placing the agent
            Vector3 point = _navScanner.NavPoints[0].Point;

            bool warp = _agent.Warp(point);
            if (warp)
            {
                _agent.enabled = false;
                transform.position = point;
            }

            _agent.enabled = true;
            _agent.updateRotation = true;
            _agent.updateUpAxis = true;
            GetNewPath();
        }

        // Update is called once per frame
        private void Update()
        {
            NavMeshPathStatus pathStatus = _agent.pathStatus;

            // If Path is anything but being able to reach destination
            // get a new one
            if (pathStatus != NavMeshPathStatus.PathComplete)
                GetNewPath();

            // If walker has reached destination, get a new path
            if (Mathf.RoundToInt(_agent.remainingDistance) == 0)
                GetNewPath();
        }

        private void GetNewPath()
        {
            _agent.ResetPath();
            Vector3 newTarget = _navScanner.FindPointInNavMesh().Value;

            Debug.DrawLine(transform.position, newTarget, Color.green, 10);
            _agent.SetDestination(newTarget);
        }
    }
}