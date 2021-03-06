﻿using System.Collections.Generic;

namespace WJStore.Domain.Entities.EqualityCompare
{
    public class OwnerComparer : IEqualityComparer<Owner>
    {
        // Objects are equal if their unique data are equal.
        public bool Equals(Owner x, Owner y)
        {
            //Check whether the compared objects reference the same data.
            if (ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;

            //Check whether the objects' properties are equal.
            return x.Name == y.Name;
        }

        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.

        public int GetHashCode(Owner Owner)
        {
            //Check whether the object is null
            if (ReferenceEquals(Owner, null)) return 0;

            //Get hash code for the field.
            var hashOwnerName = Owner.Name.GetHashCode();

            //Calculate the hash code for the object.
            return hashOwnerName;
        }
    }
}
