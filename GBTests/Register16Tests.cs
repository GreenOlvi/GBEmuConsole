using FluentAssertions;
using GBEmu;
using NUnit.Framework;

namespace GBTests
{
    public class Register16Tests
    {
        [Test]
        public void NewCreatedRegisterShouldBeZeroedTest()
        {
            var r = new Register16();
            r.Value.Should().Be(0);
            r.Hi.Should().Be(0);
            r.Lo.Should().Be(0);
        }

        [Test]
        public void SettingHiShouldChangeCombinedValueTest()
        {
            var r = new Register16();
            r.Hi = 0xbb;
            r.Value.Should().Be(0xbb00);
        }

        [Test]
        public void SettingLoShouldChangeCombinedValueTest()
        {
            var r = new Register16();
            r.Lo = 0xaa;
            r.Value.Should().Be(0x00AA);
        }

        [Test]
        public void SettingValueShouldChangeAllValuesTest()
        {
            var r = new Register16();
            r.Value = 0xbeef;
            r.Value.Should().Be(0xbeef);
            r.Hi.Should().Be(0xbe);
            r.Lo.Should().Be(0xef);
        }
    }
}