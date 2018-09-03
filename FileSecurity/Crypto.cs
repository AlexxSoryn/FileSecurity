using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSecurity
{
    public class Crypto
    {
        Blowfish _blowfish;

        public Crypto(byte[] key)
        {
            _blowfish = new Blowfish(BlowfishAlgorithm.CFB64);
            _blowfish.SetKey(key);
        }

        public void Decrypt(byte[] packet)
        {
            byte[] buffer = _blowfish.Decrypt(packet);
            System.Buffer.BlockCopy(buffer, 0, packet, 0, buffer.Length);
        }

        public void Encrypt(byte[] packet)
        {
            byte[] buffer = _blowfish.Encrypt(packet);
            System.Buffer.BlockCopy(buffer, 0, packet, 0, buffer.Length);
        }

        public Blowfish Blowfish
        {
            get { return _blowfish; }
        }
    }
}
