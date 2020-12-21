using System;
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
            Assert.Throws<ArgumentNullException>(() => _dogMeasuresService.CheckDogIdealWeight("samoyedo", 20));
        }
        [Fact]
        public void ThrowsArgumentOutOfRangeException_IfBreedOsNull()
        {
            Assert.Throws<ArgumentNullException>(() => _dogMeasuresService.CheckDogIdealWeight("bóxer", -5));
        }

    }
}
