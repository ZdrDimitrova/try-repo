using HeroesGame.Contract;
using HeroesGame.Implementation.Hero;
using HeroesGame.Implementation.Monster;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesGame.Tests
{
    public class CombatProcessorShould
    {
        private CombatProcessor _cp;

        [SetUp]
        public void Setup()
        {
            this._cp = new CombatProcessor(new Hunter());
           
        }

        [Test]
        public void InitializeCorrectly()
        {
            Assert.That(this._cp.Hero, Is.Not.Null);
            Assert.That(this._cp.Logger, Is.Not.Null);
            Assert.That(this._cp.Logger, Is.Empty);
        }

       

    }
}
