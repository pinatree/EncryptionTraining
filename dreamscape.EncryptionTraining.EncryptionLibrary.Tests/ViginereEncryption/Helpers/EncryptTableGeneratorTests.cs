using dreamscape.EncryptionTraining.EncryptionLibrary.ViginereEncryption.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.Tests.ViginereEncryption.Helpers
{
    public class EncryptTableGeneratorTests
    {
        [Test]
        public void CheckAlphabetFromPosGeneration()
        {
            VigenereSymbolsHelper vigenereSymbolsHelper = new VigenereSymbolsHelper('A', 'Z');

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
            VigenereSymbolsHelper vigenereSymbolsHelper = new VigenereSymbolsHelper('A', 'Z');
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
