using UnityEngine;

namespace Patterns
{
    // a common interface between products
    public interface IProduct
    {
        // add common properties and methods here
        public string ProductName { get; set; }

        // customize this for each concrete product
        public void Initialize();
    }
}
