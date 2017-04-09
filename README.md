# PublicPrivateKeyEncryptionExample
Simple working example of public private key encryption

## References
  * [Crypto Primer](https://blogs.msdn.microsoft.com/plankytronixx/2010/10/22/crypto-primer-understanding-encryption-publicprivate-key-signatures-and-certificates/)
* [Cryptography/A Basic Public Key Example](https://en.wikibooks.org/wiki/Cryptography/A_Basic_Public_Key_Example)
* [Toni Beardon - Public Key Cryptography](https://nrich.maths.org/2200)
* [Extended GCD algorithm (Extended Euclidean Algorithm)](http://amir-shenodua.blogspot.com/2012/06/extended-gcd-algorithm-extended.html)
* [StackExchange - How does asymmetric encryption work?](http://crypto.stackexchange.com/questions/292/how-does-asymmetric-encryption-work)

# Useful code

## Creating the public and private key
```csharp
int p = 17; // 1st large prime (larger)
int q = 13; // 2nd large prime
int pubKey1 = p*q;
int pubKey2 = 11;// < pubKey1 - 65537 is commonly used
int privKey = CalculateExtendedEuclideanAlgorithm(pubKey2, (p - 1) * (q - 1));
```

## Encryption
```csharp
var cipherText = BigInteger.Pow(input, pubKey2) % pubKey1;
```

## Decryption
```csharp
var plainText = (char)(BigInteger.Pow(cipherText, privKey) % pubKey1);
```
