using Reflection.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReflectionServiceHost
{
    public static class ReflectionComprassion
    {
        static byte[] outByte;
        static string outString;
        static bool success = true;

        public static byte[] CompressData(string inString)
        {
            Chilkat.Compression compress = new Chilkat.Compression();
            try
            {
                //success = compress.UnlockComponent("Compress12345678_15D72EFCp21Y");
                success = compress.UnlockComponent("VQAoNv.CBX0024_823OC4tZmRCH");//zWE1EL.CBX0024_Q4F2xK0k159o
                if (success == true)
                {
                    compress.Algorithm = "bzip2";
                    compress.Charset = "utf-8";
                    compress.EncodingMode = "base64";
                    outByte = compress.CompressString(inString);
                }
                else { outByte = null; }
            }
            catch (Exception ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return outByte;
        }
        public static byte[] CompressByteData(byte[] inByte)
        {
            Chilkat.Compression compress = new Chilkat.Compression();
            try
            {
                //success = compress.UnlockComponent("Compress12345678_15D72EFCp21Y");
                success = compress.UnlockComponent("VQAoNv.CBX0024_823OC4tZmRCH");//zWE1EL.CBX0024_Q4F2xK0k159o
                if (success == true)
                {
                    compress.Algorithm = "bzip2";
                    compress.Charset = "utf-8";
                    compress.EncodingMode = "base64";
                    outByte = compress.CompressBytes(inByte);
                }
                else { outByte = null; }
            }
            catch (Exception ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return outByte;
        }
        public static string DeCompressData(byte[] inByte)
        {
            Chilkat.Compression compress = new Chilkat.Compression();
            try
            {
                //success = compress.UnlockComponent("Compress12345678_15D72EFCp21Y");
                success = compress.UnlockComponent("VQAoNv.CBX0024_823OC4tZmRCH");//zWE1EL.CBX0024_Q4F2xK0k159o
                if (success == true)
                {
                    compress.Algorithm = "bzip2";
                    compress.Charset = "utf-8";
                    compress.EncodingMode = "base64";
                    outString = compress.DecompressString(inByte);
                }
                else { outString = ""; }
            }
            catch (Exception ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return outString;
        }
        public static byte[] DeCompressByteData(byte[] inByte)
        {
            Chilkat.Compression compress = new Chilkat.Compression();
            try
            {
                //success = compress.UnlockComponent("Compress12345678_15D72EFCp21Y");
                success = compress.UnlockComponent("VQAoNv.CBX0024_823OC4tZmRCH");//zWE1EL.CBX0024_Q4F2xK0k159o
                if (success == true)
                {
                    compress.Algorithm = "bzip2";
                    compress.Charset = "utf-8";
                    compress.EncodingMode = "base64";
                    outByte = compress.DecompressBytes(inByte);
                }
                else { outByte = null; }
            }
            catch (Exception ex)
            {

            }
            return outByte;
        }
    }
}