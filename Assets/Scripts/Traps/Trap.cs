using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class Trap : MonoBehaviour
{
    protected List<GameObject> Units;

    protected virtual void Start()
    {
        Units = new List<GameObject>();
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

    protected virtual void Activate(){}
    
    private void AddUnit(Collider col)
    {
        try
        {
            var unit = GetObject(col);
            if (unit != null && !Units.Contains(unit))
            {
                Units.Add(unit);
            }
        }
        catch { }
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
    
    protected virtual GameObject GetObject(Collider other) => 
        other.gameObject.GetComponentInParent<Rigidbody>().gameObject;
}
