using System;
using System.Collections.Generic;
using VaughnVernon.Mockroservices;

namespace DoneByMe.Pricing.Model.Analysis
{
    public class PricingAnalysis : EventSourcedRootEntity
	{
		public Id Id { get; private set; }

		public long Price { get; private set; }

		public long SuggestedPrice { get; private set; }

		public bool Verified { get; private set; }

		public PricingAnalysis(List<DomainEvent> events, int streamVersion)
			: base(events, streamVersion) 
		{
		}

		private PricingAnalysis(string pricedItemId, long price, long suggestedPrice, bool verified)
		{
			if(verified)
			{
				Apply(PricingVerified.Instance(pricedItemId, price));
			}
			else
			{
				Apply(PricingRejected.Instance(pricedItemId, price, suggestedPrice));
			}
		}

        public static PricingAnalysis RejectedWith(string pricedItemId, long price)
        {
            return new PricingAnalysis(pricedItemId, price, price, false);
        }

        public static PricingAnalysis VerifiedWith(string pricedItemId, long price)
        {
            return new PricingAnalysis(pricedItemId, price, price * 2, true);
        }

		public void When(PricingVerified pricingVerified)
		{
			this.Id = Id.FromExisting(pricingVerified.OriginatorId);
			this.Price = pricingVerified.Price;
			this.SuggestedPrice = pricingVerified.Price;
			this.Verified = true;
		}

		public void When(PricingRejected pricingRejected)
		{
			this.Id = Id.FromExisting(pricingRejected.OriginatorId);
			this.Price = pricingRejected.Price;
			this.SuggestedPrice = pricingRejected.SuggestedPrice;
			this.Verified = false;
		}
    }
}
