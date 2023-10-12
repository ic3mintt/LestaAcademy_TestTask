using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class Trap : MonoBehaviour
{
    [Header("Time settings")]
    [SerializeField] protected float RechargeDelay = 2f;
        
    protected List<IChangable> Units;
    
    protected virtual void Start()
    {
        Units = new List<IChangable>();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        AddUnit(other);
        Activate();
    }
    
    protected virtual void OnTriggerStay(Collider other)
    {
        if (Units.Count != 0)
        {
            Activate();
        }
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        RemoveUnit(other);
    }

    protected abstract void Activate();
    
    private void AddUnit(Collider col)
    {
        try
        {
            var unit = GetObject(col);
            if (unit != null && !Units.Contains(unit))
            {
                Units.Add(unit);
            }
        }catch { }
    }
    
    protected virtual void RemoveUnit(Collider other)
    {
        try
        {
            var unit = GetObject(other);
            if (unit != null && Units.Contains(unit))
            {
                Units.Remove(unit);
            }    
        }catch{}
    }

    protected abstract IChangable GetObject(Collider other);
}
