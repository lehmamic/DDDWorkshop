﻿using System;
using System.Collections.Generic;
using System.Threading;
using DoneByMe.Matching.Infra.Persistence;
using DoneByMe.Matching.Model;
using DoneByMe.Matching.Model.Proposals;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void TestProposalSubmitted()
        {
            DoneByMe.Matching.Infra.StartUp.Start();
            DoneByMe.Pricing.Infra.StartUp.Start();

            Client client = Client.From("12345");

            ISet<Step> steps = new HashSet<Step>();
            steps.Add(Step.Ordered(1, Description.Has("Step 1")));

            Expectations expectations =
                Expectations.Of(
                    Summary.Has("A summary"),
                    Description.Has("A description"),
                    new DateTime(DateTime.Now.Ticks + (24 * 60 * 60 * 1000)),
                    steps,
                    1995);

            Proposal proposal = Proposal.SubmitFor(client, expectations);

            Repositories.ProposalRepository.Save(proposal);

            Thread.Sleep(1000);
        }
    }
}
