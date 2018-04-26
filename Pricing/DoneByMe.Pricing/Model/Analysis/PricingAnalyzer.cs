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

            var pricingAnalysis = PricingAnalysis.AnalizePrice(pricedItemId, price);
			this.repository.Save(pricingAnalysis);

        }
    }
}