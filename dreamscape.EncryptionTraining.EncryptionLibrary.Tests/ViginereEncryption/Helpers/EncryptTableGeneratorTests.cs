using dreamscape.EncryptionTraining.EncryptionLibrary.ViginereEncryption.Helpers;
using NUnit.Framework;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.Tests.ViginereEncryption.Helpers
{
    public class EncryptTableGeneratorTests
    {
        [Test]
        public void CheckAlphabetFromPosGeneration()
        {
            VigenereAlphabetHelper vigenereSymbolsHelper = new VigenereAlphabetHelper('A', 'Z');

            //from B
            var expect = "BCDEFGHIJKLMNOPQRSTUVWXYZA".ToCharArray();
            var result = EncryptTableGenerator.GenerateAlphabetFromPos('B', vigenereSymbolsHelper);
            Assert.AreEqual(expect, result);

            //from J
            expect = "JKLMNOPQRSTUVWXYZABCDEFGHI".ToCharArray();
            result = EncryptTableGenerator.GenerateAlphabetFromPos('J', vigenereSymbolsHelper);
            Assert.AreEqual(expect, result);

            //from Y
            expect = "YZABCDEFGHIJKLMNOPQRSTUVWX".ToCharArray();
            result = EncryptTableGenerator.GenerateAlphabetFromPos('Y', vigenereSymbolsHelper);
            Assert.AreEqual(expect, result);
        }

        [Test]
        public void CheckEncryptionTableGenerationWorksCorrectly()
        {
            VigenereAlphabetHelper vigenereSymbolsHelper = new VigenereAlphabetHelper('A', 'Z');
            //key 'BJY'
            char[][] except = new char[][]
            {
                "BCDEFGHIJKLMNOPQRSTUVWXYZA".ToCharArray(),
                "JKLMNOPQRSTUVWXYZABCDEFGHI".ToCharArray(),
                "YZABCDEFGHIJKLMNOPQRSTUVWX".ToCharArray(),
            };
            char[][] result = EncryptTableGenerator.GetEncryptionTable("BJY", vigenereSymbolsHelper);
            Assert.AreEqual(except, result);

            //key 'BJYHG'
            except = new char[][]
            {
                "BCDEFGHIJKLMNOPQRSTUVWXYZA".ToCharArray(),
                "JKLMNOPQRSTUVWXYZABCDEFGHI".ToCharArray(),
                "YZABCDEFGHIJKLMNOPQRSTUVWX".ToCharArray(),
                "HIJKLMNOPQRSTUVWXYZABCDEFG".ToCharArray(),
                "GHIJKLMNOPQRSTUVWXYZABCDEF".ToCharArray(),
            };
            result = EncryptTableGenerator.GetEncryptionTable("BJYHG", vigenereSymbolsHelper);
            Assert.AreEqual(except, result);
        }
    }
}
