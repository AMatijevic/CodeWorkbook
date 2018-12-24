using TotalRecall.Core.Enums;

namespace TotalRecall.Core.Entities
{
    public class Length //ValueObject
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