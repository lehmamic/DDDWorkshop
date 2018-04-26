using System;
using System.Collections.Generic;
using DoneByMe.Matching.Infra;
using DoneByMe.Matching.Model;
using DoneByMe.Matching.Model.Proposals;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTests
{
    [TestClass]
    public class Exercise2Test
    {
        [TestMethod]
        public void ProposalSubmitted_FullRoundTrip()
        {
            DoneByMe.Matching.Infra.StartUp.Start();
            DoneByMe.Pricing.Infra.StartUp.Start();

            API.ProposalCommands.SubmitProposal(
                clientId: "12345",
                summary: "A summary",
                description: "A description",
                completedBy: new DateTime(DateTime.Now.Ticks + (24 * 60 * 60 * 1000)),
                steps: new Dictionary<int, string> { { 1, "Step 1"} },
                price: 1995);
        }
    }
}