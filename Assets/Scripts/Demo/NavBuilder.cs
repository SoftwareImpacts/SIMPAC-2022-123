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

using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using NaughtyAttributes;
using UnityEngine.Events;

namespace SnapMeshPCG.Demo
{

    [RequireComponent(typeof(NavMeshSurface))]
    public class NavBuilder : MonoBehaviour
    {
        [SerializeField] private NavWalker demoCharacter = null;
        [Foldout(":: Events ::")]
        [SerializeField]
        private UnityEvent<MapPiece[]> OnNavMeshReady = null;

        public void BuildNavMesh(MapPiece[] pieces)
        {
            NavMeshSurface dummyNav = GetComponent<NavMeshSurface>();
            if (dummyNav == null)
                dummyNav = gameObject.AddComponent<NavMeshSurface>();

            StartCoroutine(BuildNavMeshCR(pieces));
        }

        private IEnumerator BuildNavMeshCR(MapPiece[] pieces)
        {
            yield return null;

            GameObject topPiece = pieces[0].gameObject;
            NavMeshSurface unWantedNav =
                topPiece.GetComponent<NavMeshSurface>();
            if(unWantedNav != null)
                Destroy(unWantedNav);
            NavMeshSurface nav = topPiece.AddComponent<NavMeshSurface>();
            nav.useGeometry = NavMeshCollectGeometry.PhysicsColliders;

            print($"Building NavMesh at parent piece: {nav.gameObject.name}");
            nav.BuildNavMesh();

            demoCharacter.mapPieces = pieces;
            Instantiate(demoCharacter.gameObject, new Vector3(0, 10, 0), Quaternion.identity);

            OnNavMeshReady.Invoke(pieces);
        }
    }
}

