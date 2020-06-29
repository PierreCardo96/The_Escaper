using Assets.Scripts.Player_Scripts.Powers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionBar : MonoBehaviour
{
    private ActionSlot[] actionSlots;
    private PowerType currentPowerType = PowerType.WhiteBall;

    void Awake()
    {
        actionSlots = GetComponentsInChildren<ActionSlot>();
    }

    public void UpdateSelection(PowerType powerType)
    {
        PowerType lastPowerType = currentPowerType;
        currentPowerType = powerType;
        foreach (ActionSlot actionSlot in actionSlots)
        {
            if(actionSlot.GetPowerType() == lastPowerType)
            {
                actionSlot.UnSelect();
            }
            if(actionSlot.GetPowerType() == currentPowerType)
            {
                actionSlot.Select();
            }
        }
    }

    public void ActivatePower(PowerType powerType)
    {
        foreach (ActionSlot actionSlot in actionSlots)
        {
            if (actionSlot.GetPowerType() == powerType)
            {
                actionSlot.SetIsActive(true);
            }
        }
    }

    public bool IsPowerActive(PowerType powerType)
    {
        foreach (ActionSlot actionSlot in actionSlots)
        {
            if (actionSlot.GetPowerType() == powerType)
            {
                return actionSlot.GetIsActive();
            }
        }
        return false;
    }

    public void UnselectAll()
    {
        currentPowerType = PowerType.WhiteBall;
        foreach (ActionSlot actionSlot in actionSlots)
        {
            actionSlot.UnSelect();
        }
    }

    public void SetAllKeysActivation(bool value)
    {
        currentPowerType = PowerType.WhiteBall;
        foreach (ActionSlot actionSlot in actionSlots)
        {
            actionSlot.UnSelect();
            actionSlot.SetIsActive(value);
        }
    }


}
