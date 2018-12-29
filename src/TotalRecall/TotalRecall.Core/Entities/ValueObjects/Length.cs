using TotalRecall.Core.Enums;
using TotalRecall.Core.SharedKernel;

namespace TotalRecall.Core.Entities.ValueObjects
{
    //Value object
    public class Length : ValueObject
    {
        public Length()
        {
            Amount = 0;
            Unit = LengthUnit.None;
        }

        public float Amount { get; protected set; }
        public LengthUnit Unit { get; protected set; }
    }
}