using System;

// Domain Service
namespace DoneByMe.Pricing.Model.Analysis {
    public class PricingAnalyzer {
        private readonly PricingAnalysisRepository repository;
        public PricingAnalyzer (PricingAnalysisRepository repository) {
            this.repository = repository;
        }
        public void AnalyzePricing (string pricedItemId, long price) {
            // TODO: process in this Domain Service and keep PricingHistory
            Console.WriteLine ("PricingAnalyzer#AnalyzePricing(" + pricedItemId + ", " + price + ")");

            // TODO lots of stuff
			var verified = price % 2 > 0;

            PricingAnalysis pricingAnalysis;
			if(verified)
			{
            	pricingAnalysis = PricingAnalysis.VerifiedWith(pricedItemId, price);
			}
			else {
				pricingAnalysis = PricingAnalysis.RejectedWith(pricedItemId, price);
			}

			this.repository.Save(pricingAnalysis);
        }
    }
}