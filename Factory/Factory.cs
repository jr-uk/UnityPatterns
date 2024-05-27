using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using UnityEngine;

namespace Patterns
{
    // base class for factories
    public abstract class Factory : MonoBehaviour
    {
        public abstract IProduct GetProduct(Vector2 position);

        // shared method with all factories
        public string GetLog(IProduct product)
        {
            string logMessage = "Factory: created product " + product.ProductName;
            return logMessage;
        }
    }
}
