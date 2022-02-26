using dreamscape.EncryptionTraining.EncryptionLibrary.ViginereEncryption.Encryptor;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.Tests.ViginereEncryption.Encryptor
{
    public class VigenereEncryptorTests
    {
        private VigenereEncryptor _encryptor;

        [SetUp]
        public void SetUp()
        {
            _encryptor = new VigenereEncryptor();
        }

        [Test]
        public void UppercaseConversionWorksCorrectly()
        {
            //All characters in lowercase
            string toConvert = "abcdefg";
            string expect = "ABCDEFG";
            Assert.AreEqual(expect, _encryptor.SetToUpperCase(toConvert));

            //Characters in both lower and upper case
            toConvert = "bcdABdfgC";
            expect = "BCDABDFGC";
            Assert.AreEqual(expect, _encryptor.SetToUpperCase(toConvert));

            //The crazy line does not throw exceptions and works out
            toConvert = " 6jf94$1! @#fddxАБ Вва";
            expect = " 6JF94$1! @#FDDXАБ ВВА";
            Assert.AreEqual(expect, _encryptor.SetToUpperCase(toConvert));
        }

        [Test]
        public void GetSymbolWithOffsetWorksCorrectly()
        {
            //A + 1 = B
            Assert.AreEqual('B', _encryptor.GetSymbolWithOffset('A', 1));

            //A + 2 = C
            Assert.AreEqual('C', _encryptor.GetSymbolWithOffset('A', 2));

            //Z + 1 = A
            Assert.AreEqual('A', _encryptor.GetSymbolWithOffset('Z', 1));

            //W + 5 = B
            Assert.AreEqual('B', _encryptor.GetSymbolWithOffset('W', 5));

            //A + 26 = A
            Assert.AreEqual('A', _encryptor.GetSymbolWithOffset('A', 26));

            //Z + 26 = Z
            Assert.AreEqual('Z', _encryptor.GetSymbolWithOffset('Z', 26));

            //Z + 27 = A
            Assert.AreEqual('A', _encryptor.GetSymbolWithOffset('Z', 27));

            //X + 52 = X
            Assert.AreEqual('X', _encryptor.GetSymbolWithOffset('X', 52));

            //X + 53 = Y
            Assert.AreEqual('Y', _encryptor.GetSymbolWithOffset('X', 53));

            //C + 262 = E
            Assert.AreEqual('E', _encryptor.GetSymbolWithOffset('C', 262));
        }

        [Test]
        public void CheckAlphabetFromPosGeneration()
        {
            //from B
            var expect = "BCDEFGHIJKLMNOPQRSTUVWXYZA".ToCharArray();
            var result = _encryptor.GenerateAlphabetFromPos('B');
            Assert.AreEqual(expect, result);

            //from J
            expect = "JKLMNOPQRSTUVWXYZABCDEFGHI".ToCharArray();
            result = _encryptor.GenerateAlphabetFromPos('J');
            Assert.AreEqual(expect, result);

            //from Y
            expect = "YZABCDEFGHIJKLMNOPQRSTUVWX".ToCharArray();
            result = _encryptor.GenerateAlphabetFromPos('Y');
            Assert.AreEqual(expect, result);
        }

        [Test]
        public void CheckEncryptionTableGenerationWorksCorrectly()
        {
            //key 'BJY'
            char[][] except = new char[][]
            {
                "BCDEFGHIJKLMNOPQRSTUVWXYZA".ToCharArray(),
                "JKLMNOPQRSTUVWXYZABCDEFGHI".ToCharArray(),
                "YZABCDEFGHIJKLMNOPQRSTUVWX".ToCharArray(),
            };
            char[][] result = _encryptor.GetEncryptionTable("BJY");
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
            result = _encryptor.GetEncryptionTable("BJYHG");
            Assert.AreEqual(except, result);
        }

        [Test]
        public void CheckGetEncryptedString()
        {
            //encryption table for key 'BJYHG'
            char[][] encryptionTable = new char[][]
            {
                "BCDEFGHIJKLMNOPQRSTUVWXYZA".ToCharArray(),
                "JKLMNOPQRSTUVWXYZABCDEFGHI".ToCharArray(),
                "YZABCDEFGHIJKLMNOPQRSTUVWX".ToCharArray(),
                "HIJKLMNOPQRSTUVWXYZABCDEFG".ToCharArray(),
                "GHIJKLMNOPQRSTUVWXYZABCDEF".ToCharArray(),
            };

            var result = _encryptor.GetEncryptedString("ABC", encryptionTable);
            Console.WriteLine(result);
        }


    }
}
