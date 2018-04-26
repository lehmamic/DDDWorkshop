using DoneByMe.Pricing.Model.Analysis;

// Application Service
namespace DoneByMe.Pricing.Application {
    public class PricingVerification
    {
		private readonly PricingAnalysisRepository repository;

        public PricingVerification (PricingAnalysisRepository repository) {
            this.repository = repository;
        }

        public void VerifyPricing (string pricedItemId, long price) {
            new PricingAnalyzer(this.repository).AnalyzePricing (pricedItemId, price);
        }
    }
}