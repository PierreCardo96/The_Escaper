using Assets.Scripts.Player_Scripts.Powers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionSlot : MonoBehaviour
{
    [SerializeField]
    private PowerType powerType = PowerType.WhiteBall;
    private RawImage powerImage;
    private RawImage[] borders;

    [SerializeField]
    private bool isActive = false;

    void Awake()
    {
        powerImage = GetComponent<RawImage>();
        borders = GetComponentsInChildren<RawImage>();
    }
    
    public void Select()
    {
        ColorBorders(Color.red);
    }

    public void UnSelect()
    {
        ColorBorders(Color.yellow);
    }

    public void SetIsActive(bool isActive)
    {
        if(isActive)
        {
            powerImage.color = Color.white;
        }
        else
        {
            powerImage.color = new Color(0.25f,0.25f,0.25f);
        }
        this.isActive = isActive;
    }

    private void ColorBorders(Color color)
    {
        borders[1].color = color;
        borders[2].color = color;
    }


    public PowerType GetPowerType()
    {
        return powerType;
    }

    public bool GetIsActive()
    {
        return isActive;
    }
}
