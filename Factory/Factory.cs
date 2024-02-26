using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Generic factory class
/// </summary>
public class Factory<T> where T : MonoBehaviour, IProduct
{
    private List<GameObject> products; // Assume all products are instantiated from a known GameObject
    private IFactory<T> creator; // Assume all products are from another GameObject, that may want to know of them

    public List<GameObject> Products { get => products; set => products = value; }
    public IFactory<T> Creator { get => creator; set => creator = value; }

    public Factory(IFactory<T> creator) 
    {
        this.Creator = creator;
        this.Products = creator.Producables;
    }

    // Factory's produce method
    public T Build(GameObject product)
    {
        if (product == null)
        {
            Debug.LogError("Product is null. Cannot build product.");
            return null;
        }
        if (!Products.Contains(product))
        {
            Debug.LogError($"{product} is not a valid product of this factory");
            return null;
        }

        Vector3 position = Creator.FactoryOutputPosition;
        
        // Create the product
        GameObject productInstance = UnityEngine.Object.Instantiate(product, position, Quaternion.identity);
        
        // Get T by component - where component is it's main script
        T productComponent = productInstance.GetComponent<T>();
        // If that failed
        if (productComponent == null)
        {
            // Add the component
            productComponent = productInstance.AddComponent<T>();
        }
        
        // Call an initialization method
        productComponent.OnCreate();

        // Return the component - as a reference
        return productComponent;
    }
}