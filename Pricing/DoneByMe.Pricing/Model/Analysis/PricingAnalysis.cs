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

		private PricingAnalysis(string pricedItemId, long price)
		{
			Apply(PricingVerified.Instance(pricedItemId, price));
		}

		private PricingAnalysis(string pricedItemId, long price, long suggestedPrice)
		{
			Apply(PricingRejected.Instance(pricedItemId, price, suggestedPrice));
		}

        public static PricingAnalysis AnalizePrice(string pricedItemId, long price)
        {
			var verified = price % 2 > 0;
            return verified ? new PricingAnalysis(pricedItemId, price) : new PricingAnalysis(pricedItemId, price, price * 2);
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
