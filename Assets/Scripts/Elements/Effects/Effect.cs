using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Effect : MonoBehaviour
{
    [SerializeField]
    ElementType elementType;
    public ElementType ElementType => elementType;
    [SerializeField]
    EffectType effectType;
    public EffectType EffectType => effectType;


    public abstract void Apply(Unit unit);

    public abstract void Remove(Unit unit);
}
