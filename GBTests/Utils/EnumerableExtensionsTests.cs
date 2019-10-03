using System.Collections.Generic;
using NUnit.Framework;
using FluentAssertions;
using GBEmu.Utils;
using System;

namespace GBTests.Utils
{
    [TestFixture]
    public class EnumerableExtensionsTests
    {
        private static IEnumerable<TestCaseData> ChunkifyTestCases()
        {
            yield return new TestCaseData(new byte[0], 1, new byte[0][]);
            yield return new TestCaseData(new byte[] { 0xde, 0xad, 0xbe, 0xef }, 2,
                new byte[][] { new byte[] { 0xde, 0xad }, new byte[] { 0xbe, 0xef } });
            yield return new TestCaseData(new byte[] { 1, 2, 3, 4 }, 3,
                new byte[][] { new byte[] { 1, 2, 3 }, new byte[] { 4 } });
        }

        [Test]
        [TestCaseSource(nameof(ChunkifyTestCases))]
        public void ChunkifyTests(byte[] input, int chunkSize, byte[][] expected)
        {
            input.Chunkify(chunkSize).Should().BeEquivalentTo(expected);
        }

        [Test]
        public void ChunkifyShouldThrowWhenGivenNullTest()
        {
            IEnumerable<byte> input = null;
            Action a = () => input.Chunkify(2);
            a.Should().ThrowExactly<ArgumentNullException>();
        }

        [Test]
        public void ChunkifyShouldThrowWhenGivenNegativeSizeTest()
        {
            Action a = () => new string[] { "a", "b", "c", "d" }.Chunkify(-2);
            a.Should().ThrowExactly<ArgumentException>();
        }
    }
}
