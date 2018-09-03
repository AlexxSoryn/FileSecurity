using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace FileSecurity
{
    public class Native
    {
        [DllImport("libeay34.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void CAST_set_key(IntPtr _key, int len, byte[] data);

        [DllImport("libeay34.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void BF_set_key(IntPtr _key, int len, byte[] data);

        [DllImport("libeay34.dll")]
        public extern static void BF_ecb_encrypt(byte[] in_, byte[] out_, IntPtr schedule, int enc);

        [DllImport("libeay34.dll")]
        public extern static void BF_cbc_encrypt(byte[] in_, byte[] out_, int length, IntPtr schedule, byte[] ivec, int enc);

        [DllImport("libeay34.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void CAST_cfb64_encrypt(byte[] in_, byte[] out_, int length, IntPtr schedule, byte[] ivec, ref int num, int enc);

        [DllImport("libeay34.dll")]
        public extern static void BF_ofb64_encrypt(byte[] in_, byte[] out_, int length, IntPtr schedule, byte[] ivec, out int num);
    }
}
