﻿using TechTalk.SpecFlow;
using Xunit;

namespace katarabbitmq.bdd.tests.Steps
{
    [Binding]
    public class DockerShutdownStepDefinitions
    {
        [Given("the server is running")]
        public static void GivenTheServerIsRunning()
        {
            Assert.True(Processes.Robot.IsRunning);
        }

        [When("a TERM signal is sent")]
        public static void WhenATermSignalIsSent()
        {
            Processes.Robot.SendTermSignal();
        }

        [Then("the application shuts down.")]
        public static void TheApplicationShutsDown()
        {
            Assert.True(Processes.Robot.HasExited);
        }
    }
}
