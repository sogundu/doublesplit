using System;

namespace DoubleSplit.Core
{
    public class PlaneValidator : IValidator<Plane>
    {
        public void Validate(Plane entity)
        {
            if(entity.NumberOfCosineIterations % 2 != 0)
            {
                throw new ArgumentException("Number of cosine iterations must be even!");
            }
        }
    }
}