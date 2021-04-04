﻿using HeroesGame.Constant;
using HeroesGame.Contract;
using HeroesGame.Implementation.Hero;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesGame.Tests
{
    public class HeroShould
    {
        private Mock<Mage> _hero;

        [SetUp]
        public void Setup()
        {
            
            this._hero = new Mock<Mage>();
            this._hero.Protected()
                .Setup("LevelUp")
                .CallBase();


        }

        [Test]
        public void HaveCorrectInitialValues()
        {


            //Assert
            Assert.That(_hero.Object.Level, Is.EqualTo(HeroConstants.InitialLevel));
            Assert.That(_hero.Object.Experience, Is.EqualTo(HeroConstants.InitialExperience));
            Assert.That(_hero.Object.MaxHealth, Is.EqualTo(HeroConstants.InitialMaxHealth));
            Assert.That(_hero.Object.Health, Is.EqualTo(HeroConstants.InitialMaxHealth));
            Assert.That(_hero.Object.Armor, Is.EqualTo(HeroConstants.InitialArmor));
            Assert.That(_hero.Object.Weapon, Is.Not.Null);
        }

        [Test]
        public void TakeHitCorrectly()
        {


            //Act
            var damage = 50;
            this._hero.Object.TakeHit(damage);

            //Assert
            Assert.That(_hero.Object.Health, Is.EqualTo(HeroConstants.InitialMaxHealth - damage + HeroConstants.InitialArmor));
        }

        [Test]
        public void ThrowExceptionFonNegativeTakeHitValue()
        {
            //Act
            var damage = -50;

            //Assert
            Assert.Throws<ArgumentException>(() => this._hero.Object.TakeHit(damage), "Damage value can not be negative.");
        }

        [Test]
        [TestCase(10)]
        [TestCase(20)]
        [TestCase(30)]
        public void TakeHitCorrectly_TestCase(int damage)
        {
            //Act
            this._hero.Object.TakeHit(damage);

            //Assert
            Assert.That(this._hero.Object.Health, Is.EqualTo(HeroConstants.InitialMaxHealth - damage + HeroConstants.InitialArmor));
        }

        [Test]
        public void TakeHitCorrectly_Combinatorial([Values(40,50,60)]int damage)
        {
            //Act
            this._hero.Object.TakeHit(damage);

            //Assert
            Assert.That(this._hero.Object.Health, Is.EqualTo(HeroConstants.InitialMaxHealth - damage + HeroConstants.InitialArmor));
        }

        [Test]
        public void TakeHitCorrectly_Range([Range(70, 100, 10)] int damage)
        {
            //Act
            this._hero.Object.TakeHit(damage);

            //Assert
            Assert.That(this._hero.Object.Health, Is.EqualTo(HeroConstants.InitialMaxHealth - damage + HeroConstants.InitialArmor));
        }



    }
}
