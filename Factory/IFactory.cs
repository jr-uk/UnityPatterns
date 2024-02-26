using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// For Generic Factory Implementations
/// 
/// Where T is the component/script to attach
/// 
/// Implementation (minus generics):  
/// public FactoryT Factory => factory;
/// public ListT Producables => producables;
/// public Vector3 FactoryOutputPosition => factoryOutputPosition;
/// public void Produce() {}
/// </summary>
public interface IFactory<T> where T : MonoBehaviour, IProduct
{
    Factory<T> Factory { get; }
    List<GameObject> Producables { get; } // Required - Valid GameObjects for this factory to create and attach too
    Vector3 FactoryOutputPosition { get; } // Required - location for spawning in objects
    void Produce(GameObject gameObject); // Used to create from this.producables and attached factory component
}