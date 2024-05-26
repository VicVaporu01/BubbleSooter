using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PoolPlayerIndicators : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabsIndicators;
    [SerializeField] private List<GameObject> playerIndicators;

    private int listLength = 6;

    private void Awake()
    {
        for (int i = 0; i < listLength; i++)
        {
            playerIndicators.Add(GenerateIndicator(i));
        }
    }

    private GameObject GenerateIndicator(int indicatorPosition)
    {
        GameObject indicator = Instantiate(prefabsIndicators[indicatorPosition], transform);
        indicator.SetActive(false);

        return indicator;
    }

    public GameObject RequestIndicator(int indicatorType)
    {
        GameObject indicator = playerIndicators[indicatorType];
        indicator.SetActive(true);
        return indicator;
    }
}