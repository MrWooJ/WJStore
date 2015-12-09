using System.Collections.Generic;

namespace WJStore.Domain.Entities.EqualityCompare
{
    public class ProductComparer : IEqualityComparer<Product>
    {
        // Objects are equal if their unique data are equal.
        public bool Equals(Product x, Product y)
        {
            //Check whether the compared objects reference the same data.
            if (ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;

            //Check whether the objects' properties are equal.
            return x.Title == y.Title && x.Owner == y.Owner;
        }

        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.

        public int GetHashCode(Product Product)
        {
            //Check whether the object is null
            if (ReferenceEquals(Product, null)) return 0;

            //Get hash code for the field if it is not null.
            var hashProductOwner = Product.Owner == null ? 0 : Product.Owner.Name.GetHashCode();

            //Get hash code for the field.
            var hashProductTitle = Product.Title.GetHashCode();

            //Calculate the hash code for the object.
            return hashProductTitle ^ hashProductOwner;
        }
    }
}
