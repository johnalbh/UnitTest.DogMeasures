using System;
using Linkedin.DogMeasures.Exceptions;
using Linkedin.DogMeasures.Models;
using Linkedin.DogMeasures.Repositories;
using Linkedin.DogMeasures.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DogMeasures.Tests
{
    [TestClass]
    public class DogMeasuresServiceShould
    {
        private static DogMeasuresService _dogMeasuresService;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _dogMeasuresService = new DogMeasuresService(new DogMeasuresRepository());
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ThrowsArgumentNullException_IfBreedIsNull()
        {
            _dogMeasuresService.CheckDogIdealWeight(null, 0);
        }

        [ExpectedException(typeof(BreedNotFoundException))]
        [TestMethod]
        public void ThrowsBreedNotFoundException_IfBreedIsSamoyedo()
        {
            _dogMeasuresService.CheckDogIdealWeight("samoyedo", 20);
        }

        [DataTestMethod]
        [DataRow("Labrador Retriever", 20)]
        [DataRow("Labrador Retriever", 22)]
        [DataRow("Labrador Retriever", 20)]

        public void DogIsIdealWeight_IfBreedIsLabradorAndWeightInRange20and40(string breed, int weight)
        {
            var result = _dogMeasuresService.CheckDogIdealWeight(breed, weight);
            Assert.IsTrue(result.DeviationType == DogWeightInfo.WeightDeviationType.InRange);
            Assert.AreEqual(0, result.WeightDeviation);
        }


    }
}
