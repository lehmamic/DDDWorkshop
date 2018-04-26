using DoneByMe.Pricing.Application;
using DoneByMe.Pricing.Infra.Persistence;

namespace DoneByMe.Pricing.Infra
{
	public class API
	{
		private static PricingVerification pricingVerification;
		public static PricingVerification PricingVerification
        {
			get
			{
				if (pricingVerification == null)
				{
					pricingVerification = new PricingVerification(Repositories.PricingAnalysisRepository);
				}
				return pricingVerification;
			}
		}
	}
}
