using VaughnVernon.Mockroservices;

namespace DoneByMe.Pricing.Model.Analysis
{
    public class PricingVerified : DomainEvent
    {
        public string OriginatorId { get; private set; }

		public long Price { get; private set; }

        public PricingVerified() { }

        public static PricingVerified Instance(
            string originatorId,
            long price)
        {
            PricingVerified pricingVerified = new PricingVerified
            {
                OriginatorId = originatorId,
                Price = price,
            };

            return pricingVerified;
		}
    }
}