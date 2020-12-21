using System;
using Linkedin.DogMeasures.Exceptions;
using Linkedin.DogMeasures.Models;
using Linkedin.DogMeasures.Repositories;
using Linkedin.DogMeasures.Services;
using NUnit.Framework;

namespace NUnit.DogMeasures.Tests
{
    [TestFixture]
    public class DogMeasuresServiceShould
    {
        private DogMeasuresService _dogMeasuresService;
        [OneTimeSetUp]
        public void Setup()
        {
            _dogMeasuresService = new DogMeasuresService(new DogMeasuresRepository());
        }

        [Test]
        public void ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _dogMeasuresService.CheckDogIdealWeight(null, 0));
        }
        [Test]
        public void ThrowsBreedNotFoundException_IfBreedIsSamoyedo()
        {
            Assert.Throws<BreedNotFoundException>(() => _dogMeasuresService.CheckDogIdealWeight("samoyedo", 20));
        }
        [Test]
        public void ThrowsArgumentOutOfRangeException_IfBreedOsNull()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _dogMeasuresService.CheckDogIdealWeight("bóxer", -5));
        }
        [Test]
        public void DogIsIdealWeight([Range(5,19)]int Weight)
        {
            var result = _dogMeasuresService.CheckDogIdealWeight("Labrador retriever", Weight);
            Assert.True(result.DeviationType == DogWeightInfo.WeightDeviationType.BelowWeight);
            Assert.AreEqual(20 - Weight, result.WeightDeviation);

        }
    }
}
