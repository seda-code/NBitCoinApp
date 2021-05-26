using System;
using NBitcoin;

namespace NBitcoinApp
{

    //https://programmingblockchain.gitbook.io/
    class Program
    {
        static void Main(string[] args)
        {
            //will create a key pair and generate a Bitcoin secret from the key for the Network.
            //Same as GetBitCoinSecret-- > para que quiero un BitCoinSecret??
            //Private keys are often represented in Base58Check called a Bitcoin Secret (also known as Wallet Import Format or simply WIF), like Bitcoin Addresses.


            Key privateKey = new Key(); // generate a random private key
            BitcoinSecret testNetPrivateKey = privateKey.GetWif(Network.TestNet);
            Console.WriteLine($"Bitcoin secret: {testNetPrivateKey} for the {Network.TestNet} network: ");
            

            bool WifIsBitcoinSecret = testNetPrivateKey == privateKey.GetWif(Network.TestNet);
            Console.WriteLine($"son iguales : {WifIsBitcoinSecret}");

            //1- Create a simple bitcoin transaction "by hand".
            //The keys are not stored on the network and they can be generated without access to the Internet

            

            PubKey publicKey = privateKey.PubKey;
            Console.WriteLine($"Publicc key: {publicKey}");

            //You can easily get your bitcoin address from your public key and the network on which this address should be used.
            BitcoinAddress bitcoinAdress =publicKey.GetAddress(ScriptPubKeyType.Legacy, Network.TestNet);
            Console.WriteLine($"Bitcoin address : {bitcoinAdress}");

            //PubKey samePublicKey = bitcoinAdress.ItIsNotPossible;            

            var publicKeyHash = publicKey.Hash;
            Console.WriteLine($"Public Key Hash: {publicKeyHash}"); // f6889b21b5540353a29ed18c45ea0031280c42cf
            // var mainNetAddress = publicKeyHash.GetAddress(Network.Main);
            var testNetAddress = publicKeyHash.GetAddress(Network.TestNet);


//Transactions are the most important part of the bitcoin system. Everything else in bitcoin is designed to ensure that transactions can be created,
// propagated on the network, validated, and finally added to the global ledger of transactions (the blockchain).
// Transactions are data structures that encode the transfer of value between participants in the bitcoin system. Each transaction is a public entry in bitcoin’s blockchain, the global double-entry bookkeeping ledger.

        }
    }
}