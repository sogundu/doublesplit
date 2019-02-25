using System;

namespace alg.core
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