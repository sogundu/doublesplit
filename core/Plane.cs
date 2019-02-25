namespace alg.core
{
    public class Plane
    {
        public PlaneSize Size { get; }

        public int NumberOfCosineIterations { get; }

        public Plane(IValidator<Plane> planeValidator, PlaneSize size, int numberOfCosineIterations)
        {
            Size = size;

            NumberOfCosineIterations = numberOfCosineIterations;

            planeValidator.Validate(this);
        }
    }
}