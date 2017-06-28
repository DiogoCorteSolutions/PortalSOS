using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;


namespace PortalSos.Infra.CrossCutting.Common.Security
{
    public class CriptografiaSecurity
    {
        /// <summary>
        /// Método criar senha
        /// </summary>
        /// <param name="paramentro">Recebe um paramentro para criar senha</param>
        /// <returns>Retorna uma senha</returns>
        public static string CreatePassword(int paramentro)
        {
            string _allowedChars = "0123456789abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ";
            Random randNum = new Random();
            char[] chars = new char[paramentro];
            int allowedCharCount = _allowedChars.Length;
            for (int i = 0; i < paramentro; i++)
            {
                chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
            }
            return new string(chars);
        }

        /// <summary>
        /// Método criar senha
        /// </summary>
        /// <returns>Retorna uma senha</returns>
        public static string CreatePassword()
        {
            int Tamanho = 8; // Numero de digitos da senha
            string senha = string.Empty;

            for (int i = 0; i < Tamanho; i++)
            {
                Random random = new Random();
                int codigo = Convert.ToInt32(random.Next(48, 122).ToString());

                if ((codigo >= 48 && codigo <= 57) || (codigo >= 97 && codigo <= 122))
                {
                    string _char = ((char)codigo).ToString();
                    if (!senha.Contains(_char))
                    {
                        senha += _char;
                    }
                    else
                    {
                        i--;
                    }
                }
                else
                {
                    i--;
                }
            }
            return senha;
        }

        /// <summary>
        /// Vetor de bytes utilizados para a criptografia (Chave Externa)
        /// </summary>
        private static byte[] bIV = { 0x50, 0x08, 0xF1, 0xDD, 0xDE, 0x3C, 0xF2, 0x18, 0x44, 0x74, 0x19, 0x2C, 0x53, 0x49, 0xAB, 0xBC };

        /// <summary>
        /// Representação de valor em base 64 (Chave Interna)
        /// </summary>
        private const string AesIV256 = @"!axZwWeX#EDx412@";
        private const string AesKey256 = @"$mgvvuM;Pjam@;}x)t*M+f<~jFn#qb^#";

        private const string cryptoKey = "Q3JpcHRvZ3JhZmlhcyBjb20gUmluamRhZWwgLyBBRVM=";
        //private const string cryptoKey = "3cDyOf7I6P4sU+ImVmIJW8k/IzGyoCACaJi+PbVY+I8=";

        /// <summary>
        /// Metodo de criptografia de valor
        /// </summary>
        /// <param name="text">valor a ser criptografado</param>
        /// <returns>valor criptografado</returns>
        public static string EncryptOne(string text)
        {
            try
            {
                // Se a string não está vazia, executa a criptografia
                if (!string.IsNullOrEmpty(text))
                {
                    // Cria instancias de vetores de bytes com as chaves
                    byte[] bText, bKey;
                    bKey =
                    Convert.FromBase64String(cryptoKey);
                    bText =
                    new UTF8Encoding().GetBytes(text);

                    // Instancia a classe de criptografia Rijndael
                    Rijndael rijndael = new RijndaelManaged();

                    // Define o tamanho da chave "256 = 8 * 32"
                    // Lembre-se: chaves possíves:
                    // 128 (16 caracteres), 192 (24 caracteres) e 256 (32 caracteres)
                    rijndael.KeySize = 256;

                    // Cria o espaço de memória para guardar o valor criptografado:
                    MemoryStream mStream = new MemoryStream();

                    // Instancia o encriptador 
                    CryptoStream encryptor = new CryptoStream(mStream, rijndael.CreateEncryptor(bKey, bIV),

                             CryptoStreamMode.Write);

                    // Faz a escrita dos dados criptografados no espaço de memória
                    encryptor.Write(bText, 0, bText.Length);
                    // Despeja toda a memória.
                    encryptor.FlushFinalBlock();

                    // Pega o vetor de bytes da memória e gera a string criptografada
                    return Convert.ToBase64String(mStream.ToArray());
                }
                else
                {
                    // Se a string for vazia retorna nulo
                    return null;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message.ToString());
            }
        }

        /// <summary>
        /// Metodo de descriptografia
        /// </summary>
        /// <param name="text">texto criptografado</param>
        /// <returns>valor descriptografado</returns>
        public static string DecryptOne(string text)
        {
            try
            {
                // Se a string não está vazia, executa a criptografia
                if (!string.IsNullOrEmpty(text))
                {
                    // Cria instancias de vetores de bytes com as chaves
                    byte[] bText, bKey;
                    bKey = Convert.FromBase64String(cryptoKey);
                    bText =
                    Convert.FromBase64String(text);

                    // Instancia a classe de criptografia Rijndael
                    Rijndael rijndael = new RijndaelManaged();

                    // Define o tamanho da chave "256 = 8 * 32"
                    // Lembre-se: chaves possíves:
                    // 128 (16 caracteres), 192 (24 caracteres) e 256 (32 caracteres)
                    rijndael.KeySize = 256;

                    // Cria o espaço de memória para guardar o valor DEScriptografado:
                    MemoryStream mStream = new MemoryStream();

                    // Instancia o Decriptador 

                    CryptoStream decryptor =

                    new CryptoStream(

                    mStream,

                    rijndael.CreateDecryptor(bKey, bIV),

                    CryptoStreamMode.Write);

                    // Faz a escrita dos dados criptografados no espaço de memória
                    decryptor.Write(bText, 0, bText.Length);
                    // Despeja toda a memória.
                    decryptor.FlushFinalBlock();

                    // Instancia a classe de codificação para que a string venha de forma correta
                    UTF8Encoding utf8 = new UTF8Encoding();
                    // Com o vetor de bytes da memória, gera a string descritografada em UTF8
                    return utf8.GetString(mStream.ToArray());
                }
                else
                {
                    // Se a string for vazia retorna nulo
                    return null;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message.ToString());
            }
        }

        public static string EncryptTwo(string text)
        {
            return EncrypAndDecryptSecurity.Encrypt(text);
        }

        public static string DecryptTwo(string text)
        {
            return EncrypAndDecryptSecurity.Decrypt(text);
        }

        public static string Encrypt256(string text)
        {
            // AesCryptoServiceProvider
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.IV = Encoding.UTF8.GetBytes(AesIV256);
            aes.Key = Encoding.UTF8.GetBytes(AesKey256);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            // Convert string to byte array
            byte[] src = Encoding.Unicode.GetBytes(text);

            // encryption
            using (ICryptoTransform encrypt = aes.CreateEncryptor())
            {
                byte[] dest = encrypt.TransformFinalBlock(src, 0, src.Length);

                // Convert byte array to Base64 strings
                return Convert.ToBase64String(dest);
            }
        }

        /// <summary>
        /// AES decryption
        /// </summary>
        public static string Decrypt256(byte[] text)
        {
            // AesCryptoServiceProvider
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.IV = Encoding.UTF8.GetBytes(AesIV256);
            aes.Key = Encoding.UTF8.GetBytes(AesKey256);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            // Convert Base64 strings to byte array
            byte[] src = text;

            // decryption
            using (ICryptoTransform decrypt = aes.CreateDecryptor())
            {
                byte[] dest = decrypt.TransformFinalBlock(src, 0, src.Length);
                return Encoding.Unicode.GetString(dest);
            }
        }

        public static string HtmlEncode(string text)
        {
            return HttpUtility.HtmlEncode(text);
        }

        public static string HtmlDecode(string text)
        {
            return HttpUtility.HtmlDecode(text);
        }
    }

    class EncrypAndDecryptSecurity
    {
        public EncrypAndDecryptSecurity() { }

        /// <summary>
        /// Método conta quantidades de bytes em uma string
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static int GetByteCount(string hexString)
        {
            int numHexChars = 0;
            char c;
            // remove all none A-F, 0-9, characters
            for (int i = 0; i < hexString.Length; i++)
            {
                c = hexString[i];
                if (IsHexDigit(c))
                    numHexChars++;
            }
            // if odd number of characters, discard last character
            if (numHexChars % 2 != 0)
            {
                numHexChars--;
            }
            return numHexChars / 2; // 2 characters per byte
        }

        /// <summary>
        /// Creates a byte array from the hexadecimal string. Each two characters are combined
        /// to create one byte. First two hexadecimal characters become first byte in returned array.
        /// Non-hexadecimal characters are ignored.
        /// </summary>
        /// <param name="hexString">string to convert to byte array</param>
        /// <param name="discarded">number of characters in string ignored</param>
        /// <returns>byte array, in the same left-to-right order as the hexString</returns>
        public static byte[] GetBytes(string hexString, out int discarded)
        {
            discarded = 0;
            string newString = "";
            char c;
            // remove all none A-F, 0-9, characters
            for (int i = 0; i < hexString.Length; i++)
            {
                c = hexString[i];
                if (IsHexDigit(c))
                    newString += c;
                else
                    discarded++;
            }
            // if odd number of characters, discard last character
            if (newString.Length % 2 != 0)
            {
                discarded++;
                newString = newString.Substring(0, newString.Length - 1);
            }

            int byteLength = newString.Length / 2;
            byte[] bytes = new byte[byteLength];
            string hex;
            int j = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
                hex = new String(new Char[] { newString[j], newString[j + 1] });
                bytes[i] = HexToByte(hex);
                j = j + 2;
            }
            return bytes;
        }

        /// <summary>
        /// Método converte bytes para string
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ToString(byte[] bytes)
        {
            string hexString = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                hexString += bytes[i].ToString("X2");
            }
            return hexString;
        }

        /// <summary>
        /// Determines if given string is in proper hexadecimal string format
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static bool InHexFormat(string hexString)
        {
            bool hexFormat = true;

            foreach (char digit in hexString)
            {
                if (!IsHexDigit(digit))
                {
                    hexFormat = false;
                    break;
                }
            }
            return hexFormat;
        }

        /// <summary>
        /// Returns true is c is a hexadecimal digit (A-F, a-f, 0-9)
        /// </summary>
        /// <param name="c">Character to test</param>
        /// <returns>true if hex digit, false if not</returns>
        public static bool IsHexDigit(Char c)
        {
            int numChar;
            int numA = Convert.ToInt32('A');
            int num1 = Convert.ToInt32('0');
            c = Char.ToUpper(c);
            numChar = Convert.ToInt32(c);
            if (numChar >= numA && numChar < (numA + 6))
                return true;
            if (numChar >= num1 && numChar < (num1 + 10))
                return true;
            return false;
        }

        /// <summary>
        /// Converts 1 or 2 character string into equivalant byte value
        /// </summary>
        /// <param name="hex">1 or 2 character string</param>
        /// <returns>byte</returns>
        private static byte HexToByte(string hex)
        {
            if (hex.Length > 2 || hex.Length <= 0)
                throw new ArgumentException("hex must be 1 or 2 characters in length");
            byte newByte = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);
            return newByte;
        }

        /// <summary>
        /// Método criptografar
        /// </summary>
        /// <param name="Str"></param>
        /// <returns></returns>
        public static string Encrypt(string Str)
        {
            int discarded = 0;

            byte[] key = EncrypAndDecryptSecurity.GetBytes("AA AD 8B 4C 00 E1 3F 53 B8 E7 16 BC B5 F4 D1 B9", out discarded);
            byte[] vetor = EncrypAndDecryptSecurity.GetBytes("FA 0E 3C 9B 4F A2 C7 AA 37 0F CA 9B 5A 91 64 08", out discarded);

            while ((Str.Length % 16) != 0)
                Str = Str + " ";

            Str = EncrypAndDecryptSecurity.ToString(_EncrypAndDecryptSecurity.Encrypt(Encoding.UTF8.GetBytes(Str), key, vetor));

            return Str;
        }

        /// <summary>
        /// Método descriptografar
        /// </summary>
        /// <param name="Str"></param>
        /// <returns></returns>
        public static string Decrypt(string Str)
        {
            int discarded = 0;

            byte[] key = EncrypAndDecryptSecurity.GetBytes("AA AD 8B 4C 00 E1 3F 53 B8 E7 16 BC B5 F4 D1 B9", out discarded);
            byte[] vetor = EncrypAndDecryptSecurity.GetBytes("FA 0E 3C 9B 4F A2 C7 AA 37 0F CA 9B 5A 91 64 08", out discarded);

            Str = Encoding.UTF8.GetString(_EncrypAndDecryptSecurity.Decrypt(EncrypAndDecryptSecurity.GetBytes(Str, out discarded), key, vetor)).Trim();

            return Str;
        }
    }

    class _EncrypAndDecryptSecurity
    {
        // Encrypt a byte array into a byte array using a key and an IV
        public static byte[] Encrypt(byte[] clearData, byte[] Key, byte[] IV)
        {
            // Create a MemoryStream to accept the encrypted bytes
            MemoryStream ms = new MemoryStream();

            // Create a symmetric algorithm.
            // We are going to use Rijndael because it is strong and
            // available on all platforms.
            // You can use other algorithms, to do so substitute the
            // next line with something like
            //      TripleDES alg = TripleDES.Create();
            Rijndael alg = Rijndael.Create();
            alg.Mode = System.Security.Cryptography.CipherMode.CBC;
            alg.Padding = System.Security.Cryptography.PaddingMode.None;
            alg.KeySize = 128;

            // Now set the key and the IV.
            // We need the IV (Initialization Vector) because
            // the algorithm is operating in its default
            // mode called CBC (Cipher Block Chaining).
            // The IV is XORed with the first block (8 byte)
            // of the data before it is encrypted, and then each
            // encrypted block is XORed with the
            // following block of plaintext.
            // This is done to make encryption more secure.

            // There is also a mode called ECB which does not need an IV,
            // but it is much less secure.
            alg.Key = Key;
            alg.IV = IV;

            // Create a CryptoStream through which we are going to be
            // pumping our data.
            // CryptoStreamMode.Write means that we are going to be
            // writing data to the stream and the output will be written
            // in the MemoryStream we have provided.
            CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);

            // Write the data and make it do the encryption
            cs.Write(clearData, 0, clearData.Length);

            // Close the crypto stream (or do FlushFinalBlock).
            // This will tell it that we have done our encryption and
            // there is no more data coming in,
            // and it is now a good time to apply the padding and
            // finalize the encryption process.
            cs.Close();

            // Now get the encrypted data from the MemoryStream.
            // Some people make a mistake of using GetBuffer() here,
            // which is not the right way.
            byte[] encryptedData = ms.ToArray();

            return encryptedData;
        }

        public static string Encrypt(string clearText, string Password)
        {
            // First we need to turn the input string into a byte array.
            byte[] clearBytes = System.Text.Encoding.Unicode.GetBytes(clearText);

            // Then, we need to turn the password into Key and IV
            // We are using salt to make it harder to guess our key
            // using a dictionary attack -
            // trying to guess a password by enumerating all possible words.
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(
                Password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

            // Now get the key/IV and do the encryption using the
            // function that accepts byte arrays.
            // Using PasswordDeriveBytes object we are first getting
            // 32 bytes for the Key
            // (the default Rijndael key length is 256bit = 32bytes)
            // and then 16 bytes for the IV.
            // IV should always be the block size, which is by default
            // 16 bytes (128 bit) for Rijndael.
            // If you are using DES/TripleDES/RC2 the block size is
            // 8 bytes and so should be the IV size.
            // You can also read KeySize/BlockSize properties off
            // the algorithm to find out the sizes.
            byte[] encryptedData = Encrypt(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16));

            // Now we need to turn the resulting byte array into a string.
            // A common mistake would be to use an Encoding class for that.
            //It does not work because not all byte values can be
            // represented by characters.
            // We are going to be using Base64 encoding that is designed
            //exactly for what we are trying to do.
            return Convert.ToBase64String(encryptedData);
        }

        // Encrypt bytes into bytes using a password
        //    Uses Encrypt(byte[], byte[], byte[])

        public static byte[] Encrypt(byte[] clearData, string Password)
        {
            // We need to turn the password into Key and IV.
            // We are using salt to make it harder to guess our key
            // using a dictionary attack -
            // trying to guess a password by enumerating all possible words.
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(
                Password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

            // Now get the key/IV and do the encryption using the function
            // that accepts byte arrays.
            // Using PasswordDeriveBytes object we are first getting
            // 32 bytes for the Key
            // (the default Rijndael key length is 256bit = 32bytes)
            // and then 16 bytes for the IV.
            // IV should always be the block size, which is by default
            // 16 bytes (128 bit) for Rijndael.
            // If you are using DES/TripleDES/RC2 the block size is 8
            // bytes and so should be the IV size.
            // You can also read KeySize/BlockSize properties off the
            // algorithm to find out the sizes.
            return Encrypt(clearData, pdb.GetBytes(32), pdb.GetBytes(16));
        }

        // Encrypt a file into another file using a password
        public static void Encrypt(string fileIn, string fileOut, string Password)
        {
            // First we are going to open the file streams
            FileStream fsIn = new FileStream(fileIn,
                FileMode.Open, FileAccess.Read);
            FileStream fsOut = new FileStream(fileOut,
                FileMode.OpenOrCreate, FileAccess.Write);

            // Then we are going to derive a Key and an IV from the
            // Password and create an algorithm
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(
                Password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

            Rijndael alg = Rijndael.Create();
            alg.Key = pdb.GetBytes(32);
            alg.IV = pdb.GetBytes(16);

            // Now create a crypto stream through which we are going
            // to be pumping data.
            // Our fileOut is going to be receiving the encrypted bytes.
            CryptoStream cs = new CryptoStream(fsOut, alg.CreateEncryptor(), CryptoStreamMode.Write);

            // Now will will initialize a buffer and will be processing
            // the input file in chunks.
            // This is done to avoid reading the whole file (which can
            // be huge) into memory.
            int bufferLen = 4096;
            byte[] buffer = new byte[bufferLen];
            int bytesRead;

            do
            {
                // read a chunk of data from the input file
                bytesRead = fsIn.Read(buffer, 0, bufferLen);

                // encrypt it
                cs.Write(buffer, 0, bytesRead);
            } while (bytesRead != 0);

            // close everything

            // this will also close the unrelying fsOut stream
            cs.Close();
            fsIn.Close();
        }

        // Decrypt a byte array into a byte array using a key and an IV
        public static byte[] Decrypt(byte[] cipherData, byte[] Key, byte[] IV)
        {
            // Create a MemoryStream that is going to accept the
            // decrypted bytes
            MemoryStream ms = new MemoryStream();

            // Create a symmetric algorithm.
            // We are going to use Rijndael because it is strong and
            // available on all platforms.
            // You can use other algorithms, to do so substitute the next
            // line with something like
            //     TripleDES alg = TripleDES.Create();
            Rijndael alg = Rijndael.Create();
            alg.Mode = System.Security.Cryptography.CipherMode.CBC;
            alg.Padding = System.Security.Cryptography.PaddingMode.None;
            alg.KeySize = 128;

            // Now set the key and the IV.
            // We need the IV (Initialization Vector) because the algorithm
            // is operating in its default
            // mode called CBC (Cipher Block Chaining). The IV is XORed with
            // the first block (8 byte)
            // of the data after it is decrypted, and then each decrypted
            // block is XORed with the previous
            // cipher block. This is done to make encryption more secure.
            // There is also a mode called ECB which does not need an IV,
            // but it is much less secure.
            alg.Key = Key;
            alg.IV = IV;

            // Create a CryptoStream through which we are going to be
            // pumping our data.
            // CryptoStreamMode.Write means that we are going to be
            // writing data to the stream
            // and the output will be written in the MemoryStream
            // we have provided.
            CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);

            // Write the data and make it do the decryption
            cs.Write(cipherData, 0, cipherData.Length);

            // Close the crypto stream (or do FlushFinalBlock).
            // This will tell it that we have done our decryption
            // and there is no more data coming in,
            // and it is now a good time to remove the padding
            // and finalize the decryption process.
            cs.Close();

            // Now get the decrypted data from the MemoryStream.
            // Some people make a mistake of using GetBuffer() here,
            // which is not the right way.
            byte[] decryptedData = ms.ToArray();

            return decryptedData;
        }

        // Decrypt a string into a string using a password
        //    Uses Decrypt(byte[], byte[], byte[])

        public static string Decrypt(string cipherText, string Password)
        {
            // First we need to turn the input string into a byte array.
            // We presume that Base64 encoding was used
            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            // Then, we need to turn the password into Key and IV
            // We are using salt to make it harder to guess our key
            // using a dictionary attack -
            // trying to guess a password by enumerating all possible words.
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(
                Password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

            // Now get the key/IV and do the decryption using
            // the function that accepts byte arrays.
            // Using PasswordDeriveBytes object we are first
            // getting 32 bytes for the Key
            // (the default Rijndael key length is 256bit = 32bytes)
            // and then 16 bytes for the IV.
            // IV should always be the block size, which is by
            // default 16 bytes (128 bit) for Rijndael.
            // If you are using DES/TripleDES/RC2 the block size is
            // 8 bytes and so should be the IV size.
            // You can also read KeySize/BlockSize properties off
            // the algorithm to find out the sizes.
            byte[] decryptedData = Decrypt(cipherBytes, pdb.GetBytes(32), pdb.GetBytes(16));

            // Now we need to turn the resulting byte array into a string.
            // A common mistake would be to use an Encoding class for that.
            // It does not work
            // because not all byte values can be represented by characters.
            // We are going to be using Base64 encoding that is
            // designed exactly for what we are trying to do.
            return System.Text.Encoding.Unicode.GetString(decryptedData);
        }

        // Decrypt bytes into bytes using a password
        //    Uses Decrypt(byte[], byte[], byte[])

        public static byte[] Decrypt(byte[] cipherData, string Password)
        {
            // We need to turn the password into Key and IV.
            // We are using salt to make it harder to guess our key
            // using a dictionary attack -
            // trying to guess a password by enumerating all possible words.
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(
                Password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

            // Now get the key/IV and do the Decryption using the
            //function that accepts byte arrays.
            // Using PasswordDeriveBytes object we are first getting
            // 32 bytes for the Key
            // (the default Rijndael key length is 256bit = 32bytes)
            // and then 16 bytes for the IV.
            // IV should always be the block size, which is by default
            // 16 bytes (128 bit) for Rijndael.
            // If you are using DES/TripleDES/RC2 the block size is
            // 8 bytes and so should be the IV size.

            // You can also read KeySize/BlockSize properties off the
            // algorithm to find out the sizes.
            return Decrypt(cipherData, pdb.GetBytes(32), pdb.GetBytes(16));
        }

        // Decrypt a file into another file using a password
        public static void Decrypt(string fileIn, string fileOut, string Password)
        {
            // First we are going to open the file streams
            FileStream fsIn = new FileStream(fileIn, FileMode.Open, FileAccess.Read);

            FileStream fsOut = new FileStream(fileOut, FileMode.OpenOrCreate, FileAccess.Write);

            // Then we are going to derive a Key and an IV from
            // the Password and create an algorithm
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(
                Password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

            Rijndael alg = Rijndael.Create();
            alg.Mode = System.Security.Cryptography.CipherMode.CBC;
            alg.Padding = System.Security.Cryptography.PaddingMode.None;
            alg.KeySize = 128;

            alg.Key = pdb.GetBytes(32);
            alg.IV = pdb.GetBytes(16);

            // Now create a crypto stream through which we are going
            // to be pumping data.
            // Our fileOut is going to be receiving the Decrypted bytes.
            CryptoStream cs = new CryptoStream(fsOut, alg.CreateDecryptor(), CryptoStreamMode.Write);

            // Now will will initialize a buffer and will be
            // processing the input file in chunks.
            // This is done to avoid reading the whole file (which can be
            // huge) into memory.
            int bufferLen = 4096;
            byte[] buffer = new byte[bufferLen];
            int bytesRead;

            do
            {
                // read a chunk of data from the input file
                bytesRead = fsIn.Read(buffer, 0, bufferLen);

                // Decrypt it
                cs.Write(buffer, 0, bytesRead);
            } while (bytesRead != 0);

            // close everything
            cs.Close(); // this will also close the unrelying fsOut stream
            fsIn.Close();
        }
    }
}
