using System;
using Linkedin.DogMeasures.Exceptions;
using Linkedin.DogMeasures.Models;
using Linkedin.DogMeasures.Repositories;
using Linkedin.DogMeasures.Services;
using Xunit;

namespace xUnit.DogMesasures.Test
{
    public class DogMeasuresServiceShould
    {
        private DogMeasuresService _dogMeasuresService;

        public DogMeasuresServiceShould()
        {
            _dogMeasuresService = new DogMeasuresService(new DogMeasuresRepository());
        }

        [Fact]
        public void ThrowArgumenNullException_IfBreedOsNull()
        {
            Assert.Throws<ArgumentNullException>(() => _dogMeasuresService.CheckDogIdealWeight(null, 0));
        }
        [Fact]
        public void ThrowsBreedNotFoundException_IfBreedIsSamoyedo()
        {
            Assert.Throws<BreedNotFoundException>(() => _dogMeasuresService.CheckDogIdealWeight("samoyedo", 20));
        }
        [Fact]
        public void ThrowsArgumentOutOfRangeException_IfBreedOsNull()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _dogMeasuresService.CheckDogIdealWeight("bóxer", -5));
        }

        [InlineData((20))]
        [Theory]
        public void DogIsIdealWeight(int Weight)
        {
            var result = _dogMeasuresService.CheckDogIdealWeight("Labrador retriever", Weight);
            Assert.True(result.DeviationType == DogWeightInfo.WeightDeviationType.InRange);
            Assert.Equal(0, result.WeightDeviation);

        }

    }
}
