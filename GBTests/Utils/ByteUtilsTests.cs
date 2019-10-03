using System.Collections.Generic;
using GBEmu.Utils;
using NUnit.Framework;
using FluentAssertions;
using System;

namespace GBTests.Utils
{
    [TestFixture]
    public class ByteUtilsTests
    {
        private static IEnumerable<TestCaseData> HexStringToBytesTestCases()
        {
            yield return new TestCaseData("", new byte[0]);
            yield return new TestCaseData("ab", new byte[] { 0xab });
            yield return new TestCaseData("BA", new byte[] { 0xba });
            yield return new TestCaseData("cafe", new byte[] { 0xca, 0xfe });
            yield return new TestCaseData("deadBEEF", new byte[] { 0xde, 0xad, 0xbe, 0xef });
        }

        [Test]
        [TestCaseSource(nameof(HexStringToBytesTestCases))]
        public void HexStringToBytesTests(string hex, byte[] expected)
        {
            ByteUtils.HexStringToBytes(hex).Should().BeEquivalentTo(expected);
        }

        [Test]
        public void HexStringToBytesShouldThrowWhenGivenNullTest()
        {
            Action a = () => ByteUtils.HexStringToBytes(null).Should();
            a.Should().ThrowExactly<ArgumentNullException>();
        }

        private static IEnumerable<TestCaseData> BytesToHexStringTestCases()
        {
            yield return new TestCaseData(new byte[0], "");
            yield return new TestCaseData(new byte[] { 0xcd }, "cd");
            yield return new TestCaseData(new byte[] { 0xde, 0xad, 0xbe, 0xef }, "deadbeef");
        }

        [Test]
        [TestCaseSource(nameof(BytesToHexStringTestCases))]
        public void BytesToHexStringTests(byte[] bytes, string expected)
        {
            ByteUtils.BytesToHexString(bytes).Should().Be(expected);
        }

        [Test]
        public void BytesToHexStringShouldThrowWhenGivenNullTest()
        {
            Action a = () => ByteUtils.BytesToHexString(null).Should();
            a.Should().ThrowExactly<ArgumentNullException>();
        }
    }
}
