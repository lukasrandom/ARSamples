﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshSurface))]
public class NavMeshUpdater : MonoBehaviour
{
    public bool m_EverySecond = false;
    private NavMeshSurface m_navMeshSurface;
    private float m_UpdateInterval = 1f;

    void Start()
    {
        m_navMeshSurface = GetComponent<NavMeshSurface>();

        // temp test
        if (m_EverySecond)
            StartCoroutine(IntervalMeshUpdater());
        else
            AreaMarker.onUpdatedArea += OnUpdatedMesh;
    }

    private void OnUpdatedMesh(object sender, Mesh mesh)
    {
        m_navMeshSurface.BuildNavMesh();
    }

    private IEnumerator IntervalMeshUpdater()
    {
        while (true)
        {
            OnUpdatedMesh(null, null);
            yield return new WaitForSeconds(m_UpdateInterval);
        }
    }
}
